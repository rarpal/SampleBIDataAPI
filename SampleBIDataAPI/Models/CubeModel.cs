using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// This file contains entire the cube model

namespace SampleBIDataAPI.Models
{
    public class ConceptMember
    {
        public string MemberKey { get; set; }
        public string MemberName { get; set; }
        public string Dimension { get; set; }
        public string Hiearchy { get; set; }
        public string Level { get; set; }

        public ConceptMember(string membername, string memberkey)
        {
            Dimension = "[Dim QOF Group]";
            Hiearchy = "[QOF Condition]";
            Level = "[QOF Condition]";
            MemberName = membername;
            MemberKey = memberkey;
        }
    }
    
    public class ConceptDimension
    {
        public List<ConceptMember> Members { get; set; }

        public ConceptDimension()
        {

        }

        public ConceptDimension(string expression)
        {

        }
    }

    public class ConditionMember
    {
        public string MemberKey { get; set; }
        public string MemberName { get; set; }
        public string Dimension { get; set; }
        public string Hiearchy { get; set; }
        public string Level { get; set; }

        public ConditionMember(string membername, string memberkey)
        {
            Dimension = "[Dim QOF Group]";
            Hiearchy = "[QOF Condition]";
            Level = "[QOF Condition]";
            if (!String.IsNullOrWhiteSpace(memberkey))
            {
                MemberKey = memberkey;
            }
            else
            {
                MemberName = membername;
            }
        }

        public bool IsMemberKeyAvailable()
        {
            return !String.IsNullOrWhiteSpace(MemberKey);
        }

    }

    public class ConditionDimension
    {
        public List<ConditionMember> Members { get; set; }
        
        public ConditionDimension()
        {
            // populate members with all conditions
        }

        public ConditionDimension(string expression)
        {

        }
    }

    public class PatientCountMeasure
    {
        public string MemberName { get; set; }
        public string Dimension { get; set; }

        public PatientCountMeasure()
        {
            MemberName = "[Patient Count]";
            Dimension = "[Measures]";
        }
    }

    public class PrescriptionCountMeasure
    {
        public string MemberName { get; set; }
        public string Dimension { get; set; }

        public PrescriptionCountMeasure()
        {
            MemberName = "[Prescription Count]";
            Dimension = "[Measures]";
        }
    }

    public class PrescriptionCostMeasure
    {
        public string MemberName { get; set; }
        public string Dimension { get; set; }

        public PrescriptionCostMeasure()
        {
            MemberName = "[Prescription Cost]";
            Dimension = "[Measures]";
        }
    }

    public class Measure<T>
    {
        public string MemberName { get; set; }
        public string Dimension { get; set; }
        public T MeasureValue { get; set; }
    }
}