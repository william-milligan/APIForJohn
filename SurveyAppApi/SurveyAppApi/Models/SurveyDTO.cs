using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAppApi.Models;

namespace SurveyAppApi
{
    public class SurveyDTO
    {
        public int SurveyId { get; set; }
        public string Name { get; set; }
        public ICollection<QuestionDTO> Questions { get; set; }
    }
    public class QuestionDTO
    {
        public ICollection<PossibleAnswerDTO> PossibleAnswers { get; set; }
        public ICollection<SubQuestions> SubQuestions { get; set; }
        public string Type { get; set; }
        public int SurveyID { get; set; }
        public string QuestionAsked { get; set; }
        public int QuestionNumber { get; set; }
        public int QuestionId { get; set; }
        public bool HasSubQuestions { get; set; }
        public bool TriggersConstraint { get; set; }
        public bool Hidden { get; set; }
    }
    public class PossibleAnswerDTO
    {
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public int PossibleAnswersId { get; set; }
    }
    public class SubQuestionDTO
    {
        public int SubQuestionsId { get; set; }
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public int? QuestionNumber { get; set; }

    }
    public class ConstraintsDTO
    {
        public int ConstraintsId { get; set; }
        public int QuestionIdTriggeringConstraint { get; set; }
        public int QuestionIdWithConstraint { get; set; }
        public string ConstraintType { get; set; }
        public string PossibleAnswersId { get; set; }
        public int SurveyId { get; set; }
    }
    public class ConstrainsTable
    {
        public ICollection<ConstraintsDTO> constraintsDTOs { get; set; }
    }
    public class ExcludedResult
    {
        public int ExcludedResultId { get; set; }
        public int PossibleAnswersId { get; set; }
        public int QuestionId { get; set; }
        public int SurveyId { get; set; }
    }
    public class ExcludedResultsTableDTO
    {
        public ICollection<ExcludedResult> ExcludedResultsDTOs { get; set; }

    }

    public class CreateCompleteResponsesDTO
    {
        public string ParticipantId { get; set; }
        public ResponseDto[] Responses { get; set; }
        public int SurveyId { get; set; }
    }
    public class ResponseDto
    {
        public string[] Responses { get; set; }
        public int QuestionId { get; set; }
        public string QuestionAsked { get; set; }
    }
}