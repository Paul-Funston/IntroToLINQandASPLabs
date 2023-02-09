using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IntroToLINQandASPLabs.Models;
using IntroToLINQandASPLabs.Data;

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
            if (movieid == 0) { return NotFound(); }

            Movie movie = Context.Movies.FirstOrDefault(m => m.Id == movieid);
            if (movie == null) { return NotFound(); } else
            {
                return View(movie);
            }
        }

        public IActionResult GetAllInGenre()
        {

            return RedirectToAction("Index");
        }

        public IActionResult GetCountInGenre()
        {
            return View();
        }

        public IActionResult MoviesInBudget()
        {
            return View();
        }

        public IActionResult MoviesInThe90s() 
        {
            return View();
        }
       

       

       

        

        

        
    }
}
