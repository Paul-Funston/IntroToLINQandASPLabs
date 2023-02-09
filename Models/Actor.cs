using System.Xml.Linq;
using IntroToLINQandASPLabs.Data;
namespace IntroToLINQandASPLabs.Models
{
    public class Actor
    {
        private int _id;
        public int Id { get { return _id; } }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length < 2 || !value.All(c => Char.IsLetter(c) || Char.IsWhiteSpace(c)))
                {
                    throw new Exception("An actors name must be at least 2 letters.");
                }
                else
                {
                    _name = value;
                }
            }
        }

        private int _totalEarned;
        public int TotalEarned { get { return _totalEarned; }  }
        public void GetEarnings()
        {
            int earnings = 0;
            foreach (Role r in _roles) 
            {
                earnings += r.Salary;
            }
            _totalEarned = earnings;
        }

        public int NumOfRoles { get { return _roles.Count; } }

        private HashSet<Role> _roles = new HashSet<Role>();
        public HashSet<Role> Roles { get { return _roles.ToHashSet(); } }

        public void AddRole(Role role)
        {
            _roles.Add(role);
            GetEarnings();
        }

        public Actor( string name)
        {
            _id = Context.GetNextId();
            Name = name;
            
        }

        
    }
    
}
