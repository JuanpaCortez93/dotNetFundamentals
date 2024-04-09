namespace _004_Example5_Complete.DTOs.Students
{
    public class StudentsGetDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly DateOnly { get; set; } = new DateOnly();
        public string? Address { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
    }
}
