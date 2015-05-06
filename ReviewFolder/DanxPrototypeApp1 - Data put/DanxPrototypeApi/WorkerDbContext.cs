namespace DanxPrototypeApi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WorkerDbContext : DbContext
    {
        public WorkerDbContext()
            : base("name=WorkerDbContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>()
                .Property(e => e.Worker_name)
                .IsUnicode(false);

            modelBuilder.Entity<Worker>()
                .Property(e => e.Worker_adress)
                .IsUnicode(false);
        }
    }
}
