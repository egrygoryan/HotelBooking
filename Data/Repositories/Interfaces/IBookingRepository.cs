using HotelBooking.Data.Entities;

namespace HotelBooking.Data.Repositories.Interfaces;

public interface IBookingRepository
{
    Task AddAsync(Booking booking);
    Task<IEnumerable<Booking>> GetRelatedAsync(int guestId);
    Task<Booking> GetByIdAsync(int id);
    Task DeleteAsync(Booking booking);
}
