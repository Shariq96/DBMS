using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication8.Models
{
    public class resultView
    {
        public resultView()
        {
            ccr = new HashSet<StudentResult>();
            
        }
        public  StudentResult  ccra { get; set; }
       
        public IEnumerable<StudentResult> ccr { get; set; }
       
    }
}