using IntroToLINQandASPLabs.Data;
namespace IntroToLINQandASPLabs.Models
{
    public class User
    {
        private int _id;
        public int Id { get { return _id; } }

        private string _name;
        public string Name { get { return _name;} }

        private HashSet<Rating> _ratings = new HashSet<Rating>();

        public void AddRating(Rating rating)
        {
            _ratings.Add(rating);
        }
        

        public User( string name)
        {
            _id = Context.GetNextId();
            _name = name;
        }
    }
}
