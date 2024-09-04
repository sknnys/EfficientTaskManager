using System.Threading.Tasks;
public class SupabaseAuthService
{
    // Implementação fictícia. Substitua pela lógica real.
    public Task<string> SignInAsync(string email, string password)
    {
        // Lógica de autenticação fictícia
        return Task.FromResult("userId");
    }

    public Task SignOutAsync()
    {
        // Lógica de logout fictícia
        return Task.CompletedTask;
    }
}
