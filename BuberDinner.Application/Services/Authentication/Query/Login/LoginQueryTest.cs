using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Errors;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Query.Login
{
    public class LoginQueryTest : ILoginQuery
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public LoginQueryTest(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            // Validate user exists
            if(_userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // Validate password is correct
            if(user.Password != password)
            {
                return new[] { Errors.Authentication.InvalidCredentials };
            }

            // Generate JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token
            );
        }
    }
}