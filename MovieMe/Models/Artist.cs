﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieMe.Models
{
    public abstract class Artist
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:30,MinimumLength =1)]
        public string Name { get; set; }
        [Required]
        [Range(1, 105)]
        public int Age { get; set; }
        [Required]
        [StringLength(maximumLength:30)]
        public string CityOfBirth { get; set; }
        public string ShortDescription { get; set; }
        public ICollection<Film> Films { get; set; } = new List<Film>();


    }
}