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

    public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken token)
    {
        return await _db.Orders.ToListAsync(token);
    }

    public async Task<Order> GetAsync(int id,CancellationToken token)
    {
        return await _db.Orders.FindAsync(id,token);
    }
    public async Task AddAsync(Order order, CancellationToken token)
    {
        _db.Orders.Add(order);
        await _db.SaveChangesAsync(token);
    }

    public async Task UpdateAsync(Order order, CancellationToken token)
    {
        _db.Orders.Update(order);
        await _db.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(Order order, CancellationToken token)
    {
        _db.Orders.Remove(order);
        await _db.SaveChangesAsync(token);
    }
}