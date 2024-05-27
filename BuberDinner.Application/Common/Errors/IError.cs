using System.Net;

namespace BuberDinner.Application.Common.Errors
{
    public interface IErrorOneOf
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage { get; }
    }
}