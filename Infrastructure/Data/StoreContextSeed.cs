using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory logger)
        {
            try
            {
                if (!context.ProductBrands.Any())
                { 
                    var brandsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    if (brands == null) return;
                    context.ProductBrands.AddRange(brands);
                    await context.SaveChangesAsync();
                }
                 
                if (!context.ProductTypes.Any())
                {
                    var typesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    if (types == null) return;
                    context.ProductTypes.AddRange(types);
                    await context.SaveChangesAsync();
                }
                 
                if (!context.Products.Any())
                {
                    var productsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    if (products == null) return;
                    context.Products.AddRange(products);
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                var log = logger.CreateLogger<StoreContextSeed>();
                log.LogError(ex.Message, "An error occure");

            }

        }
    }
}
