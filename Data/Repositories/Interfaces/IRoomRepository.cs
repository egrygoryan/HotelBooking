using HotelBooking.Data.Entities;
using HotelBooking.Models.Constants;

namespace HotelBooking.Data.Repositories.Interfaces;

public interface IRoomRepository
{
    Task<Room> GetByIdAsync(int roomNumber);
    Task SetRoomOccupiedAsync(Room toBook);
    Task<IEnumerable<Room>> GetAvailableRoomsAsync(AppartmentType? appartmentType = null);
}
