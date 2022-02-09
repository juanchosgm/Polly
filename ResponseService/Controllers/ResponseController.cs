using Microsoft.AspNetCore.Mvc;

namespace ResponseService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        // GET - api/response/3

        [HttpGet("{id:int}")]
        public ActionResult GetResponse(int id)
        {
            var random = new Random();
            var randomValue = random.Next(1, 101);
            if (randomValue >= id)
            {
                Console.WriteLine("--> Failure  - Generate a HTTP 500");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Console.WriteLine("--> Success  - Generate a HTTP 200");
            return Ok();
        }
    }
}