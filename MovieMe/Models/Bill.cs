using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieMe.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        public DateTime TimeOfPurchase { get; set; }
        public virtual ICollection<Film> Films { get; set; } = new List<Film>();
        
    }
}