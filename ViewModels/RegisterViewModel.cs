using System.ComponentModel.DataAnnotations;

namespace EfficientTaskManager.ViewModels
{
    public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }

    [Required]
    [StringLength(256)]
    public string UserName { get; set; } // Adicionado UserName
}

}
