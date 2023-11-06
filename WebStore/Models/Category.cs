using System.ComponentModel.DataAnnotations;

namespace WebStore.Models;

public class Category
{
    [Key]
    public int id { get; set; }

    public string name { get; set; }
}