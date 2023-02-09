using Microsoft.AspNetCore.Mvc;
using IntroToLINQandASPLabs.Data;
using IntroToLINQandASPLabs.Models;

namespace IntroToLINQandASPLabs.Controllers
{
    public class ActorController : Controller
    {
        public IActionResult Index()
        {
            return View(Context.Actors);
        }

        public IActionResult HighestPaidActors()
        {
            HashSet<Actor> orderedActors = Context.Actors.OrderByDescending(a => a.TotalEarned).ToHashSet();
            return View("Index", orderedActors);
        }

        public IActionResult MostRoles()
        {
            HashSet<Actor> orderedActors = Context.Actors.OrderByDescending(a => a.NumOfRoles).ToHashSet();
            return View("Index", orderedActors);
        }

    }
}
