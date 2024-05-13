namespace HotelBooking.Data.Entities;

public class Booking
{
    public int Id { get; set; }
    public Guest Guest { get; set; }
    public int GuestId { get; set; }
    public RoomType RoomType { get; set; }
    public int RoomTypeId { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfGuests { get; set; }
}
