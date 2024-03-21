using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CloudIceTaskShopInventory.Data;
using CloudIceTaskShopInventory.Models;

namespace CloudIceTaskShopInventory.Controllers
{
    public class InventoriesController : Controller
    {
        private readonly CloudIceTaskShopInventoryContext _context;

        public InventoriesController(CloudIceTaskShopInventoryContext context)
        {
            _context = context;
        }

        // GET: Inventories
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Inventory.ToListAsync());
        //}
        //public async Task<IActionResult> Index(string searchString)
        //{
        //    if (_context.Inventory == null)
        //    {
        //        return Problem("Entity set 'CloudIceTaskShopInventoryContext.Inventory'  is null.");
        //    }

        //    var inventory = from m in _context.Inventory
        //                 select m;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        inventory = inventory.Where(s => s.ProductName!.Contains(searchString));
        //    }

        //    return View(await inventory.ToListAsync());
        //}
        
        public async Task<IActionResult> Index(string ProductCatogory, string searchString)
        {
            if (_context.Inventory == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> CatogoryQuery = from m in _context.Inventory
                                            orderby m.Catogory
                                            select m.Catogory;
            var product = from m in _context.Inventory
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                product = product.Where(s => s.ProductName!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(ProductCatogory))
            {
                product = product.Where(x => x.Catogory == ProductCatogory);
            }

            var productcatogoryVM = new InventoryCatogory
            {
                 catogry = new SelectList(await CatogoryQuery.Distinct().ToListAsync()),
                products = await product.ToListAsync()
            };

            return View(productcatogoryVM);
        }

        // GET: Inventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // GET: Inventories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,LastOrderedOn,Quantity,Price,Catogory")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,LastOrderedOn,Quantity,Price,Catogory")] Inventory inventory)
        {
            if (id != inventory.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory != null)
            {
                _context.Inventory.Remove(inventory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventory.Any(e => e.ProductId == id);
        }
    }
}
