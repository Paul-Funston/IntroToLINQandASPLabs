using IntroToLINQandASPLabs.Data;

namespace IntroToLINQandASPLabs.Models
{
    public class Role
    {
        private int _id;
        public int Id { get { return _id; } }
        private Actor _actor;
        public Actor Actor { get { return _actor; } }
        private Movie _movie;
        public Movie Movie { get { return _movie; } }
        private string _title;
        public string Title { get { return _title; } }
        private int _salary;
        public int Salary { get { return _salary; } }

        public Role(int id, Actor actor, Movie movie, string title, int salary)
        {
            _id = Context.GetNextId();
            _actor = actor;
            _movie = movie;
            if (salary > 0)
            {
                _salary = salary;
            } else
            {
                throw new Exception("Salary must be greater than 0");
            }

            if (title != null)
            {
                _title = title;
            } else
            {
                throw new Exception("a title must be declared.");
            }
        }
    }
}
