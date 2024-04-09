using _002_Ejercicio.Controllers;

namespace _002_Ejercicio.Services
{
    public class TeachersService : ITeachersService
    {
        public bool TeachersValidator(Teachers teacher)
        {
            if (string.IsNullOrEmpty(teacher.Name) && teacher.Email.Contains('@') && string.IsNullOrEmpty(teacher.Email) && string.IsNullOrEmpty(teacher.Level)) return true;
            return false;
        }
    }
}
