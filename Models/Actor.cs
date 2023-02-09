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

        public int GetHighestPay()
        {
            return _roles.Max(r => r.Salary);
        }

        private HashSet<Role> _roles = new HashSet<Role>();
        public HashSet<Role> Roles { get { return _roles.ToHashSet(); } }

        public void AddRole(Role role)
        {
            _roles.Add(role);
        }

        public Actor( string name)
        {
            _id = Context.GetNextId();
            Name = name;
            
        }

        
    }
    
}
