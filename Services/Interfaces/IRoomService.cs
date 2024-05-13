using HotelBooking.DTO;

namespace HotelBooking.Services.Interfaces;

public interface IRoomService
{
    Task<IEnumerable<AvailableRoomsResponse>> GetAvailableRoomsAsync();
}
