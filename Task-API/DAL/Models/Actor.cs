using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Task_API.DAL.Models
{
    public class Actor
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; } 
    }
}