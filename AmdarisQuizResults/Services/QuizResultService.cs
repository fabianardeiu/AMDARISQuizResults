using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmdarisQuizResults.Models;
using AmdarisQuizResultsApi.DTO;
using AmdarisQuizResultsApi.Models;

namespace AmdarisQuizResults.Services
{
    public class QuizResultService : IQuizResultService
    {
        private readonly AmdarisQuizContext _context;
        public QuizResultService(AmdarisQuizContext context)
        {
            _context = context;
        }
        public async Task<QuizResult> AddQuizResult(QuizResult quizResult)
        {
            await _context.AddAsync(quizResult);
            await _context.SaveChangesAsync();
            return quizResult;
        }


        public async Task<bool> Calculate(QuizResultDTO quizResultDTO)
        {
            return await Task.Run(async () =>
            {
                var correctAnswers = _context.Answers.Where(a => a.IsCorrect);
                var score = quizResultDTO.Answers.Count(a => correctAnswers.Any(ans => ans.IsCorrect == a.IsSelected));
                if(ParticipantExists(quizResultDTO.FirstName,quizResultDTO.LastName,quizResultDTO.Email))
                {
                    await AddQuizResult(new QuizResult
                    {

                        Score = score,
                        Participant = GetParticipant(quizResultDTO.FirstName, quizResultDTO.LastName, quizResultDTO.Email),
                        QuizId = quizResultDTO.QuizId
                    }); 
                }
                else
                {
                    await AddQuizResult(new QuizResult
                    {
                        Score = score,
                        Participant = new Participant
                        { LastName = quizResultDTO.LastName, FirstName = quizResultDTO.FirstName, Email = quizResultDTO.Email }
                    });
                }
                
                return true;
            });
        }
        private bool ParticipantExists(string firstName, string lastName, string email)
        {
            return _context.Participants
                        .Any(p => p.FirstName == firstName && p.LastName == lastName && p.Email == email);
        }
        private Participant GetParticipant(string firstName, string lastName, string email)
        {
            return _context.Participants.First(p => p.FirstName == firstName && p.LastName == lastName && p.Email == email);
        }

        public IEnumerable<QuizResult> ListQuizResults()
        {
            return _context.QuizResults.ToList();
        }
    }
}
