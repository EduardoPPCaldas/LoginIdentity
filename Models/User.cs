using Microsoft.AspNetCore.Identity;

namespace LoginSimulator.Models;

public class User : IdentityUser
{
    public User(): base()
    {
        
    }
    public DateTime BirthDate { get; set; }
}
