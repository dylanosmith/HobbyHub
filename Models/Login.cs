using System;
using System.ComponentModel.DataAnnotations;

namespace HobbyHub.Models
{
    public class Login
    {
        [Required]
        [MinLength(3, ErrorMessage = "Username must be more than 3 characters")]
        [MaxLength(15,ErrorMessage = "Username must be less than 15 characters")]
        public string Username {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password {get; set;}

    }

}