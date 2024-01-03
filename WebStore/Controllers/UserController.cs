using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Models;

namespace WebStore.Controllers;

public class UserController : Controller
{
    private readonly ApplicationDbContext _db;
    
    public UserController( ApplicationDbContext db)
    {
        
        _db = db;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var users = await _db.user.ToListAsync();
        return View(users);
    }
    
}