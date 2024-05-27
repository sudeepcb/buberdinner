using System.Text.RegularExpressions;
using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Application.Services.Authentication.Commands;
using BuberDinner.Application.Services.Authentication.Commands.Register;
using BuberDinner.Application.Services.Authentication.Query;
using BuberDinner.Application.Services.Authentication.Query.Login;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using FluentResults;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
                        
            ErrorOr<AuthenticationResult> _authResult = await _mediator.Send(command);
            
            /*
            if(registerResult.IsSuccess)
            {
                Ok(MapAuthResult(registerResult.Value));
            }
            
            var firstError = registerResult.Errors[0];

            if(firstError is DuplicateEmailError)
            {
                return Problem(statusCode: (int) StatusCodes.Status409Conflict, title: "Email already exists.");
            }

            return Problem();
            */
        
            return _authResult.Match(
                registerResult => Ok(MapAuthResult(registerResult)),
                firstError => Problem(firstError)
            );

        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult) {

            return new AuthenticationResponse(
                Id: authResult.User.Id,
                FirstName: authResult.User.FirstName,
                LastName: authResult.User.LastName,
                Email: authResult.User.Email,
                Token: authResult.Token
            );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);

            ErrorOr<AuthenticationResult> _authResult = await _mediator.Send(query);

            return _authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
            );

        }
    }
}