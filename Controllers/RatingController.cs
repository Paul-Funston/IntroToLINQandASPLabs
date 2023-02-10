using Microsoft.AspNetCore.Mvc;
using IntroToLINQandASPLabs.Models;
using IntroToLINQandASPLabs.Models.ViewModels;
using IntroToLINQandASPLabs.Data;

namespace IntroToLINQandASPLabs.Controllers
{
    public class RatingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        

        [HttpGet]
        public IActionResult Create(int id, bool isActor)
        {
            bool boolTest = isActor;
            CreateRatingVM vm;
            try
            {

                if (isActor)
                {
                    Actor actor = Context.Actors.First(a => a.Id == id);
                    vm = new CreateRatingVM(actor);

                }
                else
                {
                    Movie movie = Context.Movies.First(m => m.Id == id);
                    vm = new CreateRatingVM(movie);
                }
            } catch (Exception) { return NotFound(); }

            ViewBag.isActor = isActor;
            ViewBag.id = id;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create([Bind("Movie", "Actor", "Comment", "Score", "UserId", "Id", "isActor")]CreateRatingVM vm)
        {
            string testOne = vm.Id;
            bool testTwo = vm.isActor;

            //if (vm.Actor== null && vm.Movie == null) { return NotFound(); }
            //if (vm.Actor != null && vm.Movie != null) { return NotFound(); }
            try
            {
                User user = Context.Users.First(u => u.Id == Int32.Parse(vm.UserId));
                int id = Int32.Parse(vm.Id);
                if (vm.isActor)
                {
                    // make actor rating
                    
                    Actor actor = Context.Actors.First(a => a.Id == id );
                    Context.CreateRating(actor, user, vm.Score, vm.Comment);
                    return RedirectToAction("Details", "Actor", new { actorid = id });

                }
                else
                {
                   Movie movie = Context.Movies.First(m => m.Id == id);
                    // make movie rating
                    Context.CreateRating(movie, user, vm.Score, vm.Comment);

                    return RedirectToAction("GetMovieInfo", "Movie", new { movieid = id });
                }

            } catch (Exception)
            {
                return NotFound();
            }
            
            

        }
    }
}
