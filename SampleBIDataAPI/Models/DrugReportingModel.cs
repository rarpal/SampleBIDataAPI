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
//[Dim QOF Group].[QOF Condition].&[10073]

namespace SampleBIDataAPI.Models
{
    public class DrugReportingModelHelper
    {
        public ConditionDimension ConditionDimension { get; set; }
        //ConceptDimension DrugConceptDimension;

        public DrugReportingModelHelper()
        {
            ConditionDimension = new ConditionDimension();
            //DrugConceptDimension = new ConceptDimension("DESCENDANTS([Dim Concept].[Concept].&[254819],[Dim Concept].[Concept].[Level 02],AFTER)");
        }
        

        public void GetMeasureOnAllDrugsByCondition<T>(Measure<T> measure, ConditionMember conditionmember)
        {
            // construct the MDX, execute and return an IQueriable result to the controller
            string mdxQuery = null;

            mdxQuery += "SELECT " + measure.Dimension + "." + measure.MemberName + "ON 0, " +
                "NON EMPTY DESCENDANTS([Dim Concept].[Concept].&[254819],[Dim Concept].[Concept].[Level 02],AFTER) ON 1 " +
                "PATIENTCT" +
                "WHERE " + conditionmember;

            using (AdomdConnection dc = new AdomdConnection(DataConnection.GetSSASConnectionString()))
            {

                using (AdomdCommand dcom = new AdomdCommand(mdxQuery, dc))
                {
                    dc.Open();
                    AdomdDataReader dr = dcom.ExecuteReader();

                }
                
                
                //dc.Open();
                //AdomdCommand dcom = new AdomdCommand(mdxQuery, dc);
                //DataSet dset = new DataSet();
                //dset.EnforceConstraints = false;
                //dset.Tables.Add("Results");
                //dset.Tables["Results"].Load(dcom.ExecuteReader());

                
            }
            
            
            
            IQueryable result = null;


            
            

            //return result;
        }
        
        public ConditionMember GetConditionMemberByName(string condition)
        {
            ConditionMember conditionmember = new ConditionMember();

            foreach (var item in ConditionDimension.Members)
            {
                if (item.MemberName == condition)
                {
                    return (ConditionMember)item;
                }
            }

            return null;
        }
    }
}