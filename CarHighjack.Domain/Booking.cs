using System.ComponentModel.DataAnnotations;
using CarHighjack.Domain;

namespace CarHighjack.Domain
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? CarVIN { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public string? ProjectCost { get; set; }
        public DateTime CarTakenUTC { get; set; }
        public DateTime CarReturnedUTC { get; set; }
        public int BookingStatus { get; set; }
        public Car? Car { get; set; }
    }
}