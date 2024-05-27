using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace BuberDinner.Api.Controllers
{   
    [Route("[controller]")]
    public class DinnerController : ApiController
    {
        public IActionResult LastDinner()
        {
            return Ok(Array.Empty<string>());
        }
    }
}