using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Models;

namespace WebStore.Controllers;

public class UserController : Controller
{
    private readonly IdentityUser db;
    
    public UserController( IdentityUser _db)
    {
        
        db = _db;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var users = await db.user.ToListAsync();
        return View(users);
    }
    
}