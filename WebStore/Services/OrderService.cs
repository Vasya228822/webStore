using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebStore.Models;

namespace WebStore.Services;

public class OrderService
{
    private readonly ApplicationDbContext _db;
    
    public OrderService( ApplicationDbContext db)
    {
        
        _db = db;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync(CancellationToken token)
    {
        return await _db.order.ToListAsync(token);
    }

    public async Task<Order> GetOrderAsync(int id,CancellationToken token)
    {
        return await _db.order.FindAsync(id,token);
    }
    public async Task AddOrderAsync(Order order, CancellationToken token)
    {
        _db.order.Add(order);
        await _db.SaveChangesAsync(token);
    }

    public async Task UpdateOrderAsync(Order order, CancellationToken token)
    {
        _db.order.Update(order);
        await _db.SaveChangesAsync(token);
    }

    public async Task DeleteOrderAsync(Order order, CancellationToken token)
    {
        _db.order.Remove(order);
        await _db.SaveChangesAsync(token);
    }
}