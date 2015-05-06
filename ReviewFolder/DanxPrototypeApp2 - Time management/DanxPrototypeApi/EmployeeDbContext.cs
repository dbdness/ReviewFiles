namespace DanxPrototypeApi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
            : base("name=EmployeeDbContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
