using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCrud.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage ="Name can only be of 20 characters")]
        public string Name { get; set; }

       
    }
}
