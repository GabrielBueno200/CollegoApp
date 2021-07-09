using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models{
    public class User : IdentityUser{
        
        [Required]
        public string FullName { get; set; }

        public string University { get; set; }

        public string Bio { get; set; }

        public DateTime? BirthDate { get; set; }

        public string CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        public byte[] ProfileThumbnail { get; set; }

    }
}