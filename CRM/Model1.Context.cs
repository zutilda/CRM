﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ApplicationCRM> ApplicationCRM { get; set; }
        public virtual DbSet<ConectedService> ConectedService { get; set; }
        public virtual DbSet<ContractType> ContractType { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<GatewayPhone> GatewayPhone { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<InstallDevice> InstallDevice { get; set; }
        public virtual DbSet<KindServise> KindServise { get; set; }
        public virtual DbSet<Meeting> Meeting { get; set; }
        public virtual DbSet<PassportInfo> PassportInfo { get; set; }
        public virtual DbSet<PortType> PortType { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Subsriber> Subsriber { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypeDevice> TypeDevice { get; set; }
        public virtual DbSet<TypeHouse> TypeHouse { get; set; }
        public virtual DbSet<TypeOfProblem> TypeOfProblem { get; set; }
        public virtual DbSet<TypeService> TypeService { get; set; }
        public virtual DbSet<Adress> Adress { get; set; }
        public virtual DbSet<ListPhone> ListPhone { get; set; }
    }
}
