using OnRideApp.Models.DomainModel;

namespace OnRideApp.Repositories
{
    public interface ICabRepository
    {
        public Cab getRandomAvailableCab();
    }
}
