using AmdarisQuizResultsApi.DTO;
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

        
        [HttpGet]
        [Route("{questionsCount}")]
        public async Task<IActionResult> GenerateQuiz(int questionsCount)
        {
            if (ModelState.IsValid)
            {
                var quiz = new Quiz();
                var created = await _quizRepo.AddEntity(quiz);
                var quizGenerated = _quizRepo.GenerateQuiz(created, questionsCount);

                var quizDTO = new QuizDTO { Name = quiz.Name, Id =quiz.Id};
                quizDTO.QuestionDTOs = new List<QuestionDTO>();
                var t = quizGenerated.Questions.Count(a => a.Answers.Count() > 0);
                foreach (var question in quizGenerated.Questions)
                {
                    
                    var answerList = question.Answers.Select(a => new AnswerDTO { Id = a.Id, QuestionId = a.QuestionId, Text = a.Text});
                    var questionDTO = new QuestionDTO {Id = question.Id,SnippetUrl = question.SnippetUrl, Text = question.Text, AnswerDTOs = answerList };
                    quizDTO.QuestionDTOs.Add(questionDTO);
                }

                return Ok(quizDTO);
            }
                
            else
                return BadRequest("ModelState is not valid.");
            
        }
    }
}
