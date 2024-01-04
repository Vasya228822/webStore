using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    
    public float Price { get; set; }
    
    public int Amount { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }

    [ForeignKey("Category")] 
    public int CategoryId { get; set; }

    public Category Category;
}