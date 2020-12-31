using MovieMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieMe.ViewModels
{
    public class GenreUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public GenreUpdateViewModel()
        {

        }
        public GenreUpdateViewModel(Genre genre)
        {
            Id = genre.Id;
            Name = genre.Name;
            ShortDescription = genre.ShortDescription;
        }
    }
}