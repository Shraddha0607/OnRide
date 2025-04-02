﻿using OnRideApp.Models.DomainModel;

namespace OnRideApp.Repositories
{
    public interface ITripBookingRepository
    {
        Task<TripBooking> AddAsync(TripBooking tripBooking);
        Task<TripBooking> GetByIdAsync(int id);
    }
}
