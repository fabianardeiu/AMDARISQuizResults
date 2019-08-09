using AmdarisQuizResults.Models;
using AmdarisQuizResults.Services;
using AmdarisQuizResultsApi.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AmdarisQuizResults.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizResultsController : Controller
    {
        private readonly IQuizResultService _quizService;
        public QuizResultsController(IQuizResultService quizService)
        {
            _quizService = quizService;
        }

        [HttpPost]
        public async Task<IActionResult> AddQuizResult([FromBody] QuizResultDTO quizResult)
        {
           var result = await _quizService.Calculate(quizResult);
            return result ? Ok("Saved") : (IActionResult)BadRequest();
        }

        [HttpGet]
        public IActionResult ListQuizResults()
        {
            return Ok(_quizService.ListQuizResults());
        }
    }
}
