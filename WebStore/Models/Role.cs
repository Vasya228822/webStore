using System.ComponentModel.DataAnnotations;

namespace WebStore.Models;

public class Role
{
    [Key]
    public int Id { get; set; }
    
    public bool role { get; set; }
}