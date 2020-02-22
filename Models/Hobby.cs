using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace HobbyHub.Models
{
    public class Hobby 
    {
        [Key]
        public int HobbyId {get;set;}

        public int CreatedById {get; set;}

        [Required]
        public string Name {get; set;}

        [Required]
        public string Description {get; set;}

        public List<Enthusiast> Users {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;


    }


}