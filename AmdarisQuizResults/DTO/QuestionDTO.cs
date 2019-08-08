using System.Collections.Generic;

namespace AmdarisQuizResultsApi.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string SnippetUrl { get; set; }
        public IEnumerable<AnswerDTO> AnswerDTOs { get; set; }
    }
}
