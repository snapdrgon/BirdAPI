using System.Data.Entity;
using BirdAPI.Models;

namespace BirdAPI
{
    public interface IApplicationDbContext
    {
        DbSet<BirdBreed> BirdBreeds { get; set; }
        DbSet<BirdObserver> BirdObservers { get; set; }
        int SaveChanges();
    }
}