using AmdarisQuizResultsApi.Models;
using AmdarisQuizResultsApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmdarisQuizResultsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        private readonly IQuizRepository _quizRepo;
        public QuizController(IQuizRepository quizRepo)
        {
            _quizRepo = quizRepo;
        }

        //[HttpPost]
        //private IActionResult CreateQuiz([FromBody] Quiz quiz)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var created = _quizRepo.AddEntity(quiz);
        //        return Created($"https://localhost:5003/api/quizresults/{created.Id}", created);
        //    }
        //    else
        //        return BadRequest("ModelState is not valid.");
        //}
        
        [HttpGet]
        [Route("{questionsCount}")]
        public IActionResult GenerateQuiz(int questionsCount)
        {
            if (ModelState.IsValid)
            {
                var quiz = new Quiz();
                var created = _quizRepo.AddEntity(quiz);
                var quizGenerated = _quizRepo.GenerateQuiz(created, questionsCount);
                return Ok(quizGenerated);
            }
                
            else
                return BadRequest("ModelState is not valid.");
            
        }
    }
}
