namespace server.Entities
{
    public class Product: AuditBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public double AverageRating { get; set; }
        public int TotalReviews { get; set; }
        public bool InStock { get; set; }
        public bool InFeatured { get; set; } = false;
        public Category Category { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<ProductReview> ProductReviews { get; set; }

    }
}
