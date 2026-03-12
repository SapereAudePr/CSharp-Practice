using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Controllers
{
    //https://localhost:7234/api/passengers
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        // GET: //https://localhost:7234/api/passengers
        [HttpGet]
        public IActionResult GetAllPassengers()
        {
            string[] passengers = { "John", "Mark", "Olivia", "Manny" };

            return Ok(passengers);
        }
    }
}
