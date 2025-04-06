﻿namespace OnRideApp.Models.DomainModel;

public class Review
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public int TripBookingId { get; set; }
    public TripBooking TripBooking { get; set; }
}