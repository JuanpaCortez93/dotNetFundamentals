using _001_Basics.Controllers;

namespace _001_Basics.Services
{
    public class PeopleService : IPeopleService
    {
        public bool Validate (People people)
        {
            if(string.IsNullOrEmpty(people.Name) || people.Name.Length > 100) return false;
            return true;
        }
    }
}
