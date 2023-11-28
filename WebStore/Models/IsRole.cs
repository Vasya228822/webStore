using System.ComponentModel.DataAnnotations;

namespace WebStore.Models;

public class IsRole
{
    [Key]
    public int id { get; set; }
    
    public bool role { get; set; }
}