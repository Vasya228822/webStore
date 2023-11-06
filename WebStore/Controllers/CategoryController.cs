using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers;

public class CategoryController : Controller
{
    private readonly IdentityUser db;
    
    public CategoryController( IdentityUser _db)
    {
        
        db = _db;
    }
    // GET
    public IActionResult Index()
    {
        var categories = db.category.ToList();
        
        return View(categories);
    }
}