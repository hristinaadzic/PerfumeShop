using Microsoft.AspNetCore.Mvc;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain;
using PerfumeShop.Implementation;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfumeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {
        private Context _context;
        public InitialDataController(Context context)
        {
            _context = context;
        }

        // POST api/<InitialDataController>
        [HttpPost]
        public IActionResult Post()
        {

            if (_context.Categories.Any())
            {
                return Conflict();
            }

            var categories = new List<Category>
            {
                new Category { Name = "Floral"},
                new Category { Name = "Citrus"},
                new Category { Name = "Fresh"},
                new Category { Name = "Woody"}
            };

            var brands = new List<Brand>
            {
                    new Brand { Name = "Tom Ford"},
                    new Brand { Name = "Armani"},
                    new Brand { Name = "Dior"},
                    new Brand { Name = "Gucci"},
                    new Brand { Name = "Chanel"},
            };

            var genders = new List<Gender>
            {
                new Gender { GenderName = "Male"},
                new Gender { GenderName = "Female"}
            };

            var volumes = new List<Volume>
            {
                 new Volume { VolumeInMillilitres = 75},
                 new Volume { VolumeInMillilitres = 125},
                 new Volume { VolumeInMillilitres = 175}
            };

            var products = new List<Product>
            {
                 new Product {
                     Name = "Acqua di Gio",
                     ImagePath = "pic1.jpg",
                     Description = "",
                     Brand = brands.ElementAt(1),
                     Gender = genders.ElementAt(0)
                 },
                 new Product {
                     Name = "Si",
                     ImagePath = "pic2.jpg",
                     Description = "The elegance of Freesia and the exquisite honey hues of Rose De Mai absolute make this perfume truly distinctive.",
                     Brand = brands.ElementAt(1),
                     Gender = genders.ElementAt(1)
                 },
                 new Product {
                     Name = "Sauvage",
                     ImagePath = "pic3.jpg",
                     Description = "Discover or rediscover the legendary signature scent of Sauvage , fresh and powerful at once.",
                     Brand = brands.ElementAt(2),
                     Gender = genders.ElementAt(0)
                 },
                 new Product {
                     Name = "CHANEL CHANCE EAU TENDRE",
                     ImagePath = "pic4.jpg",
                     Description = "A delicate presence, an intensely feminine and enveloping trail.",
                     Brand = brands.ElementAt(4),
                     Gender = genders.ElementAt(0)
                 },
                 new Product {
                     Name = "BLEU DE CHANEL",
                     ImagePath = "pic5.jpg",
                     Description = "A tribute to masculine freedom in an aromatic-woody fragrance with a captivating trail.",
                     Brand = brands.ElementAt(4),
                     Gender = genders.ElementAt(1)
                 },
                 new Product {
                     Name = "Costa Azzurra",
                     ImagePath = "pic6.jpg",
                     Description = "Perfume breathes an air of freshness through crisp Italian lemon while the dense coastal forest is felt with magnified oakwood extract and cypress",
                     Brand = brands.ElementAt(0),
                     Gender = genders.ElementAt(1)
                 }
            };

            var productCategories = new List<ProductCategory>()
            {
                new ProductCategory
                {
                    Product = products.ElementAt(0),
                    Category = categories.ElementAt(0)
                },
                new ProductCategory
                {
                    Product = products.ElementAt(0),
                    Category = categories.ElementAt(1)
                },new ProductCategory
                {
                    Product = products.ElementAt(1),
                    Category = categories.ElementAt(1)
                },
                new ProductCategory
                {
                    Product = products.ElementAt(1),
                    Category = categories.ElementAt(2)
                },
                new ProductCategory
                {
                    Product = products.ElementAt(2),
                    Category = categories.ElementAt(2)
                }

            };

            var productVolumes = new List<ProductVolume>
            {
                new ProductVolume
                {
                    Product = products.ElementAt(0),
                    Volume = volumes.ElementAt(0)
                },
                new ProductVolume
                {
                    Product = products.ElementAt(1),
                    Volume = volumes.ElementAt(0)
                },
                new ProductVolume
                {
                    Product = products.ElementAt(1),
                    Volume = volumes.ElementAt(2)
                },
                new ProductVolume
                {
                    Product = products.ElementAt(2),
                    Volume = volumes.ElementAt(0)
                },
                new ProductVolume
                {
                    Product = products.ElementAt(2),
                    Volume = volumes.ElementAt(2)
                },
                new ProductVolume
                {
                    Product = products.ElementAt(2),
                    Volume = volumes.ElementAt(1)
                },
                new ProductVolume
                {
                    Product = products.ElementAt(5),
                    Volume = volumes.ElementAt(2)
                },
                new ProductVolume
                {
                    Product = products.ElementAt(4),
                    Volume = volumes.ElementAt(0)
                },
                new ProductVolume
                {
                    Product = products.ElementAt(4),
                    Volume = volumes.ElementAt(1)
                }
            };

            var prices = new List<Price>
            {
                new Price
                {
                    ProductVolume = productVolumes.ElementAt(0),
                    PriceValue = 65
                },
                new Price
                {
                    ProductVolume = productVolumes.ElementAt(1),
                    PriceValue = 85
                },
                new Price
                {
                    ProductVolume = productVolumes.ElementAt(2),
                    PriceValue = 55
                },
                new Price
                {
                    ProductVolume = productVolumes.ElementAt(3),
                    PriceValue = 120
                },
                new Price
                {
                    ProductVolume = productVolumes.ElementAt(4),
                    PriceValue = 95
                },
                new Price
                {
                    ProductVolume = productVolumes.ElementAt(5),
                    PriceValue = 130
                },
                new Price
                {
                    ProductVolume = productVolumes.ElementAt(6),
                    PriceValue = 150
                },
                new Price
                {
                    ProductVolume = productVolumes.ElementAt(7),
                    PriceValue = 75
                },
                new Price
                {
                    ProductVolume = productVolumes.ElementAt(8),
                    PriceValue = 110
                }
            };

            var roles = new List<Role>
            {
                new Role{ Name = "admin"},
                new Role{ Name = "user"}
            };

            var users = new List<User>
            {
                new User
                {
                    FirstName = "Pera",
                    LastName = "Peric",
                    Email = "pera@gmail.com",
                    Password = "pera123",
                    Address = "",
                    Role = roles.ElementAt(0)
                },
                new User
                {
                    FirstName = "Mika",
                    LastName = "Mikic",
                    Email = "mika@gmail.com",
                    Password = "mika123",
                    Address = "Cara Dusana 12",
                    Role = roles.ElementAt(1)
                }
            };

            var userUseCases = new List<UserUseCase>();
            for(int i = 1; i<28; i++)
            {
                userUseCases.Add(new UserUseCase
                {
                    User = users.ElementAt(0),
                    UseCaseId = i
                });
            }

            var orders = new List<Order>
            {
                new Order
                {
                    User = users.ElementAt(1),
                    Total = 185
                }
            };

            var orderLines = new List<OrderLine>
            {
                new OrderLine
                {
                    ProductName = "Sauvage",
                    Price = 85,
                    Order = orders.ElementAt(0),
                    ProductVolume = productVolumes.ElementAt(7),
                    Quantity = 1
                },
                new OrderLine
                {
                    ProductName = "Si",
                    Price = 100,
                    Order = orders.ElementAt(0),
                    ProductVolume = productVolumes.ElementAt(8),
                    Quantity = 1
                }
            };

            _context.Categories.AddRange(categories);
            _context.Brands.AddRange(brands);
            _context.Genders.AddRange(genders);
            _context.Products.AddRange(products);
            _context.ProductCategories.AddRange(productCategories);
            _context.Volumes.AddRange(volumes);
            _context.ProductVolumes.AddRange(productVolumes);
            _context.Prices.AddRange(prices);    
            _context.Roles.AddRange(roles);
            _context.Users.AddRange(users);
            _context.Orders.AddRange(orders);    
            _context.OrderLines.AddRange(orderLines);

            _context.SaveChanges();

            return StatusCode(201);
        }

      
    }
}
