using GapUp.Domain.Entites.Commons;
using GapUp.Domain.Entites.Enums;
using GapUp.Services.DTO_s;

namespace GapUp.Domain.Entites
{
    public class Product : IAuditable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }


        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public ItemState State { get; set; }

        public void Create()
        {
            CreatedAt = DateTime.Now;
            State = ItemState.Created;
        }

        public void Delete()
        {
            DeletedAt = DateTime.Now;
            State = ItemState.Deleted;
        }

        public void Update()
        {
            UpdatedAt = DateTime.Now;
            State = ItemState.Updated;
        }

        public static explicit operator Product(ProductViewModel v)
        {
            return new Product
            {
                Name = v.Name,
                PhotoUrl = v.PhotoUrl,
                Description = v.Description,
                Price = v.Price,
                Type = v.type
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
                type = v.Type
            };
        }
    }
}
