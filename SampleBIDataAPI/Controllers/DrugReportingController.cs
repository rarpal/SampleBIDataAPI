using System;
using System.Collections.Generic;
using System.Data;
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

        public class yourdrugdata
        {
            public DrugData[] drugdata = new DrugData[] 
            {
                new DrugData {DrugName = "Captopril (bi1..)", Count = 3},
                new DrugData {DrugName = "Cilazapril (bi8..)", Count = 1},
                new DrugData {DrugName = "Enalapril (x01Qe)", Count = 20},
                new DrugData {DrugName = "Lisinopril (bi3..)", Count = 65},
                new DrugData {DrugName = "Perindopril (x01Qg)", Count = 18}
             };
        }

        
        // Get all conditions
        //public List<ConditionMember> GetAllConditions()
        //{
        //    DrugReportingModelHelper helper = new DrugReportingModelHelper();

        //    return helper.ConditionDimension.Members;
        //}

        // Get measure for all drugs by condition and return JSON result to the AJAX client
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        //public JsonResult<List<Dictionary<string, object>>> GetMeasureOnAllDrugsByCondition(string measure, string condition)
        public DataTable GetMeasureOnAllDrugsByCondition(string measure, string condition)
        //public IEnumerable<DrugData> GetMeasureOnAllDrugsByCondition()
        //public JsonResult<yourdrugdata> GetMeasureOnAllDrugsByCondition()
        //public JsonResult<DrugData[]> GetMeasureOnAllDrugsByCondition()
        {
            //string measure = null;
            //string condition = null;
            //BarChartData barchartdata = new BarChartData();
            //DataRowCollection barchartdata = new DataRowCollection();
            //List<Dictionary<string,object>> barchartdata = new List<Dictionary<string,object>>();
            DataTable barchartdata = new DataTable();
            DrugReportingModelHelper helper = new DrugReportingModelHelper();
            ConditionMember conditionmember = new ConditionMember(null,"&[10073]"); //helper.GetConditionMemberByName(condition);

            switch (measure)
            {
                case "Patient Count":
                    Measure<int> patientcountmeasure = new Measure<int>();
                    patientcountmeasure.Dimension = "[Measures]";
                    patientcountmeasure.MemberName = "[Patient Count]";
                    //barchartdata = helper.GetTableRows(helper.GetMeasureOnAllDrugsByCondition<int>(patientcountmeasure, conditionmember));
                    barchartdata = helper.GetMeasureOnAllDrugsByCondition<int>(patientcountmeasure, conditionmember);
                    break;
                case "Prescription Count":
                    Measure<int> prescriptioncountmeasure = new Measure<int>();
                    prescriptioncountmeasure.Dimension = "[Measures]";
                    prescriptioncountmeasure.MemberName = "[Prescription Count]";
                    //barchartdata = helper.GetTableRows(helper.GetMeasureOnAllDrugsByCondition<int>(prescriptioncountmeasure, conditionmember));
                    barchartdata = helper.GetMeasureOnAllDrugsByCondition<int>(prescriptioncountmeasure, conditionmember);
                    break;
                case "Prescription Cost":
                    Measure<double> prescriptioncostmeasure = new Measure<double>();
                    prescriptioncostmeasure.Dimension = "[Measures]";
                    prescriptioncostmeasure.MemberName = "[Prescription Cost]";
                    //barchartdata = helper.GetTableRows(helper.GetMeasureOnAllDrugsByCondition<double>(prescriptioncostmeasure, conditionmember));
                    barchartdata = helper.GetMeasureOnAllDrugsByCondition<double>(prescriptioncostmeasure, conditionmember);
                    break;
                default:
                    break;
            }

            //return Json<BarChartData>(barchartdata);
            //return drugusage;
            //yourdrugdata yd = new yourdrugdata();
            //return Json<yourdrugdata>(yd);
            //return Json<DrugData[]>(drugusage);
            //return Json<List<Dictionary<string, object>>>(barchartdata);
            return barchartdata;
        }
    }
}
