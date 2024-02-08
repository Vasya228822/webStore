using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    
    public CategoryController( ApplicationDbContext db)
    {
        
        _db = db;
    }
    // GET
    public IActionResult Index()
    {
        var categories = _db.Categories.ToList();
        
        return View(categories);
    }
}