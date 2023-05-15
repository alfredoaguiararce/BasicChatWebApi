using System.ComponentModel.DataAnnotations;

public class UserCreateDto
{
    [MaxLength(50)]
    [Required]
    public string Username { get; set; }
    [MaxLength(50)]
    [Required]
    public string Password { get; set; }
    [MaxLength(50)]
    [EmailAddress]
    [Required]
    public string Email { get; set; }
}
