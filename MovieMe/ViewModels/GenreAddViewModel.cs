using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieMe.ViewModels
{
    public class GenreAddViewModel
    {
        [Required]
        [StringLength(maximumLength: 30)]
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public GenreAddViewModel()
        {

        }
    }
}