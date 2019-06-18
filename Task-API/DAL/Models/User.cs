using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task_API.DAL.Models
{
    public class User
    {
       
        [Key]
        public int ID { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        [Required]
        public string Name { get; set; }

        public bool State { get; set; }
    }
}
