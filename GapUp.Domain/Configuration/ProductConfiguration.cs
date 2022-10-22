using GapUp.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GapUp.Domain.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData
            (
            new Product
            {
                Id = new Guid("{64AD470E-632A-4AB4-9BC8-CAD48CC04091}"),
                Name = "Uzbek Guys",
                PhotoUrl = "~images/uzbek.jpg",
                Description = "Size: All Type: Cotton",
                Price = 200000,
                Type = "Hoodie"
            },
            new Product
            {
                Id = new Guid("{B6477EAD-AEE7-43E1-BC8A-A4FA69313CD3}"),
                Name = "Home",
                PhotoUrl = "~images/home.jpg",
                Description = "Size: All Type: Cotton",
                Price = 200000,
                Type = "Hoodie"
            },
            new Product
            {
                Id = new Guid("{F2E1D94D-5EC6-4C49-956C-187400AAE12B}"),
                Name = "Uzbek Guys",
                PhotoUrl = "~images/uzbeksh.jpg",
                Description = "Size: All Type: Cotton",
                Price = 110000,
                Type = "Shirt"
            },
            new Product
            {
                Id = new Guid("{341EB32A-079B-4900-A81E-B3F375181934}"),
                Name = "Sunnah Hoodie",
                PhotoUrl = "~images/sunnah.jpg",
                Description = "Size: All Type: Cotton",
                Price = 200000,
                Type = "Hoodie"
            },
            new Product
            {
                Id = new Guid("{04F72447-4FD6-47F0-8D15-86B925094F49}"),
                Name = "Sunnah Cap",
                PhotoUrl = "~images/sunnahc.jpg",
                Description = "Size: All Type: Cotton",
                Price = 50000,
                Type = "Cap"
            },
            new Product
            {
                Id = new Guid("{FFBEBC88-9654-4933-A8DC-560337B8C0D7}"),
                Name = "Java != Javascript Hoodie",
                PhotoUrl = "~images/prog.jpg",
                Description = "Size: All Type: Cotton",
                Price = 200000,
                Type = "Hoodie"
            }
            );
        }
    }
}
