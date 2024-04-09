using Microsoft.AspNetCore.Mvc;
using Moodle.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace Moodle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: api/Home/Index
        [HttpGet("Index")] 
        [SwaggerOperation(Summary = "Get index")]
        public IActionResult Index()
        {
            return Ok();
        }

        // GET: api/Home/Privacy
        [HttpGet("Privacy")] 
        [SwaggerOperation(Summary = "Get privacy")]
        public IActionResult Privacy()
        {
            return Ok();
        }

        // GET: api/Home/Error
        [HttpGet("Error")] 
        [SwaggerOperation(Summary = "Get error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return Ok(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

