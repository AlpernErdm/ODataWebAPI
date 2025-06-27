namespace ODataWebAPI.Models
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid();

        }

        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; } = default!; // Navigation property to Category
        public decimal Price { get; set; }
    }
}
