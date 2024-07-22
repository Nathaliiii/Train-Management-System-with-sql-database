﻿using System.ComponentModel.DataAnnotations;

namespace TrainAPI.Models
{
    public class Train
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Capacity { get; set; }
        
    }
}

