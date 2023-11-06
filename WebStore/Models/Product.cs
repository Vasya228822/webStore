using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models;

public class Product
{
    [Key]
    public int id { get; set; }
    
    public float price { get; set; }
    
    public int amount { get; set; }
    
    public string name { get; set; }
    
    public string description { get; set; }

    [ForeignKey("Category")] 
    public int categoryid { get; set; }

    public Category Category;
}