using HotelBooking.Models.Constants;
using System.Text.Json.Serialization;

namespace HotelBooking.DTO;


public sealed class CreateBookingRequest
{
    public int GuestId { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AppartmentType AppartmentType { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfGuests { get; set; }
}