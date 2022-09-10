using System.ComponentModel.DataAnnotations;

namespace HotelApp.Blazor.Models
{
    //Used with Dependency Injection to pass values between pages
    public class RoomSelection
    {
        public RoomTypeModel? RoomType { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

        [Required]
        [StringLength(maximumLength: 50,ErrorMessage ="Please enter a name",MinimumLength = 1)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Please enter a name", MinimumLength = 1)]
        public string? LastName { get; set; }
    }
}
