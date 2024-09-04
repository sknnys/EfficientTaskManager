using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EfficientTaskManager.ViewModels;
using EfficientTaskManager.Services;

public class AccountController : Controller
{
    private readonly SupabaseAuthService _authService;

    public AccountController(SupabaseAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
public async Task<IActionResult> Login(LoginViewModel model)
{
    var userId = await _authService.SignInAsync(model.Email, model.Password);
    if (!string.IsNullOrEmpty(userId))
    {
        // Login successful, redirect to home
        return RedirectToAction("Index", "Home");
    }

    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
    return View(model);
}

[HttpPost]
public async Task<IActionResult> Logout()
{
    await _authService.SignOutAsync();
    return RedirectToAction("Index", "Home");
}

}
