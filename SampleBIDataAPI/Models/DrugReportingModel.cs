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
        public class DrugMember
        {
            public string MemberKey { get; set; }
            public string MemberName { get; set; }
            public string ReferenceProperty { get; set; }
        }

        public class DrugDimension
        {
            public List<DrugMember> DrugMembers;

            public DrugDimension()
            {
                // populate DrugMembers with only drug members hard coded
            }
        }
        
        public void GetMeasureOnAllDrugsByCondition<T>(Measure<T> measure, ConditionMember conditionmember)
        {
            // construct the MDX, execute and return an IQueriable result to the controller
            string mdxQuery = null;

            using (AdomdConnection dc = new AdomdConnection(DataConnection.GetSSASConnectionString()))
            {
                dc.Open();
                AdomdCommand dcom = new AdomdCommand(mdxQuery, dc);
                DataSet dset = new DataSet();
                dset.EnforceConstraints = false;
                dset.Tables.Add("Results");
                dset.Tables["Results"].Load(dcom.ExecuteReader());

                
            }
            
            
            
            IQueryable result = null;


            
            

            //return result;
        }

        public List<ConditionMember> GetAllConditionMembers()
        {
            ConditionDimension conditiondimension = new ConditionDimension();

            return conditiondimension.Members;
        }
        
        public ConditionMember GetConditionMemberByName(string condition)
        {
            ConditionDimension conditiondimension = new ConditionDimension();
            ConditionMember conditionmember = new ConditionMember();
            
            foreach (var item in conditiondimension.Members)
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