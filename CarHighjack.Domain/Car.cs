using System.ComponentModel.DataAnnotations;

namespace CarHighjack.Domain
{
    public class Car
    {
        [Key]
        [Required(ErrorMessage = "VIN jest wymagany")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "VIN musi miec 17 znakow")]
        public string VIN { get; set; }

        [Required(ErrorMessage = "Numer rejestracyjny jest wymagany")]
        public string? RegistrationNumber { get; set; }

        [Required(ErrorMessage = "Marka jest wymagana")]
        public string? Brand { get; set; }

        [Required(ErrorMessage = "Model jest wymagany")]
        public string? Model { get; set; }

        [Range(1, 9, ErrorMessage = "Liczba miejsc musi byc miedzy 1 a 9")]
        public int SeatsNumber { get; set; }

        [Range(2, 5, ErrorMessage = "Liczba drzwi musi byc miedzy 2 a 5")]
        public int Doors { get; set; }

        [Range(1, 9999, ErrorMessage = "Pojemnosc bagaznika musi byc wieksza od 0")]
        public int Trunk { get; set; }

        [Range(1, 2000, ErrorMessage = "Moc silnika musi byc miedzy 1 a 2000 KM")]
        public int HorsePower { get; set; }

        public string? Engine { get; set; }
        public string? TyreSize { get; set; }
        public int Fuel { get; set; }
        public string? CardPin { get; set; }
        public DateTime Insurance { get; set; }
        public DateTime TechnicalReview { get; set; }
        public string? PhotoPath { get; set; }
    }
}