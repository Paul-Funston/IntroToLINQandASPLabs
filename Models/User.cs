using IntroToLINQandASPLabs.Data;
namespace IntroToLINQandASPLabs.Models
{
    public class User
    {
        private int _id;
        public int Id { get { return _id; } }

        private string _name;
        public string Name { 
            get { return _name;}
            set
            {
                if (value.Length > 2 && value.Length <= 30)
                {
                    _name = value;
                } else
                {
                    throw new Exception("Username must be three or more characters an cannot exceed 30.");
                }
            }
        }

        private HashSet<Rating> _ratings = new HashSet<Rating>();

        public void AddRating(Rating rating)
        {
            _ratings.Add(rating);
        }
        

        public User( string name)
        {
            _id = Context.GetNextId();
            Name = name;
        }

        public User()
        {
            _id= Context.GetNextId();

        }
    }
}
