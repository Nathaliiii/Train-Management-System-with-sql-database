﻿using System.ComponentModel.DataAnnotations;

namespace TrainAPI.Models
{
    public class Passenger
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Nationality { get; set; }
        
    }
}
