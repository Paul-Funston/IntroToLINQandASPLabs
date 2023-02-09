using IntroToLINQandASPLabs.Data;
namespace IntroToLINQandASPLabs.Models
{
    public class Movie
    {
        

        private int _id;
        public int Id { get { return _id; } }

        private readonly DateTime _releaseDate;
        public DateTime ReleaseDate { get { return _releaseDate; } }

        private string _title;
        public string Title { get { return _title; } }

        private string _genre;
        public string Genre { get { return _genre; } }

        private readonly int _budget;
        public int Budget { get { return _budget; } }

        private HashSet<Role> _roles;
        public void AddRole(Role role)
        {
            _roles.Add(role);
        }
        private HashSet<Rating> _rating;

        public void AddRating(Rating rating)
        {
            _rating.Add(rating);
        }
       



        public Movie( string title, string genre, DateTime releaseDate)
        {
            _id = Context.GetNextId();

            _genre = genre;

            if (title.Length > 0)
            {
                _title = title;
            } else
            {
                throw new ArgumentException("A movies title must be at least 1 character long.");
            }

            _releaseDate = releaseDate;

        }

        
    }
}
