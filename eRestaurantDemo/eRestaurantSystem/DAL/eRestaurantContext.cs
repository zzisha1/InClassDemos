using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces

using eRestaurantSystem.DAL.Entities;
using System.Data.Entity;

#endregion
namespace eRestaurantSystem.DAL
{
    //this class should be restricted to access by only the BLL methods.
    //this class should not be accessible outside the component library

    //this class inherits Dbcontext

    internal class eRestaurantContext :DbContext
    {
        public eRestaurantContext(): base ("name=EatIn")
        {
            //constructor is used to pass webconfig string name

        }

        //setup the Dbset Mappings
        //one DBSet for each entity i create
        public DbSet<SpecialEvent> SpecialEvents { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Bill> Bills { get; set; }
        
        //when overriding onModelCreating() it is impo to remember to call base method implementation before you exit the method
        //the ManyToManyNavigationPropertyConfiguration.Map method lets you 
        //configure the tables and columns used for many-to-many relationships
        //it takes a ManyToManyNavigationProperty instance in which you specify the column names b calling the MapleftKey, ND TOtABLE METHODS.
        //The left key is the one specified in the HasMany method 
        //the right key is the one specified WithMany method
        //we have a many to many relationship between reservation and tables
        //a reservation may need many tables

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Reservation>().HasMany(r => r.Tables)
                .WithMany(x => x.Reservations)
                .Map(mapping =>
                {
                    mapping.ToTable("ReservationTables");
                    mapping.MapLeftKey("TableID");
                    mapping.MapRightKey("ReservationID");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
