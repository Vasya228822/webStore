using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Dto;
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
    public ViewResult Index()
    {
        var users = from b in _db.Users 
            select new UserDto()
            {
                id = b.Id,
                name = b.Name,
                numberPhone = b.NumberPhone
            };
        return View(users);
    }
    
}