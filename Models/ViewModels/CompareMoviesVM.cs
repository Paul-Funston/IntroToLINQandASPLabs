using Microsoft.AspNetCore.Mvc.Rendering;
using IntroToLINQandASPLabs.Data;

namespace IntroToLINQandASPLabs.Models.ViewModels
{
    public class CompareMoviesVM
    {
        public List<SelectListItem> Movies = new List<SelectListItem>();
        public string MovieIdOne { get; set; }
        public string MovieIdTwo { get; set; }

        public Movie? MovieOne { get; set; }
        public Movie? MovieTwo { get; set; }


        public CompareMoviesVM() { }

        public CompareMoviesVM(IEnumerable<Movie> movies, string movieIdOne, string movieIdTwo)
        {
            foreach(Movie movie in movies)
            {
                Movies.Add(new SelectListItem(movie.Title, movie.Id.ToString()));
            }

            int idOne;
            int idTwo;
            if (Int32.TryParse(movieIdOne, out idOne) && idOne > 0) 
            { 
                MovieIdOne = movieIdOne;
                MovieOne = Context.Movies.FirstOrDefault(m => m.Id == idOne);
            }
            if (Int32.TryParse(movieIdTwo, out idTwo) && idTwo > 0 && idTwo != idOne) 
            { 
                MovieIdTwo= movieIdTwo;
                MovieTwo = Context.Movies.FirstOrDefault(m => m.Id == idTwo);
            }



        }

        

    }
}
