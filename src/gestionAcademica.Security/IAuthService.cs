using gestionAcademica.Security.Models;

namespace gestionAcademica.Security;

public interface IAuthService
{
    Task<object?> LoginAsync(LoginRequest request);
    Task<object?> LogoutAsync(string userId);
}
