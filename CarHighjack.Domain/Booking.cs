using System.ComponentModel.DataAnnotations;

namespace CarHighjack.Domain
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "ID uzytkownika jest wymagane")]
        public string? UserId { get; set; }

        [Required(ErrorMessage = "VIN samochodu jest wymagany")]
        public string? CarVIN { get; set; }

        [Required(ErrorMessage = "Data rozpoczecia jest wymagana")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Data zakonczenia jest wymagana")]
        public DateTime EndDate { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Koszt projektu jest wymagany")]
        public string? ProjectCost { get; set; }

        public DateTime CarTakenUTC { get; set; }
        public DateTime CarReturnedUTC { get; set; }

        [Range(0, 3, ErrorMessage = "Status rezerwacji musi byc miedzy 0 a 3")]
        public int BookingStatus { get; set; }

        public Car? Car { get; set; }
    }
}