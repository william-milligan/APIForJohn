using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAppApi.Models
{
    public interface ISurveyRepository
    {
        Survey GetSurvey(int id);
        int[] GetSurveyIds();
        string EditQuestion(QuestionEditDTO questionEditData);
        Task<string> CreateResponseEntry(string participantId, ResponseDto[] responses, int surveyId);
        Task<CompletedSurvey> CreateNewCompletedSurveyObject(string participantId, int surveyId);
    }

    public class _SurveyRepository : ISurveyRepository
    {
        private Data _data;

        public _SurveyRepository(Data _data)
        {
            this._data = _data;
        }

        public Survey GetSurvey(int id)
        {
            Survey survey = new Survey();
            survey = _data.Surveys.Where(p => p.SurveyId == id).FirstOrDefault();
            List<Question> questions = _data.Questions.Where(p => p.SurveyId == survey.SurveyId).OrderBy(f => f.QuestionNumber).ToList();
            survey.Questions = questions;

            foreach (Question question in survey.Questions)
            {
                question.PossibleAnswers = _data.PossibleAnswers.Where(p => p.QuestionId == question.QuestionId).ToList();
                if(question.HasSubQuestions == true)
                {
                        question.SubQuestions = _data.SubQuestions.Where(p => p.QuestionId == question.QuestionId).ToList();
                }
            }
            return survey;
        }
        public int[] GetSurveyIds()
        {
            Survey[] surveys = _data.Surveys.ToArray();
            List<int> surveyIds = new List<int>();
            for(int x = 0; x < surveys.Length; x++)
            {
                surveyIds.Add(surveys[x].SurveyId);
            }
            return surveyIds.ToArray();
        }

        public string EditQuestion(QuestionEditDTO questionEditData)
        {
            for(int  x = 0; x < questionEditData.PossibleAnswers.Length; x++)
            {
                PossibleAnswers answer = _data.PossibleAnswers.Where(p => p.PossibleAnswersId == questionEditData.PossibleAnswers[x].PossibleAnswersId).FirstOrDefault();
                if(answer == null)
                {
                    return null;
                }
                if(answer.Content != questionEditData.PossibleAnswers[x].Content)
                {
                    answer.Content = questionEditData.PossibleAnswers[x].Content;
                    _data.SaveChanges();

                }

            }
            if(questionEditData.HasSubQuestions == true)
            {
                for(int x = 0; x < questionEditData.SubQuestions.Length; x++)
                {
                    SubQuestions subQuestion = _data.SubQuestions.Where(s => s.SubQuestionsId == questionEditData.SubQuestions[x].SubQuestionsId).FirstOrDefault();
                    if (subQuestion == null)
                    {
                        return "Failed at Subquestion Id" + questionEditData.SubQuestions[x].SubQuestionsId;
                    }
                    subQuestion.Content = questionEditData.SubQuestions[x].Content;
                }
            }
            Question questionToEdit = _data.Questions.Where(q => q.QuestionId == questionEditData.QuestionId).FirstOrDefault();
            questionToEdit.QuestionNumber = questionEditData.QuestionNumber;
            questionToEdit.QuestionAsked = questionEditData.QuestionAsked;
            questionToEdit.Hidden = questionEditData.Hidden;
            questionToEdit.Type = questionEditData.type;
            _data.SaveChanges();
            

            return "sucess";
        }

        public async Task<string> CreateResponseEntry(string participantId, ResponseDto[] responses, int surveyId)
        {
            int responseNumber = 0;
            CompletedSurvey survey = await CreateNewCompletedSurveyObject(participantId, surveyId);
            List<Response> responsesForDb = new List<Response>();
            for (int x = 0; x < responses.Length; x++)
            {
                if (responses[x] == null)
                {
                    continue;
                }
                for (int y = 0; y < responses[x].Responses.Length; y++)
                {
                    Response response = new Response
                    {
                        Answer = responses[x].Responses[y],
                        QuestionId = responses[x].QuestionId,
                        QuestionAsked = responses[x].QuestionAsked,
                        CompletedSurveyId = survey.CompletedSurveyId
                       
                    };
                    _data.Add(response);
                }
            }
            _data.SaveChanges(); 
            return "success";
        }

        public async Task<CompletedSurvey> CreateNewCompletedSurveyObject(string participantId, int surveyId)
        {
            CompletedSurvey survey = new CompletedSurvey
            {
                ParticipantId = participantId,
                SurveyId = surveyId
            };
             _data.Add(survey);
             _data.SaveChanges();
        return survey;
        }
    }
}