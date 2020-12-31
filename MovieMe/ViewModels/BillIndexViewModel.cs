using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieMe.ViewModels
{
    public class BillIndexViewModel
    {
       
        public int Id { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        public DateTime TimeOfPurchase { get; set; }
        public string FilmName { get; set; }
    }
}