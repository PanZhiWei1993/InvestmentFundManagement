﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace testAmazeUI
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FUNDEntities : DbContext
    {
        public FUNDEntities()
            : base("name=FUNDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_constant> tb_constant { get; set; }
        public virtual DbSet<tb_area> tb_area { get; set; }
        public virtual DbSet<tb_PRE> tb_PRE { get; set; }
        public virtual DbSet<tb_Pro_PRE> tb_Pro_PRE { get; set; }
        public virtual DbSet<tb_FileInfo> tb_FileInfo { get; set; }
        public virtual DbSet<tb_notice_docment> tb_notice_docment { get; set; }
        public virtual DbSet<tb_project_image> tb_project_image { get; set; }
        public virtual DbSet<tb_project_docment> tb_project_docment { get; set; }
        public virtual DbSet<tb_interview_record> tb_interview_record { get; set; }
        public virtual DbSet<tb_project> tb_project { get; set; }
        public virtual DbSet<tb_notice> tb_notice { get; set; }
        public virtual DbSet<tb_comment> tb_comment { get; set; }
        public virtual DbSet<tb_user> tb_user { get; set; }
    }
}
