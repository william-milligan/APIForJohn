using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAppApi.Models
{

        public class QuestionEditDTO
        {
            public PossibleAnswerEditDTO[] PossibleAnswers { get; set; }
            public SubQuestionEditDTO[] SubQuestions { get; set; }
            public string type { get; set; }
            public int SurveyID { get; set; }
            public string QuestionAsked { get; set; }
            public int QuestionNumber { get; set; }
            public int QuestionId { get; set; }
            public bool HasSubQuestions { get; set; }
            public bool TriggersConstraint { get; set; }
            public bool Hidden { get; set; }
        }
        public class PossibleAnswerEditDTO
        {
            public string Content { get; set; }
            public int QuestionId { get; set; }
            public int PossibleAnswersId { get; set; }
        }
        public class SubQuestionEditDTO
        {
            public int SubQuestionsId { get; set; }
            public string Content { get; set; }
            public int QuestionId { get; set; }
            public int? QuestionNumber { get; set; }
        }
        public class QuestionCreateDTO
        {
            public string[] PossibleAnswers { get; set; }
            public string[] SubQuestions { get; set; }
            public string Type { get; set; }
            public int SurveyID { get; set; }
            public string QuestionAsked { get; set; }
            public bool HasSubQuestions { get; set; }
            public bool TriggersConstraint { get; set; }
            public bool Hidden { get; set; }
            public string PaginationString { get; set; }
            public int PaginationID { get; set; }
        }
}
