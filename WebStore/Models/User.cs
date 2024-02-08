using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Login { get; set; }
    
    public string Password { get; set; }
    
    public string NumberPhone { get; set; }
    
    [ForeignKey("IsRole")] 
    public int RoleId { get; set; }

    public Role Role;
}