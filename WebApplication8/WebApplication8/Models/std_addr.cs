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
    
    public partial class std_addr
    {
        public int std_id { get; set; }
        public string addr_type { get; set; }
        public string addr { get; set; }
    
        public virtual std_infor std_infor { get; set; }
    }
}
