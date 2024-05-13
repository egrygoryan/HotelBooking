using HotelBooking.DTO;

namespace HotelBooking.Services.Interfaces;

public interface IBookingService
{
    Task CreateBookingAsync(CreateBookingRequest request);
    Task<BookingResponse> GetBookingAsync(int bookingId);
    Task<IEnumerable<BookingResponse>> GetRelatedBookingsAsync(int guestId);
    Task DeleteBookingAsync(DeleteBookingRequest request);
}
