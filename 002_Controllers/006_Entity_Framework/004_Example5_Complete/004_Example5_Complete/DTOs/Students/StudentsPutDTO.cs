namespace _004_Example5_Complete.DTOs.Students
{
    public class StudentsPutDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly DateOnly { get; set; } = new DateOnly();
        public string? Address { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; } = "12345";
    }
}
