using _001_Basics.Controllers;

namespace _001_Basics.Services
{
    public class PeopleService2 : IPeopleService
    {
        public bool Validate (People people)
        {
            if(string.IsNullOrEmpty(people.Name) || people.Name.Length < 3) return false;
            return true;
        }
    }
}
