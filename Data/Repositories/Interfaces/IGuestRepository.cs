using HotelBooking.Data.Entities;

namespace HotelBooking.Data.Repositories.Interfaces;

public interface IGuestRepository
{
    Task<Guest> GetByIdAsync(int id);
    Task UpdateAsync(Guest guest);
}
