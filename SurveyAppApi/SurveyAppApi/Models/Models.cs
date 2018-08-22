using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAppApi.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime RoleCreatedOn { get; set; }
        public int ParticipantId { get; set; }
    }
    public class CompletedSurvey
    {
        public int CompletedSurveyId { get; set; }
        public ICollection<Response> Responses { get; set; }
        public string ParticipantId { get; set; }
        public Survey SurveyTemplate { get; set; }
        public int SurveyId { get; set; }
        public CompletedSurvey()
        {
            Responses = new Collection<Response>();
        }
    }
    public class Response
    {
        public int ResponseId { get; set; }
        public string Answer { get; set; }
        public int QuestionId { get; set; }
        public int CompletedSurveyId { get; set; }
        public string QuestionAsked { get; set; }
    }
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionAsked { get; set; }
        public string Type { get; set; }
        public int QuestionNumber { get; set; }
        public Survey Survey { get; set; }
        public int SurveyId { get; set; }
        public ICollection<PossibleAnswers> PossibleAnswers { get; set; }
        public ICollection<SubQuestions> SubQuestions { get; set; }
        public bool HasSubQuestions { get; set; }
        public bool TriggersConstraint { get; set; } = false;
        public bool Hidden { get; set; } = false;
        public Question()
        {
            SubQuestions = new Collection<SubQuestions>();
            PossibleAnswers = new Collection<PossibleAnswers>();
        }
    }
    public class PossibleAnswers
    {
        public int PossibleAnswersId { get; set; }
        public string Content { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }

    public class Survey
    {
        public int SurveyId { get; set; }
        public string Name { get; set; }
        public int? TimeForUserAccess { get; set; }
        public ICollection<Question> Questions { get; set; }
        public Survey()
        {
            Questions = new Collection<Question>();
        }
    }
    public class Responce
    {
        public int ResponceId { get; set; }
        public string Answer { get; set; }
        public int QuestionNumber { get; set; }
        public Question Question { get; set; }
        public int UserId { get; set; }
        public int SurveyId { get; set; }
        public CompletedSurvey CompletedSurvey { get; set; }
        public int CompletedSurveyId { get; set; }
    }
    public class SubQuestions
    {
        public int SubQuestionsId { get; set; }
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public int? QuestionNumber { get; set; }
        public int SurveyId { get; set; }
    }
    public class Constraints
    {
        public int ConstraintsId { get; set; }
        public int QuestionIdTriggeringConstraint { get; set; }
        public int QuestionIdWithConstraint { get; set; }
        public string ConstraintType { get; set; } = "None";
        public string PossibleAnswersId { get; set; }
        public int SurveyId { get; set; }
    }
    public class ConstraintsTable
    {
        public ICollection<Constraints> ConstraintsCollection { get; set; }
        public ConstraintsTable()
        {
            ConstraintsCollection = new Collection<Constraints>();
        }
    }
    public class ExcludedResult
    {
        public int ExcludedResultId { get; set; }
        public int PossibleAnswersId { get; set; }
        public int QuestionId { get; set; }
        public int SurveyId { get; set; }
    }

    public class ExcludedResultsTable
    {
        public ICollection<ExcludedResult> ExcludedResults { get; set; }
        public ExcludedResultsTable()
        {
            ExcludedResults = new Collection<ExcludedResult>();
        }
    }

    public class InProgResponse
    {
        public string QuestionAsked { get; set; }
        public string[] Responses { get; set; }
        public int QuestionId { get; set; }
    }

    public class ResponsesCollection
    {
        public InProgResponse[] ResponseCollection { get; set; }
    }

    public class OtherQuestions
    {
        public int OtherQuestionsId { get; set; }
        public string QuestionId { get; set; }
        public string OtherQuestionContent { get; set; }
        public int SurveyId { get; set; }
    }
    public class Pagination
    {
        public int PaginationId { get; set; }
        public int CurrentPage { get; set; }
        public int StartingQuestion { get; set; }
        public int EndingQuestionNumber { get; set; }
        public int SurveyId { get; set; }
        public string PaginationString { get; set; }
        public string PageName { get; set; }
    }
}