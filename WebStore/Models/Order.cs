using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    
    public string Address { get; set; }
    
    public string House { get; set; }
    
    public string Apartment { get; set; }
    
    public double TotalCost { get; set; }
    
    public DateTime OrderTime { get; set; } = DateTime.UtcNow;
    
    [ForeignKey("User")] 
    public int UserId { get; set; }

    public User User;

}