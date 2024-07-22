using System.ComponentModel.DataAnnotations;
namespace TrainAPI.Model
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "Not given";

        [Required]
        public decimal Price { get; set; }
        
        

    }
}
