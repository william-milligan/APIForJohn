using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAppApi.Models;

namespace SurveyAppApi.Models
{
    public class InProgResponseDto
    {
        public int UserId { get; set; }
        public int SurveyId { get; set; }
        public InProgResponse[] ResponseCollection { get; set; }
    }
}
