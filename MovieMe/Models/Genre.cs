using System.ComponentModel.DataAnnotations;

namespace MovieMe.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:30)]
        public string Name { get; set; }
        public string ShortDescription { get; set; }
    }
}