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
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepo;
        public QuestionController(IQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }

        [HttpPost]
        public IActionResult CreateQuestion([FromBody] Question question)
        {
            if(ModelState.IsValid)
            {
                var created = _questionRepo.AddEntity(question);
                return Created($"https://localhost:5003/api/quizresults/{created.Id}", created);
            }
            else
                return BadRequest("ModelState is not valid.");
        }

        [Route("{questionId}/answers")]
        [HttpGet]
        public IActionResult GetAnswers(int questionId)
        {
            var answers = _questionRepo.GetAnswers(questionId);
            return Ok(answers);
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_questionRepo.GetAll());
        }
    }

    
}
