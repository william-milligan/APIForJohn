using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAppApi.Models
{
    public class InProgressResponses
    {
        public int InProgressResponsesId { get; set; }
        public ICollection<InProgressResponse> SavedResponses { get; set; }
        public int ParticipantId { get; set; }
        public int SurveyId { get; set; }
        public string SurveyName { get; set; }
    }
}
