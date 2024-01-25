namespace Restaurant.Services.ProductAPI.Models.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripton { get; set; }
        public double Price { get; set; }
        public string CategoryName { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }

    }
}
