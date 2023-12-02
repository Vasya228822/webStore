using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models;

public class Order
{
    [Key]
    public int id { get; set; }
    
    public string address { get; set; }
    
    public string house { get; set; }
    
    public string apartment { get; set; }
    
    public double totalCost { get; set; }
    
    public DateTime orderTime { get; set; } = DateTime.UtcNow;
    
    [ForeignKey("User")] 
    public int userid { get; set; }

    public User User;

}