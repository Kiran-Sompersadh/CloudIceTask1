using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CloudIceTaskShopInventory.Models;

namespace CloudIceTaskShopInventory.Data
{
    public class CloudIceTaskShopInventoryContext : DbContext
    {
        public CloudIceTaskShopInventoryContext (DbContextOptions<CloudIceTaskShopInventoryContext> options)
            : base(options)
        {
        }

        public DbSet<CloudIceTaskShopInventory.Models.Inventory> Inventory { get; set; } = default!;
    }
}
