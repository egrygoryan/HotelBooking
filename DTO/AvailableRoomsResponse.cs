namespace HotelBooking.DTO;

public sealed record AvailableRoomsResponse(
    int RoomNumber,
    string AppartmentType,
    float Price);
