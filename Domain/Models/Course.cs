using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Course {

        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}