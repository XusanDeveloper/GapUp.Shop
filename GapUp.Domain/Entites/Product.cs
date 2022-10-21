using GapUp.Services.DTO_s;

namespace GapUp.Domain.Entites
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string type { get; set; }

        public static explicit operator Product(ProductViewModel v)
        {
            return new Product
            {
                Name = v.Name,
                PhotoUrl = v.PhotoUrl,
                Description = v.Description,
                Price = v.Price,
                type = v.type
            };
        }
        public static explicit operator ProductViewModel(Product v)
        {
            return new ProductViewModel
            {
                Name = v.Name,
                PhotoUrl = v.PhotoUrl,
                Description = v.Description,
                Price = v.Price,
                type = v.type
            };
        }
    }
}
