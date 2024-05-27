using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Services.Authentication.Query.Login
{
    public record LoginQuery(
            string Email,
            string Password
        ) : IRequest<ErrorOr<AuthenticationResult>>;
}