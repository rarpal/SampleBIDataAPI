using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using SampleBIDataAPI.Models;
using System.Web.Http.Cors;

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

        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        };

        DrugData[] drugusage = new DrugData[]
        {
            new DrugData {DrugName = "Captopril (bi1..)", Count = 3},
            new DrugData {DrugName = "Cilazapril (bi8..)", Count = 1},
            new DrugData {DrugName = "Enalapril (x01Qe)", Count = 20},
            new DrugData {DrugName = "Lisinopril (bi3..)", Count = 65},
            new DrugData {DrugName = "Perindopril (x01Qg)", Count = 18}
        };
        
        // Get all conditions
        //public List<ConditionMember> GetAllConditions()
        //{
        //    DrugReportingModelHelper helper = new DrugReportingModelHelper();

        //    return helper.ConditionDimension.Members;
        //}

        // Get measure for all drugs by condition and return JSON result to the AJAX client
        //public JsonResult<BarChartData> GetMeasureOnAllDrugsByCondition(string measure, string condition)
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IEnumerable<DrugData> GetMeasureOnAllDrugsByCondition()
        //public JsonResult<DrugData> GetMeasureOnAllDrugsByCondition()
        {
            //string measure = null;
            //string condition = null;
            //BarChartData barchartdata = new BarChartData();
            //DrugReportingModelHelper helper = new DrugReportingModelHelper();
            //ConditionMember conditionmember = helper.GetConditionMemberByName(condition);

            //switch (measure)
            //{
            //    case "Patient Count":
            //        Measure<int> patientcountmeasure = new Measure<int>();
            //        patientcountmeasure.Dimension = "[Measures]";
            //        patientcountmeasure.MemberName = "[Patient Count]";
            //        helper.GetMeasureOnAllDrugsByCondition<int>(patientcountmeasure, conditionmember);
            //        break;
            //    case "Prescription Count":
            //        Measure<int> prescriptioncountmeasure = new Measure<int>();
            //        prescriptioncountmeasure.Dimension = "[Measures]";
            //        prescriptioncountmeasure.MemberName = "[Prescription Count]";
            //        helper.GetMeasureOnAllDrugsByCondition<int>(prescriptioncountmeasure, conditionmember);
            //        break;
            //    case "Prescription Cost":
            //        Measure<double> prescriptioncostmeasure = new Measure<double>();
            //        prescriptioncostmeasure.Dimension = "[Measures]";
            //        prescriptioncostmeasure.MemberName = "[Prescription Cost]";
            //        helper.GetMeasureOnAllDrugsByCondition<double>(prescriptioncostmeasure, conditionmember);
            //        break;
            //    default:
            //        break;
            //}

            //return Json<BarChartData>(barchartdata);
            return drugusage;
        }
    }
}
