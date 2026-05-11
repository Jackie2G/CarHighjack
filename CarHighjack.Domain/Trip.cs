using System.ComponentModel.DataAnnotations;
using CarHighjack.Domain;

namespace CarHighjack.Domain
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        public bool Active { get; set; }
        public long StartMileage { get; set; }
        public string? StartLocation { get; set; }
        public DateTime StartUTCTime { get; set; }
        public long EndMileage { get; set; }
        public string? EndLocation { get; set; }
        public DateTime EndUTCTime { get; set; }
        public string? Project { get; set; }
        public float Cost { get; set; }
        public string? CostRemarks { get; set; }
        public int BookingId { get; set; }
        public Booking? Booking { get; set; }
    }
}