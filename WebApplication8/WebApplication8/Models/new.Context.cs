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
    
    public partial class ProjectdbEntity4 : DbContext
    {
        public ProjectdbEntity4()
            : base("name=ProjectdbEntity4")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<attendance> attendances { get; set; }
        public virtual DbSet<@class> classes { get; set; }
        public virtual DbSet<class_exam> class_exam { get; set; }
        public virtual DbSet<course> courses { get; set; }
        public virtual DbSet<exam> exams { get; set; }
        public virtual DbSet<exam_result> exam_result { get; set; }
        public virtual DbSet<facontact> facontacts { get; set; }
        public virtual DbSet<faculty> faculties { get; set; }
        public virtual DbSet<grade> grades { get; set; }
        public virtual DbSet<std_addr> std_addr { get; set; }
        public virtual DbSet<std_class> std_class { get; set; }
        public virtual DbSet<std_contact> std_contact { get; set; }
        public virtual DbSet<std_infor> std_infor { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<login> logins { get; set; }
    }
}
