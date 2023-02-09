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
            HashSet<Actor> orderedActors = Context.Actors.OrderBy(a => a.GetHighestPay()).ToHashSet();
            return View(orderedActors);
        }

    }
}
