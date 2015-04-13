using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AnalysisServices.AdomdClient;

// This file contains the sub cube model for drug reporting

//SELECT
//[Measures].[Patient Count] ON 0,
//NON EMPTY DESCENDANTS([Dim Concept].[Concept].&[254819],[Dim Concept].[Concept].[Level 02],AFTER) ON 1
//FROM PATIENTCT
//WHERE 
//[Dim QOF Group].[QOF Condition].[QOF Condition].&[10073]

namespace SampleBIDataAPI.Models
{
    public class DrugData
    {
        public string DrugName { get; set; }
        public int Count { get; set; }
    }
    
    public class DrugReportingModelHelper
    {
        public ConditionDimension ConditionDimension { get; set; }
        //ConceptDimension DrugConceptDimension;

        public DrugReportingModelHelper()
        {
            ConditionDimension = new ConditionDimension();
            //DrugConceptDimension = new ConceptDimension("DESCENDANTS([Dim Concept].[Concept].&[254819],[Dim Concept].[Concept].[Level 02],AFTER)");
        }

        public List<Dictionary<string,object>> GetTableRows(DataTable datatable)
        {
            List<Dictionary<string, object>> listrows = new List<Dictionary<string, object>>();
            Dictionary<string, object> dictrow = null;

            foreach (DataRow rowitem in datatable.Rows)
            {
                dictrow = new Dictionary<string, object>();
                foreach (DataColumn coltem in datatable.Columns)
                {
                    dictrow.Add(coltem.ColumnName, rowitem[coltem]);
                }
                listrows.Add(dictrow);
            }

            return listrows;
        }
        

        public DataTable GetMeasureOnAllDrugsByCondition<T>(Measure<T> measure, ConditionMember conditionmember)
        {
            // construct the MDX, execute and return an IQueriable result to the controller
            string mdxQuery = null;
            DataSet dset = new DataSet();

            mdxQuery += "SELECT " + measure.Dimension + "." + measure.MemberName + "ON 0, " +
                "NON EMPTY DESCENDANTS([Dim Concept].[Concept].&[254819],[Dim Concept].[Concept].[Level 02],AFTER) ON 1 " +
                "PATIENTCT" +
                "WHERE " + conditionmember.Dimension + "." + conditionmember.Hiearchy + "." + (conditionmember.IsMemberKeyAvailable() ? conditionmember.MemberKey : conditionmember.MemberName);

            using (AdomdConnection dc = new AdomdConnection(DataConnection.GetSSASConnectionString()))
            {

                //using (AdomdCommand dcom = new AdomdCommand(mdxQuery, dc))
                //{
                //    dc.Open();
                //    AdomdDataReader dr = dcom.ExecuteReader();

                //}

                dc.Open();
                AdomdCommand dcom = new AdomdCommand(mdxQuery, dc);
                dset.EnforceConstraints = false;
                dset.Tables.Add("Results");
                dset.Tables["Results"].Load(dcom.ExecuteReader());
            }
            
            IQueryable result = null;
            //return result;
            return dset.Tables[0];
        }
    }
}