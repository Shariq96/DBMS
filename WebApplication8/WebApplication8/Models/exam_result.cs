//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication8.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class exam_result
    {
        public int class_id { get; set; }
        public int std_id { get; set; }
        public int exam_id { get; set; }
        public string marks_obt { get; set; }
        public Nullable<int> grade_id { get; set; }
    
        public virtual std_infor std_infor { get; set; }
    }
}