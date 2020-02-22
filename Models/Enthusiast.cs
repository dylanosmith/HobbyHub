using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HobbyHub.Models
{
    public class Enthusiast 
    {
        [Key]
        public int EnthusiastId {get; set;}

        [Required]
        public int UserId {get; set;}

        [Required]
        public int HobbyId {get; set;}
        public User User {get; set;}

        public Hobby Hobby {get; set;}

    }

}