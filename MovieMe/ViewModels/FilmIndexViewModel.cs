﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieMe.ViewModels
{
    public class FilmIndexViewModel
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfRelese { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^10(\.0{0,1})? *%?$|^\d{1,1}(\.\d{1,1})? *%?$",
        ErrorMessage = "Only numbers with or without two decimal from 0 to 10")]
        public double IMDBRating { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "You must provide movie amount")]
        [Range(0, 10000, ErrorMessage = "Amount should be between 0 and 10 000!")]
        public int Amount { get; set; }
        [Required(ErrorMessage = "You must provide furniture price")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Price should between 1 and 999999999")]
        public double Price { get; set; }
        public string DirectorName  { get; set; }
        public string ProducerName  { get; set; }
        public string GenreName { get; set; }
        public string[] Actors { get; set; }
       
    }
}