using IntroToLINQandASPLabs.Data;

namespace IntroToLINQandASPLabs.Models
{
    public class Rating
    {

        private int _id;
        public int Id { get { return _id; } }

        private int _score;
        public int Score { get { return _score; } }

        private User _user;
        public User User { get { return _user; } }
        private Movie _movie;
        public Movie Movie { get { return _movie; } }


        public Rating ( Movie movie, User user, int score)
        {
            _id = Context.GetNextId();
            _movie = movie;
            _user = user;

            if (score < 0 || score > 10)
            {
                throw new Exception("The Rating must be a number between 0 and 10.");
            } else
            {
                _score = score;
            }
            
        }
    }
}
