using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAppApi.Models
{
    public interface IInProgressResultsRepository
    {
        Task<InProgressResponses> CreateNewInProgressResultsRepository(int SurveyId, int ParticipantId, InProgResponse[] responsesFromSurvey);
        Task<InProgressResponses> GetResponses(int participantId, int surveyId, InProgResponse[] responsesFromSurvey);
        Task<InProgressResponses> CreateResponses(int participantId, int surveyId, int inProgressId, InProgResponse[] responses);
    }

    public class InProgressResultsRepository : IInProgressResultsRepository
    {
        Data _Data { get; set; }
        public InProgressResultsRepository(Data _Data)
        {
            this._Data = _Data;
        }
       public async Task<InProgressResponses>  CreateNewInProgressResultsRepository( int ParticipantId, int SurveyId, InProgResponse[] responses)
        {
            InProgressResponses NewResponsesObject = new InProgressResponses();
            NewResponsesObject.SurveyId = SurveyId;
            NewResponsesObject.ParticipantId = ParticipantId;
            if(SurveyId == 1)
            {
                NewResponsesObject.SurveyName = "Personality Survey";
            }
            else if(SurveyId == 2)
            {
                NewResponsesObject.SurveyName = "Diary Survey";
            }
            else if(SurveyId == 5)
            {
                NewResponsesObject.SurveyName = "Final Survey";
            }
            else
            {
                NewResponsesObject.SurveyName = "Invalid Survey Id";
            }
            await _Data.InProgressResponses.AddAsync(NewResponsesObject);
            _Data.SaveChanges();

            await CreateResponses(NewResponsesObject.ParticipantId, NewResponsesObject.SurveyId, NewResponsesObject.InProgressResponsesId, responses);
            return NewResponsesObject;
        }

        public async Task<InProgressResponses> GetResponses(int participantId, int surveyId, InProgResponse[] responsesFromSurvey)
        {
            InProgressResponses responses = _Data.InProgressResponses.Where(p => p.ParticipantId == participantId).FirstOrDefault(); 
            if( responses != null)
            {
                _Data.InProgressResponses.Remove(responses);
                await _Data.SaveChangesAsync();
            }

            await CreateNewInProgressResultsRepository(participantId, surveyId, responsesFromSurvey);

            return responses;
        }
        public async Task<InProgressResponses> CreateResponses(int participantId, int surveyId, int inProgressId, InProgResponse[] responses)
        {
            for(int x = 0; x < responses.Length; x++)
            {
                if(responses[x] != null)
                { 
                    for(int y = 0; y<responses[x].Responses.Length; y++)
                    {
                        InProgressResponse inProgressResponse = new InProgressResponse
                        {
                            Answer = responses[x].Responses[y],
                            SurveyId = surveyId,
                            QuestionNumber = responses[x].QuestionId,
                            InprogressResponsesId = inProgressId,
                            ParticipantId = participantId,
                            QuestionAsked = responses[x].QuestionAsked
                        };
                        await _Data.InProgressResponse.AddAsync(inProgressResponse);
                        await _Data.SaveChangesAsync();
                    }
                }
            }
            return null;
        }
        public string DeleteResponses(InProgressResponses responsesToDelete)
        {
            _Data.InProgressResponses.Remove(responsesToDelete);
            _Data.SaveChanges();
            return null;
        }
    }
}
