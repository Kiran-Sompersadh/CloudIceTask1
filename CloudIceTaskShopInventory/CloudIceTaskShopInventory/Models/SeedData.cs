using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CloudIceTaskShopInventory.Data;
using System;
using System.Linq;


namespace CloudIceTaskShopInventory.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new CloudIceTaskShopInventoryContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<CloudIceTaskShopInventoryContext>>()))
        {
            // Look for any Products.
            if (context.Inventory.Any())
            {
                return;   // DB has been seeded
            }
            context.Inventory.AddRange(
                new Inventory
                {
                    ProductName = "Sumlight Liquid",
                    LastOrderedOn = DateTime.Parse("2022-2-12"),
                    Quantity = 5,
                    Price = 28.99M,
                    Catogory = "Detergent"
                },
                new Inventory
                {
                    ProductName = "Clover Milk",
                    LastOrderedOn = DateTime.Parse("2022-2-12"),
                    Quantity = 5,
                    Price = 19.99M,
                    Catogory = "Dairy"
                },
                new Inventory
                {
                    ProductName = "corn flakes",
                    LastOrderedOn = DateTime.Parse("2022-2-12"),
                    Quantity = 5,
                    Price = 12.99M,
                    Catogory = "cereal"
                }
            );
            context.SaveChanges();
        }
    }
}
