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

        private string? _comment;
        public string Comment { get { return _comment; } }
        


        public Rating ( User user, int score, string? comment)
        {
            _id = Context.GetNextId();
            _user = user;

            if(comment != null)
            {
                _comment = comment;
            }

            if (score < 0 || score > 10)
            {
                throw new Exception("The Rating must be a number between 0 and 10.");
            } else
            {
                _score = score;
            }
        }

        public Rating()
        {

        }

        public class MovieRating : Rating
        {
            private Movie _movie;
            public Movie Movie { get { return _movie; } }
            public MovieRating(Movie movie, User user, int score, string? comment) : base( user, score, comment)
            {
                _movie = movie;
            }
        }

        public class ActorRating : Rating
        {
            private Actor _actor;
            public Actor Actor { get { return _actor;} }

            public ActorRating(Actor actor, User user, int score, string? comment) : base(user, score, comment)
            {
                _actor = actor;
            }
        }
    }
}
