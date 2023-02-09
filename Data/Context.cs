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
        public static Movie CreateMovie(string title, string genre,  DateTime releaseDate, int budget)
        {
            Movie newMovie = new Movie(title, genre, releaseDate, budget);
            Movies.Add(newMovie);
            return newMovie;
        }

        public static Actor CreateActor(string name)
        {
            Actor newActor = new Actor(name);
            Actors.Add(newActor);
            return newActor;
        }

        public static User CreateUser(string name)
        {
            User newUser = new User(name);
            Users.Add(newUser);
            return newUser;
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
            Movie movieOne = CreateMovie("test", Genres.Comedy.ToString(), new DateTime(2015, 1, 1), 50);
            Movie movieTwo = CreateMovie("AnotherMovie", Genres.Romance.ToString(), new DateTime(1999, 1, 1), 100);
            Movie movieThree = CreateMovie("The Best Movie", Genres.Drama.ToString(), new DateTime(1895, 1, 1), 150);
            Movie movieFour = CreateMovie("Scary Movie", Genres.Horror.ToString(), new DateTime(1995, 1, 1), 500);
            Movie movieFive = CreateMovie("Space", Genres.Horror.ToString(), new DateTime(2001, 5, 5), 1);

            Actor actorOne = CreateActor("Tim");
            Actor actorTwo = CreateActor("Jordan");
            Actor actorThree = CreateActor("Amy");
            Actor actorFour = CreateActor("Celina");

            Role roleOne = CreateRole(movieOne, actorOne, "Extra 1", 50);
            Role roleTwo = CreateRole(movieTwo, actorTwo, "Director", 150);
            Role roleThree = CreateRole(movieThree, actorOne, "Lead Guy", 200);
            Role roleFour = CreateRole(movieFour, actorThree, "Villain", 100);
            Role roleFive = CreateRole(movieFive, actorFour,"Comedic Relief", 20);

            User userOne = CreateUser("Greg");
            User userTwo = CreateUser("Spence");
            User userThree = CreateUser("Jenny");

            Rating ratingOne = CreateRating(movieOne, userOne, 5);
            Rating ratingTwo = CreateRating(movieOne, userTwo, 8);
            Rating ratingThree = CreateRating(movieOne, userThree, 9);
            Rating ratingFour = CreateRating(movieTwo, userTwo, 1);
            Rating ratingFive = CreateRating(movieTwo, userThree, 10);
            Rating ratingSix = CreateRating(movieThree, userOne, 6);
            Rating ratingSeven = CreateRating(movieFour, userOne, 3);
            Rating ratingEight = CreateRating(movieFive, userOne, 6);
            Rating ratingNine = CreateRating(movieFive, userThree, 2);

        }

        static Context()
        {
            _seedMethod();
        }
    }

}
