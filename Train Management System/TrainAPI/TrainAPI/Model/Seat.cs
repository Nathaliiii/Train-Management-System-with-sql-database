using System.ComponentModel.DataAnnotations;

namespace TrainAPI.Models
{
    public class Seat
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string SeatNumber { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public decimal Price { get; set; }
        // Add any other properties needed for the Seat model
    }
}

