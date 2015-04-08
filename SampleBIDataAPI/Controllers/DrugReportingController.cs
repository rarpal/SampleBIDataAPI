using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using SampleBIDataAPI.Models;

namespace SampleBIDataAPI.Controllers
{
    public class DrugReportingController : ApiController
    {
        public class BarChartData
        {
            public int total { get; set; }
            public int page { get; set; }
            public int records { get; set; }
            public object[] rows { get; set; }
        }
        
        // Get all conditions
        public List<ConditionMember> GetAllConditions()
        {
            DrugReportingModelHelper helper = new DrugReportingModelHelper();

            return helper.ConditionDimension.Members;
        }

        // Get measure for all drugs by condition and return JSON result to the AJAX client
        public JsonResult<BarChartData> GetMeasureOnAllDrugsByCondition(string measure, string condition)
        {
            BarChartData barchartdata = new BarChartData();
            DrugReportingModelHelper helper = new DrugReportingModelHelper();
            ConditionMember conditionmember = helper.GetConditionMemberByName(condition);

            switch (measure)
            {
                case "PatientCount":
                    Measure<int> patientcountmeasure = new Measure<int>();
                    patientcountmeasure.Dimension = "[Measures]";
                    patientcountmeasure.MemberName = "[Patient Count]";
                    helper.GetMeasureOnAllDrugsByCondition<int>(patientcountmeasure, conditionmember);
                    break;
                case "PrescriptionCount":
                    Measure<int> prescriptioncountmeasure = new Measure<int>();
                    prescriptioncountmeasure.Dimension = "[Measures]";
                    prescriptioncountmeasure.MemberName = "[Prescription Count]";
                    helper.GetMeasureOnAllDrugsByCondition<int>(prescriptioncountmeasure, conditionmember);
                    break;
                case "PrescriptionCost":
                    Measure<double> prescriptioncostmeasure = new Measure<double>();
                    prescriptioncostmeasure.Dimension = "[Measures]";
                    prescriptioncostmeasure.MemberName = "[Prescription Cost]";
                    helper.GetMeasureOnAllDrugsByCondition<double>(prescriptioncostmeasure, conditionmember);
                    break;
                default:
                    break;
            }

            return Json<BarChartData>(barchartdata);
        }
    }
}
