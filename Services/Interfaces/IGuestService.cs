using HotelBooking.DTO;

namespace HotelBooking.Services.Interfaces;

public interface IGuestService
{
    Task<RetrieveGuestResponse> GetGuestAsync(int guestId);
    Task UpdateGuestAsync(UpdateGuestRequest request);
}
