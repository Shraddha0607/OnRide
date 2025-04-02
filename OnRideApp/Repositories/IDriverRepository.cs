using OnRideApp.Models.DomainModel;

namespace OnRideApp.Repositories
{
    public interface IDriverRepository
    {
        Task<Driver> AddAsync(Driver driver);
        public IEnumerable<Driver> GetAll();
    }
}
