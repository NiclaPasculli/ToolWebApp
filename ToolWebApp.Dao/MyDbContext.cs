using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using ToolWebApp.Domain;

namespace ToolWebApp.Dao
{
     class MyDbContext : DbContext
    {
        public DbSet<Tool> Tool { get; set; }
        public DbSet<Turret> Turret { get; set; }




        public MyDbContext() : base("name=ToolsConnectionString")
        {
            Database.Log = sql => Debug.Write(sql);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Config");

            modelBuilder.Entity<Tool>().ToTable("Tools");
            modelBuilder.Entity<Turret>().ToTable("Turrets");



            modelBuilder.Entity<Tool>()
                    .HasKey(t => t.IdTool);
            modelBuilder.Entity<Tool>()
                    .Property(t => t.IdTool)
                    .HasMaxLength(50);
            modelBuilder.Entity<Tool>()
                    .Property(t => t.BoschCode)
                    .HasMaxLength(50)
                    .IsRequired();
            modelBuilder.Entity<Tool>()
                    .Property(t => t.Description)
                    .HasMaxLength(100);
            modelBuilder.Entity<Tool>()
                    .Property(t => t.PrimarySupplier)
                    .HasMaxLength(50);
            modelBuilder.Entity<Tool>()
                    .Property(t => t.SecondarySupplier)
                    .HasMaxLength(50);
            modelBuilder.Entity<Tool>()
                    .Property(t => t.PrimarySharpener)
                    .HasMaxLength(50);
            modelBuilder.Entity<Tool>()
                    .Property(t => t.SecondarySharpener)
                    .HasMaxLength(50);
            modelBuilder.Entity<Tool>()
                    .Property(t => t.Quantity)
                    .IsOptional();
                    
            modelBuilder.Entity<Tool>()
                    .Property(t => t.PresettingQuoteNGEM1)
                    .HasMaxLength(50);
            modelBuilder.Entity<Tool>()
                    .Property(t => t.PresettingQuoteNGEM2)
                    .HasMaxLength(50);
            modelBuilder.Entity<Tool>()
                    .Property(t => t.PresettingDiameter)
                    .HasMaxLength(50);
            modelBuilder.Entity<Tool>()
                    .Property(t => t.Life)
                    .IsOptional();
            modelBuilder.Entity<Tool>()
                    .Property(t => t.SProposal)
                    .HasMaxLength(50);
            modelBuilder.Entity<Tool>()
                    .Property(t => t.FProposal)
                    .HasMaxLength(50);
            modelBuilder.Entity<Tool>()
                    .Property(t => t.SValue)
                    .HasMaxLength(50);
            modelBuilder.Entity<Tool>()
                    .Property(t => t.FValue)
                    .HasMaxLength(50);
            modelBuilder.Entity<Tool>()
                    .Property(t => t.Refrigeration)
                    .HasMaxLength(50);
            modelBuilder.Entity<Tool>()
                    .Property(t => t.Accessories)
                    .HasMaxLength(100);
            modelBuilder.Entity<Tool>()
                   .Property(t => t.TurretCode)
                   .HasMaxLength(50);





            modelBuilder.Entity<Turret>()
                .HasKey(t => t.TurretCode);

            modelBuilder.Entity<Turret>()
                .Property(t => t.TurretCode);
            modelBuilder.Entity<Turret>()
                .Property(t => t.Description)
                .HasMaxLength(50);
        }
    }
}
