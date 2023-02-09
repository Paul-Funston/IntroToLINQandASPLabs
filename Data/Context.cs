using IntroToLINQandASPLabs.Models;
using System.Data;

namespace IntroToLINQandASPLabs.Data
{
    public static class Context
    {
        public static HashSet<Movie> Movies = new HashSet<Movie>();
        public static HashSet<Actor> Actors = new HashSet<Actor>();
        public static HashSet<User> Users = new HashSet<User>();

        private static int _idCounter = 0;
        
        public static int GetNextId()
        {
            return ++_idCounter;
        }

        public enum Genres
        {
            Horror,
            Adventure,
            Comedy,
            Romance,
            Family,
            Action,
            Thriller,
            Drama,
            Documentary,
        }
        public static Movie CreateMovie(string title, string genre,  DateTime releaseDate)
        {
            Movie newMovie = new Movie(title, genre, releaseDate);
            Movies.Add(newMovie);
            return newMovie;
        }

        public static Actor CreateActor(string name)
        {
            return new Actor( name);
        }

        public static User CreateUser(string name)
        {
            return new User( name);
        }

        private static Role CreateRole(Movie movie, Actor actor, string title, int salary)
        {
            Role newRole = new Role(++_idCounter, actor, movie, title, salary);
            movie.AddRole(newRole);
            actor.AddRole(newRole);
            return newRole;
        }
        private static Rating CreateRating(Movie movie, User user, int score)
        {
            Rating newRating = new Rating( movie, user, score);
            user.AddRating(newRating);
            movie.AddRating(newRating);
            return newRating;
        }
        private static void _seedMethod()
        {
            CreateMovie("test", Genres.Comedy.ToString(), DateTime.Now);
            CreateMovie("AnotherMovie", Genres.Romance.ToString(), DateTime.Now);
        }

        static Context()
        {
            _seedMethod();
        }
    }

}
