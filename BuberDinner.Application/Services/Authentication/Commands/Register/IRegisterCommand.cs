using BuberDinner.Application.Common.Errors;
using ErrorOr;
using FluentResults;
using OneOf;

namespace BuberDinner.Application.Services.Authentication.Commands.Register
{
    public interface IRegisterCommand
    {
        ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);

    }
}