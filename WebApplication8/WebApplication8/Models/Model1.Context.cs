﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ProjectdbEntities : DbContext
    {
        public ProjectdbEntities()
            : base("name=ProjectdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<std_addr> std_addr { get; set; }
        public virtual DbSet<std_contact> std_contact { get; set; }
        public virtual DbSet<std_infor> std_infor { get; set; }
    
        public virtual ObjectResult<showallstd_Result> showallstd()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<showallstd_Result>("showallstd");
        }
    }
}
