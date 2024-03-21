using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CloudIceTaskShopInventory.Models;

public class InventoryCatogory
{
    public List<Inventory>? products { get; set; }
    public SelectList? catogry { get; set; }
    public string? ProductCatogory { get; set; }
    public string? SearchString { get; set; }

}
