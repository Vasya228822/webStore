using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.Services;
using System.Threading;

namespace WebStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: Order/Index
        public async Task<IActionResult> Index(CancellationToken token)
        {
            var orders = await _orderService.GetAllOrdersAsync(token);
            return View(orders.ToList());
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int id, CancellationToken token)
        {
            var order = await _orderService.GetOrderAsync(id, token);
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
        public async Task<IActionResult> Create(Order order, CancellationToken token)
        {
            if (ModelState.IsValid)
            {
                await _orderService.AddOrderAsync(order, token);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int id, CancellationToken token)
        {
            var order = await _orderService.GetOrderAsync(id, token);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Order order, CancellationToken token)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _orderService.UpdateOrderAsync(order, token);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int id, CancellationToken token)
        {
            var order = await _orderService.GetOrderAsync(id, token);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Order/Delete/5
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken token)
        {
            var order = await _orderService.GetOrderAsync(id, token);
            if (order == null)
            {
                return NotFound();
            }
            await _orderService.DeleteOrderAsync(order, token);
            return RedirectToAction(nameof(Index));
        }

    }
}
