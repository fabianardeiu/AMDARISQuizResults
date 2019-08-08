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
    public class AnswerController : Controller
    {
        private readonly IRepository<Answer> _answerRepo;
        public AnswerController(IRepository<Answer> answerRepo)
        {
            _answerRepo = answerRepo;
        }

        [HttpPost]
        public IActionResult CreateAnswer([FromBody] Answer answer)
        {
            if (ModelState.IsValid)
            {
                var create = _answerRepo.AddEntity(answer);
                return Created($"https://localhost:5001/api/vehicle/{create.Id}", create);
            }
            else
                return BadRequest("ModelState is not valid.");
        }

       //[HttpPut]
       //public IActionResult UpdateAnswer([FromBody] Answer answer)
       // {
       //     if (ModelState.IsValid)
       //     {
       //         _answerRepo.Update(answer);
       //         return Ok("Vehicle updated correctly");
       //     }
       //     else
       //         return BadRequest("ModelState is not valid");
       // }

       // [Route("{answerId}")]
       // [HttpDelete]
       // public IActionResult DeleteAnswer(int answerId)
       // {
       //     _answerRepo.DeleteById(answerId);
       //     return Ok("Answer deleted.");
       // }

    }
}
