using System.ComponentModel.DataAnnotations;

namespace CarHighjack.Domain
{
    public class Car
    {
        [Key]
        public string VIN { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int SeatsNumber { get; set; }
        public int Doors { get; set; }
        public int Trunk { get; set; }
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