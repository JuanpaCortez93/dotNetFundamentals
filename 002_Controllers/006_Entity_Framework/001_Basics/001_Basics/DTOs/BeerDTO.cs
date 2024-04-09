namespace _001_Basics.DTOs
{
    public class BeerDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? BrandId { get; set; }
        public decimal Alcohol { get; set; }
    }
}
