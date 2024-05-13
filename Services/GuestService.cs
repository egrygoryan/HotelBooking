using HotelBooking.Data.Repositories.Interfaces;
using HotelBooking.DTO;
using HotelBooking.Services.Interfaces;
using System.Text.RegularExpressions;

namespace HotelBooking.Services;

public sealed class GuestService(IGuestRepository guestRepo) : IGuestService
{
    public async Task<RetrieveGuestResponse> GetGuestAsync(int guestId)
    {
        //check If user exists in DB
        var guest = await guestRepo.GetByIdAsync(guestId);

        return new RetrieveGuestResponse(
            Id: guest.Id,
            Name: guest.Name,
            Email: guest.Email);
    }

    public async Task UpdateGuestAsync(UpdateGuestRequest request)
    {
        //check If user exists in DB
        var guest = await guestRepo.GetByIdAsync(request.Id);

        //perform validation on Name & Email before update
        if (!IsValidName(request.Name))
        {
            throw new ArgumentException("Name can contain only letters and digits");
        }

        if (!IsValidEmail(request.Email))
        {
            throw new ArgumentException("Incorrect Email format");
        }

        guest.Name = request.Name;
        guest.Email = request.Email;

        //update guest profile
        await guestRepo.UpdateAsync(guest);
    }

    private static bool IsValidName(string name)
    {
        // pattern for name validation
        string pattern = @"^[a-zA-Z0-9 ]+$";

        // check if name matches the pattern
        return Regex.IsMatch(name, pattern);
    }

    private static bool IsValidEmail(string email)
    {
        // pattern for email validation
        string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

        //check if the email matches the pattern
        return Regex.IsMatch(email, pattern);
    }
}
