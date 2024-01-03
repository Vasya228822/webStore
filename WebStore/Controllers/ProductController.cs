using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _db;
    
    public ProductController( ApplicationDbContext db)
    {
        
        _db = db;
    }
    // GET
    public IActionResult Index()
    {
        var products = _db.product.ToList();
        
        return View(products);
    }
}