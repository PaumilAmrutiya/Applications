using Repository.FamilyDayCare.ClassLibrary;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Repository.FamilyDayCare.Interfaces;
using System;
using System.Data;

namespace Repository.FamilyDayCare.DataModel
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Oraganisation> Oraganisations { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Suburb> Suburbs { get; set; }

        public DataContext() : base("Data Source=pamrutiya02;Initial Catalog=FDCDatabase;Integrated Security=True")
        {
            //Adding state
            //State state =new State(){ 1,"Victoria","VIC"};

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            foreach (var history in 
                this.ChangeTracker.Entries().Where(e=>e.Entity is IModificationProperties &&
                (e.State == EntityState.Added) && (e.State == EntityState.Modified)).Select(e=>e.Entity as IModificationProperties))

            {
                history.ModifiedDate = DateTime.Now;

                if (history.CreatedDate == DateTime.MinValue)
                {
                    history.CreatedDate = DateTime.Now;
                }
            }

            foreach (var history in this.ChangeTracker.Entries().Where(e=>e.Entity is ICommonProperties && (e.State == EntityState.Added)).Select(e=>e.Entity as ICommonProperties))
            {
                history.IsActive = true;
            }
            int result = base.SaveChanges();

            return result;
        }
    }
}
