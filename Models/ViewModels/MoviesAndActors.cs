namespace IntroToLINQandASPLabs.Models.ViewModels
{
    public class MoviesAndActors
    {
        public string? Message;
        public HashSet<Movie> Movies { get; set;}
        public HashSet<Actor> Actors { get; set;}

        public MoviesAndActors(HashSet<Movie> movies, HashSet<Actor> actors)
        {
            Movies = movies;
            Actors = actors;
        }

        public MoviesAndActors(HashSet<Movie> movies, HashSet<Actor> actors, string message)
        {
            Movies = movies;
            Actors = actors;
            Message = message;
        }
    }
}
