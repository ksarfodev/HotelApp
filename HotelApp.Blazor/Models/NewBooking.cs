namespace HotelApp.Blazor.Models
{
    //Model created for Json serialization
    public class NewBooking
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomTypeId { get; set; }
    }
}
