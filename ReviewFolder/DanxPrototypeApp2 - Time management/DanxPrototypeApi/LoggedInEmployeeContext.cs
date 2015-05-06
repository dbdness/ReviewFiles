namespace DanxPrototypeApi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LoggedInEmployeeContext : DbContext
    {
        public LoggedInEmployeeContext()
            : base("name=LoggedInEmployeeContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<LoggedInEmployee> LoggedInEmployees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoggedInEmployee>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
