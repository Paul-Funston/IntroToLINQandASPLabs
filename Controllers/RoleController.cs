using IntroToLINQandASPLabs.Models;
using IntroToLINQandASPLabs.Models.ViewModels;
using IntroToLINQandASPLabs.Data;
using Microsoft.AspNetCore.Mvc;

namespace IntroToLINQandASPLabs.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            CreateRoleVM vm = new CreateRoleVM(Context.Movies, Context.Actors);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create([Bind("ActorId", "MovieId", "Title", "Pay")]CreateRoleVM vm)
        {
            try
            {
                Actor actor = Context.Actors.First(a => a.Id == Int32.Parse(vm.ActorId));
                Movie movie = Context.Movies.First(m => m.Id == Int32.Parse(vm.MovieId));
                Context.CreateRole(movie, actor, vm.Title, vm.Pay);
                return RedirectToAction("GetMovieInfo", "Movie", new { movieid = movie.Id });

            } catch (Exception) { return RedirectToRoute(new {controller = "Movie", action ="Index" }); }
            

            
            
        }
    }
}
