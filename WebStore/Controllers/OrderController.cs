using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Models;

namespace WebStore.Controllers;

public class OrderController : Controller
{
    
    private readonly ApplicationDbContext _db;

    public OrderController( ApplicationDbContext db)
    {
        
        _db = db;
    }
    // GET
    public async Task<IActionResult> Index(CancellationToken token)
    {
        
        var orders = await _db.order.ToListAsync(token);
        return View(orders);
    }
    
    // GET: Order/Details/5
    public async Task<IActionResult> Details(int? id,CancellationToken token)
    {
        if (id == null)
        {
            return NotFound();
        }

        var order = await _db.order.FirstOrDefaultAsync(o => o.Id == id,token);
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
    public async Task<IActionResult> Create(Order order,CancellationToken token)
    {
        if (ModelState.IsValid)
        {
            
            order.OrderTime = DateTime.UtcNow;

            _db.Add(order);
            await _db.SaveChangesAsync(token);
            return RedirectToAction("Index");
        }

        return View(order);
    }
    
    // GET: Order/Edit/5
    public async Task<IActionResult> Edit(int? id, CancellationToken token)
    {
        if (id == null)
        {
            return NotFound();
        }

        var order = await _db.order.FindAsync(new object[] { id }, token);
        if (order == null)
        {
            return NotFound();
        }
        return View(order);
    }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Order order,CancellationToken token)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(order);
                await _db.SaveChangesAsync(token);
                return RedirectToAction("Index");
            }

            return View(order);
        }

        

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id,CancellationToken token)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _db.order.FirstOrDefaultAsync(m => m.Id == id,token);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,CancellationToken token)
        {
            var order = await _db.order.FindAsync(id);
            _db.order.Remove(order);
            await _db.SaveChangesAsync(token);
            return RedirectToAction(nameof(Index));
        }
        
        
}