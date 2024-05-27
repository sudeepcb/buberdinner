using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Query
{
    public interface ILoginQuery
    {
        ErrorOr<AuthenticationResult> Login(string email, string password);
    }
}