using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace HobbyHub.Models
{

    public class User
    {
        [Key]
        public int UserId {get; set;}

        [Required]
        [MinLength(2)]
        public string FName {get; set;}

        [Required]
        [MinLength(2)]
        public string LName {get; set;}

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Username {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password {get; set;}

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm {get; set;}

        List<Enthusiast> MyHobbies {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;



    }



}
