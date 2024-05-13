namespace HotelBooking.DTO;

public sealed record RetrieveGuestResponse(
    int Id,
    string Name,
    string Email);
