using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext dbContext = new ProductShopContext();
            string JsonInput = File.ReadAllText("../../../Datasets/categories-products.json"); //Choose correct path

            string output = GetCategoriesByProductsCount(dbContext); //Change your methods here

            Console.WriteLine(output);
            
        }


        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            UserDto[]? dtos = JsonConvert.DeserializeObject<UserDto[]>(inputJson);

            if (dtos != null)
            {
                List<User> validUsers = new List<User>();

                foreach (UserDto dto in dtos)
                {
                    if (!IsValid(dto))
                        continue;


                    bool isParsed = int.TryParse(dto.Age, out int parsedAge);

                    if (!isParsed && parsedAge != 0)
                        continue;

                    User user = new User()
                    {
                        FirstName = dto.FirstName,
                        LastName = dto.LastName,
                        Age = parsedAge
                    };

                    validUsers.Add(user);

                }

                context.Users.AddRange(validUsers);
                context.SaveChanges();


                result = $"Successfully imported {validUsers.Count}";
            }

            return result;
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ProductDto[]? productsDtos = JsonConvert.DeserializeObject<ProductDto[]>(inputJson);

            if (productsDtos != null)
            {
                ICollection<Product> validProducts = new List<Product>();

                foreach (var dto in productsDtos)
                {
                    if (!IsValid(dto)) continue;

                    bool isValidPrice = decimal.TryParse(dto.Price, out decimal price);
                    bool isValidSeller = int.TryParse(dto.SellerId, out int sellerId);

                    if (!isValidPrice || !isValidSeller) continue;

                    int? buyerId = null;
                    if (dto.BuyerId != null)
                    {
                        bool isValidBuyer = int.TryParse(dto.BuyerId, out int parsedBuyerId);

                        if (!isValidBuyer) continue;

                        buyerId = parsedBuyerId;
                    }

                    Product product = new Product()
                    {
                        Name = dto.Name,
                        Price = price,
                        SellerId = sellerId,
                        BuyerId = buyerId
                    };

                    validProducts.Add(product);
                }

                context.Products.AddRange(validProducts);
                context.SaveChanges();

                result = $"Successfully imported {validProducts.Count}";
            }

            return result;
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            CategoryDto[]? categoryDtos = JsonConvert.DeserializeObject<CategoryDto[]>(inputJson);

            if (categoryDtos != null)
            {
                ICollection<Category> validCategories = new List<Category>();

                foreach (CategoryDto dto in categoryDtos)
                {
                    if (!IsValid(dto)) continue;

                    Category category = new Category()
                    {
                        Name = dto.Name
                    };
                    validCategories.Add(category);
                }

                context.Categories.AddRange(validCategories);
                context.SaveChanges();

                result = $"Successfully imported {validCategories.Count}";
            }

            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            CategoryProductDto[]? categoryProductDtos = JsonConvert.DeserializeObject<CategoryProductDto[]>(inputJson);

            if (categoryProductDtos != null)
            {
                ICollection<CategoryProduct> validCategoriesProducts = new List<CategoryProduct>();

                foreach (CategoryProductDto dto in categoryProductDtos)
                {
                    if (!IsValid(dto)) continue;

                    bool isValidCategory = int.TryParse(dto.CategoryId, out int categoryId);
                    bool isValidProduct = int.TryParse(dto.ProductId, out int productId);

                    if (!isValidCategory || !isValidProduct) continue;

                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        CategoryId = categoryId,
                        ProductId = productId,
                    };
                    validCategoriesProducts.Add(categoryProduct);
                }

                context.CategoriesProducts.AddRange(validCategoriesProducts);
                context.SaveChanges();

                result = $"Successfully imported {validCategoriesProducts.Count}";
            }


            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToArray();

            DefaultContractResolver camelCaseContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert.SerializeObject(products, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = camelCaseContractResolver
                });

            return jsonResult;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(p => new
                        {
                            p.Name,
                            p.Price,
                            BuyerFirstName = p.Buyer!.FirstName,
                            BuyerLastName = p.Buyer.LastName
                        })
                })
                .ToArray();

            DefaultContractResolver camelCaseContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert.SerializeObject(users, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = camelCaseContractResolver
                });

            return jsonResult;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Where(c => c.CategoriesProducts.Any())
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoriesProducts.Count,
                    AveragePrice = c.CategoriesProducts.Average(cp => cp.Product.Price).ToString("F2"),
                    TotalRevenue = c.CategoriesProducts.Sum(cp => cp.Product.Price).ToString("F2")
                })
                .OrderByDescending(c => c.ProductsCount)
                .ToArray();

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert.SerializeObject(categories, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = camelCaseResolver
                });

            return jsonResult;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Count(p => p.BuyerId.HasValue),
                        Products = u.ProductsSold
                                .Where(p => p.BuyerId.HasValue)
                                .Select(p => new
                                {
                                    p.Name,
                                    p.Price
                                })
                                .ToArray()
                    }
                })
                .ToArray()
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToArray();

            var usersResult = new
            {
                UsersCount = usersWithProducts.Length,
                Users = usersWithProducts
            };

            DefaultContractResolver camelCaseContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert.SerializeObject(usersResult, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = camelCaseContractResolver,
                    NullValueHandling = NullValueHandling.Ignore
                });

            return jsonResult;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }


        private static void ResetDatabase(ProductShopContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
    }
}