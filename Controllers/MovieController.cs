using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IntroToLINQandASPLabs.Models;
using IntroToLINQandASPLabs.Data;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;

namespace IntroToLINQandASPLabs.Controllers
{
    public class MovieController : Controller
    {
        // GET: MovieController
        public IActionResult Index()
        {

            return View(Context.Movies);
        }



        // GET: MovieController/Details/5
        public IActionResult GetMovieInfo(int movieid)
        {
            if (movieid == 0) { return View(); }

            Movie movie = Context.Movies.FirstOrDefault(m => m.Id == movieid);
            if (movie == null) { return View(); } else
            {
                return View(movie);
            }
        }

        public IActionResult InGenre(string genre)
        {
            List<string> genres = Enum.GetNames(typeof(Context.Genres)).ToList();
            if (genres.Contains(genre, StringComparer.OrdinalIgnoreCase))
            {
                HashSet<Movie> moviesInGenre = Context.Movies.Where(m => m.Genre.ToString().ToLower() == genre.ToLower()).ToHashSet();
                
                    return View("Index", moviesInGenre);

                
            } else
            {
                return RedirectToAction("Error");
            }

            /*
             * 
             * HashSet<Movie> moviesInGenre = Context.Movies.Where(m => m.Genre.ToString().ToLower() == genre.ToLower()).ToHashSet();
             * if (moviesInGenre.Count > 0) {
             * return View("Index", moviesInGenre)
             * } else {
             * return NotFound();
             * }
             */
        }

        public IActionResult GetCountInGenre()
        {
            Dictionary<string,int> CountOfGenre = new Dictionary<string,int>();
            foreach (Movie movie in Context.Movies)
            {
                string genre = movie.Genre.ToString();
                if (CountOfGenre.Keys.Contains(genre))
                {
                    CountOfGenre[genre]++;
                } else
                {
                    CountOfGenre[genre] = 1;
                }
            }


            return View(CountOfGenre);
        }

        public IActionResult MoviesInBudget(int lower, int upper)
        {
            HashSet<Movie> moviesWithinBudget = Context.Movies.Where(m => m.Budget >= lower && m.Budget <= upper).ToHashSet();
            if(moviesWithinBudget.Count > 0)
            {
                return View("Index", moviesWithinBudget);

            } else
            {
                return View("Index", new HashSet<Movie>());
            }

        }

        public IActionResult MoviesInThe90s() 
        {
            HashSet<Movie> In90s = Context.Movies.Where(m => m.ReleaseDate.Year >= 1990 && m.ReleaseDate.Year <= 2000).ToHashSet();
            
            return View("Index", In90s);
        }
       

       

       

        

        

        
    }
}
