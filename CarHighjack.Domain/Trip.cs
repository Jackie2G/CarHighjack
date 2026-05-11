using System.ComponentModel.DataAnnotations;

namespace CarHighjack.Domain
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }

        public bool Active { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Przebieg startowy nie moze byc ujemny")]
        public long StartMileage { get; set; }

        [Required(ErrorMessage = "Lokalizacja startowa jest wymagana")]
        public string? StartLocation { get; set; }

        public DateTime StartUTCTime { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Przebieg koncowy nie moze byc ujemny")]
        public long EndMileage { get; set; }

        public string? EndLocation { get; set; }

        public DateTime EndUTCTime { get; set; }

        public string? Project { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Koszt nie moze byc ujemny")]
        public float Cost { get; set; }

        public string? CostRemarks { get; set; }

        [Required(ErrorMessage = "ID rezerwacji jest wymagane")]
        public int BookingId { get; set; }

        public Booking? Booking { get; set; }
    }
}