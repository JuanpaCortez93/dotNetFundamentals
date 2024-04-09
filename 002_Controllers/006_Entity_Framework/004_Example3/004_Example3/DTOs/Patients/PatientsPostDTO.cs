namespace _004_Example3.DTOs.Patients
{
    public class PatientsPostDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Birthday { get; set; } = DateTime.Now;
        public string? Address { get; set; }
        public string? Telephone { get; set; }
    }
}
