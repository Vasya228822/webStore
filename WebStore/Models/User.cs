using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models;

public class User
{
    [Key]
    public int id { get; set; }
    
    public string name { get; set; }
    
    public string login { get; set; }
    
    public string password { get; set; }
    
    public string numberPhone { get; set; }
    
    [ForeignKey("IsRole")] 
    public int roleid { get; set; }

    public IsRole Isrole;
}