using AmdarisQuizResults.Models;
using AmdarisQuizResults.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult AddQuizResult([FromBody] QuizResult quizResult)
        {
                var created = _quizService.AddQuizResult(quizResult);
                return Created($"https://localhost:5003/api/quizresults/{created.Id}", created);
        }

        [HttpGet]
        public IActionResult ListQuizResults()
        {
            return Ok(_quizService.ListQuizResults());
        }
    }
}
