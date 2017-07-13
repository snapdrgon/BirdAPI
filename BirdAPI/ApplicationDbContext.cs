namespace BirdAPI
{
    using BirdAPI.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
       
        public virtual DbSet<BirdObserver> BirdObservers { get; set; }
        public virtual DbSet<BirdBreed> BirdBreeds { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }


    }

    
}