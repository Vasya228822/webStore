using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers;

public class ProductController : Controller
{
    private readonly IdentityUser db;
    
    public ProductController( IdentityUser _db)
    {
        
        db = _db;
    }
    // GET
    public IActionResult Index()
    {
        var products = db.product.ToList();
        
        return View(products);
    }
}