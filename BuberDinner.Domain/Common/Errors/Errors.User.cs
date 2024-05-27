using System.Net;
using ErrorOr;

namespace BuberDinner.Domain.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(
                code: "User.DuplicateEmail", 
                description: "Email already exists."
                );
        }
    }
}