using HotelBooking.Data.Entities;
using HotelBooking.Data.Repositories.Interfaces;
using HotelBooking.DTO;
using HotelBooking.Models.Constants;
using HotelBooking.Services.Interfaces;
using static HotelBooking.Models.MaxPeopleInAppartments;

namespace HotelBooking.Services;

public sealed class BookingService(
    IBookingRepository bookingRepo,
    IGuestRepository guestRepo,
    IRoomRepository roomRepo) : IBookingService
{
    public async Task CreateBookingAsync(CreateBookingRequest request)
    {
        //check the checkin date is less then checkout
        if (request.CheckInDate >= request.CheckOutDate)
        {
            throw new ArgumentException("Check in date can't be greater or equal to check out date");
        }

        //check if check in date is not in the past
        if (request.CheckInDate.Date < DateTime.Now.Date)
        {
            throw new ArgumentException("Check in date should be today or in the future");
        }
        //check if we have available rooms
        //with certain type
        var availableRooms = await roomRepo.GetAvailableRoomsAsync(request.AppartmentType);

        if (!availableRooms.Any())
        {
            throw new ArgumentException($"There is no available appartments {request.AppartmentType} in hotel");
        }

        //retrieve provided number of guests
        int maxPeople = request.AppartmentType switch
        {
            AppartmentType.Studio => MaxStudio,
            AppartmentType.Luxe => MaxLuxe,
            AppartmentType.Penthouse => MaxPenthouse,
            _ => 0
        };

        //compare it with valid values
        if (request.NumberOfGuests > maxPeople)
        {
            throw new ArgumentException("Number of guests can't exceed appartment's capacity");
        }

        if (request.NumberOfGuests == 0)
        {
            throw new ArgumentException("Can't create a booking with no guests");
        }

        //take the guest from repo
        var guest = await guestRepo.GetByIdAsync(request.GuestId);

        //set room as occupied
        //by default will be taken first available room 
        //of certain type
        var roomToBook = availableRooms.First();
        await roomRepo.SetRoomOccupiedAsync(roomToBook);

        //create new booking entity
        var booking = new Booking()
        {
            Guest = guest,
            CheckInDate = request.CheckInDate,
            CheckOutDate = request.CheckOutDate,
            CreateDate = DateTime.UtcNow,
            NumberOfGuests = request.NumberOfGuests,
            RoomTypeId = roomToBook.RoomTypeId
        };

        // add it to repo
        await bookingRepo.AddAsync(booking);

    }

    public async Task DeleteBookingAsync(DeleteBookingRequest request)
    {
        //find booking entity
        var booking = await bookingRepo.GetByIdAsync(request.Id);

        //pass it to deletion
        await bookingRepo.DeleteAsync(booking);
    }

    public async Task<IEnumerable<BookingResponse>> GetRelatedBookingsAsync(int guestId)
    {
        //retrieve related bookings entities to certain guest
        var bookings = await bookingRepo.GetRelatedAsync(guestId);

        //produce result set of dto and return it
        var resultSet = bookings.Select(x =>
            new BookingResponse(
                Id: x.Id,
                GuestName: x.Guest.Name,
                AppartmentType: (AppartmentType)Enum.Parse(typeof(AppartmentType), x.RoomType.Type),
                CheckInDate: x.CheckInDate,
                CheckOutDate: x.CheckOutDate,
                NumberOfGuests: x.NumberOfGuests))
            .ToList();

        return resultSet;
    }

    public async Task<BookingResponse> GetBookingAsync(int bookingId)
    {
        //get booking entity from repo
        var booking = await bookingRepo.GetByIdAsync(bookingId);

        //transform entity into dto type
        return new BookingResponse(
            Id: booking.Id,
            GuestName: booking.Guest.Name,
            AppartmentType: (AppartmentType)Enum.Parse(typeof(AppartmentType), booking.RoomType.Type),
            CheckInDate: booking.CheckInDate,
            CheckOutDate: booking.CheckOutDate,
            NumberOfGuests: booking.NumberOfGuests);
    }
}
