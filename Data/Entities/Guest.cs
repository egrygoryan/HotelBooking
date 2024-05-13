namespace HotelBooking.Data.Entities;

public class Guest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Booking> Bookings { get; } = [];
}
