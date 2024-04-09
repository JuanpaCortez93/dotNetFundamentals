using _002_Ejercicio.Controllers;

namespace _002_Ejercicio.Services
{
    public class StudentsService : IStudentsService
    {
        public bool StudentsValidator(Students students)
        {
            if (string.IsNullOrEmpty(students.Name) && students.Email.Contains('@') && string.IsNullOrEmpty(students.Email) && string.IsNullOrEmpty(students.Level)) return true;
            return false;
        }
    }
}
