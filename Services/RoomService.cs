using HotelBooking.Data.Repositories.Interfaces;
using HotelBooking.DTO;
using HotelBooking.Services.Interfaces;

namespace HotelBooking.Services;

public sealed class RoomService(IRoomRepository roomRepo) : IRoomService
{
    public async Task<IEnumerable<AvailableRoomsResponse>> GetAvailableRoomsAsync()
    {
        //call repo's layer for retrieving available rooms
        var rooms = await roomRepo.GetAvailableRoomsAsync();

        //create response type 
        //fulfill it with corresponded values from db entity
        var availableRooms = rooms.Aggregate(new List<AvailableRoomsResponse>(), (set, room) =>
        {
            var result = new AvailableRoomsResponse(
                RoomNumber: room.Number,
                AppartmentType: room.RoomType.Type,
                Price: room.RoomType.Price);

            set.Add(result);
            return set;
        });

        return availableRooms;
    }
}
