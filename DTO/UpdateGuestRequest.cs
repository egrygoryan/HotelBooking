namespace HotelBooking.DTO;

public sealed record UpdateGuestRequest(
    int Id,
    string Name,
    string Email);
