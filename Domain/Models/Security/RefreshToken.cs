using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Security
{
    public class RefreshToken {

        [Key]
        public Guid Id { get; set; }

        public string Token { get; set; }

        public DateTime Created { get; set; }

        public DateTime Expiry { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public User User { get; set; }
        
    }
}