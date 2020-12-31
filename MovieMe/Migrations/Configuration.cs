namespace MovieMe.Migrations
{
    using MovieMe.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieMe.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieMe.Models.ApplicationDbContext context)
        {
            var director = new Director()
            {
                Age = 60,
                ShortDescription = "He was..",
                CityOfBirth = "LA",
                Name = "Ridley Scott"
            };
            var genre = new Genre()
            {
                Name = "Action",
                ShortDescription = "Movies about action"

            };
            List<Actor> actors = new List<Actor>()
            {
               new Actor()
               {
                   Age = 44,
                ShortDescription = "He was..",
                CityOfBirth = "LA",
                Name = "Christian Bale"
               },
               new Actor()
               {
                   Age=50,
                   ShortDescription="He was..",
                   CityOfBirth = "Phoenix",
                   Name="Brad Pitt"
                   
               }
            };
            var producer = new Producer()
            {
                Age = 24,
                ShortDescription = "He was..",
                CityOfBirth = "New York",
                Name = "John Doe"
            };
            var film = new Film()
            {
                DateOfRelese = DateTime.Now,
                Description = "Movie was about..",
                IMDBRating = 7.7,
                Amount = 15,
                Price = 40,
                Director = director,
                Producer = producer,
                Actors = actors,
                Genre=genre,
                Name="Batman"
            };

            context.Actors.AddRange(actors);
            context.Directors.Add(director);
            context.Producers.Add(producer);
            context.Genres.Add(genre);
            context.Films.Add(film);
            context.SaveChanges();

        }
    }
}
