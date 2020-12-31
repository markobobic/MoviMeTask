using MovieMe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieMe.ViewModels
{
    public class FilmUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Must be between 1 and 50")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime DateOfRelese { get; set; }
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
        [Required]
        public  int DirectorId { get; set; }
        [Required]
        public  int ProducerId { get; set; }
        [Required]
        public  int GenreId { get; set; }
        [Required]
        public int[] ActorsSelectedIds { get; set; }
        public List<SelectListItem> SelectedActors { get; set; } = new List<SelectListItem>();

        public FilmUpdateViewModel()
        {

        }
        public FilmUpdateViewModel(Film film)
        {
            Id = film.Id;
            Name = film.Name;
            DateOfRelese = film.DateOfRelese;
            IMDBRating = film.IMDBRating;
            Description = film.Description;
            Amount = film.Amount;
            Price = film.Price;
            DirectorId = film.Director.Id;
            ProducerId = film.Producer.Id;
            GenreId = film.Genre.Id;
            ActorsSelectedIds = film.Actors.Select(x => x.Id).ToArray();
            SelectedActors = film.Actors.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
        }

    }
}