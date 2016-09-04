namespace GPSView.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB_Model : DbContext
    {
        public DB_Model()
            : base("name=DB_Model")
        {
        }

        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>()
                .HasMany(e => e.Locations)
                .WithRequired(e => e.Device)
                .WillCascadeOnDelete(false);
        }
    }
}
