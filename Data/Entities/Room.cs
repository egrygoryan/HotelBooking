using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Data.Entities;

public class Room
{
    [Key]
    public int Number { get; set; }
    public bool IsOccupied { get; set; }
    public RoomType RoomType { get; set; }
    public int RoomTypeId { get; set; }
}
