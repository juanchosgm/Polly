using Microsoft.AspNetCore.Mvc;
using RequestService.Policies;

namespace RequestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RequestController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        // GET - api/request
        [HttpGet]
        public async Task<ActionResult> MakeRequest()
        {
            var client = httpClientFactory.CreateClient("Test");
            var response = await client.GetAsync("https://localhost:7063/api/response/25");
            /*var response = await clientPolicy.InmmediateHttpRetry
                .ExecuteAsync(() => client.GetAsync("https://localhost:7063/api/response/25"));*/
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> ResponseService return SUCCESS");
                return Ok();
            }
            Console.WriteLine("--> ResponseService return FAILURE");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}