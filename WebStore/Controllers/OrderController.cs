using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Models;

namespace WebStore.Controllers;

public class OrderController : Controller
{
    
    private readonly IdentityUser db;
    
    public OrderController( IdentityUser _db)
    {
        
        db = _db;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var orders = await db.order.ToListAsync();
        return View(orders);
    }
    
    // GET: Order/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var order = await db.order.FirstOrDefaultAsync(o => o.id == id);
        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }
    
    // GET: Order/Create
    public IActionResult Create()
    {
        return View();
    }
    
    // POST: Order/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Order order)
    {
        if (ModelState.IsValid)
        {
            
            order.orderTime = DateTime.UtcNow;

            db.Add(order);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        return View(order);
    }
    
    // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await db.order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            if (id != order.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                db.Update(order);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await db.order.FirstOrDefaultAsync(m => m.id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await db.order.FindAsync(id);
            db.order.Remove(order);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        
}