using HotelBooking.Models.Constants;

namespace HotelBooking.DTO;

public sealed record BookingResponse(
    int Id,
    string GuestName,
    AppartmentType AppartmentType,
    DateTime CheckInDate,
    DateTime CheckOutDate,
    int NumberOfGuests);
