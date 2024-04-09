using _000_Fundamentals.Models;

namespace _000_Fundamentals.Constants
{
    public class UserConstants
    {
        public static List<Users> Users = new List<Users>()
        {
            new Users() {UserName = "juanpacortez", Password = "admin12345", Rol="administrador", EmailAddress="juanpacortez@correo.com", FirstName="Juan", LastName="Cortez"},
            new Users() {UserName = "felicortez", Password = "admin12345", Rol="vendedor", EmailAddress="felipecortez@correo.com", FirstName="Felipe", LastName="Cortez"},
            new Users() {UserName = "ximemosquera", Password = "admin12345", Rol="administrador", EmailAddress="ximena@correo.com", FirstName="Ximena", LastName="Mosquera"}
        };
    }
}
