using System.ComponentModel.DataAnnotations;

namespace WebStore.Models;

public class IsRole
{
    [Key]
    public int Id { get; set; }
    
    public bool Role { get; set; }
}