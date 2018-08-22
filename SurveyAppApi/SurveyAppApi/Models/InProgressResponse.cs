using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAppApi.Models
{
    public class InProgressResponse
    {
        public int InProgressResponseId { get; set; }
        public int InprogressResponsesId { get; set; }
        public string Answer { get; set; }
        public int QuestionNumber { get; set; }
        public int ParticipantId { get; set; }
        public int SurveyId { get; set; }
        public string QuestionAsked { get; set; }
        public int CurrentPage { get; set; }
    }
}
