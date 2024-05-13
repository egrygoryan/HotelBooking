namespace HotelBooking.Data.Entities;

public class RoomType
{
    public int Id { get; set; }
    public string Type { get; set; }
    public float Price { get; set; }
    public string Description { get; set; }
    public int MaxGuests { get; set; }
    public ICollection<Room> Rooms { get; } = new List<Room>();
    public ICollection<Booking> Bookings { get; } = new List<Booking>();
}
