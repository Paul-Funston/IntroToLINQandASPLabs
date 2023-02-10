using Microsoft.AspNetCore.Mvc.Rendering;
using IntroToLINQandASPLabs.Data;

namespace IntroToLINQandASPLabs.Models.ViewModels
{
    public class CreateRatingVM
    {
        public Movie? Movie { get; set; }
        public Actor? Actor { get; set; }
        public string? Id { get; set; }
        public bool isActor { get; set; }

        public string UserId { get; set; }
        public string? Comment { get; set; }
        public int Score { get; set; }
        public List<SelectListItem> Users { get; } = new List<SelectListItem>();

        private List<SelectListItem>  AllUsersToSelectList(HashSet<Rating> ratings)
        {
            List<SelectListItem> users = new List<SelectListItem>();
            foreach(User user in Context.Users)
            {
                if (!ratings.Any(r => r.User == user))
                {
                    users.Add(new SelectListItem(user.Name, user.Id.ToString()));
                }
            }

            return users;
        }
        public CreateRatingVM(Movie movie)
        {
            Movie = movie;
            Users = AllUsersToSelectList(movie.Ratings);
            
            
        }

        public CreateRatingVM(Actor actor)
        {
            Actor = actor;
            Users = AllUsersToSelectList(actor.Ratings);
            
        }
        public CreateRatingVM() { }

    }
}
