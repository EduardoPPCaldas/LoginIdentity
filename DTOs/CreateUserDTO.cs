using System.ComponentModel.DataAnnotations;

namespace LoginSimulator.DTOs;

public class CreateUserDTO
{
    [Required]
    public required string Username { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Required]
    [Compare("Password")]
    public required string RePassword { get; set; }
}
