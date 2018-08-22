using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAppApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace SurveyAppApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    public class SurveyController : Controller
    {
        public ISurveyRepository repository;
        public Data data;
        private readonly IMapper _mapper;
        public IInProgressResultsRepository inProgressResultsRepository;


        public SurveyController(ISurveyRepository repository, Data data, IMapper mapper, IInProgressResultsRepository inProgressResultsRepository)
        {
            this.inProgressResultsRepository = inProgressResultsRepository;
            this.repository = repository;
            this.data = data;
            _mapper = mapper;
        }

        [HttpGet]
        public string PersonalitySurvey()
        {
            int surveyId = 1;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Survey, SurveyDTO>();
                cfg.CreateMap<Question, QuestionDTO>();
                cfg.CreateMap<PossibleAnswers, PossibleAnswerDTO>();
                cfg.CreateMap<SubQuestions, SubQuestionDTO>();
                cfg.CreateMap<ConstraintsTable, ConstraintsDTO[]>();
            });

            Survey survey = repository.GetSurvey(surveyId);
            OtherQuestions[] OtherQuestions = data.OtherQuestions.Where(p => p.SurveyId == surveyId).ToArray();
            var mapper = config.CreateMapper();
            ConstraintsTable ConstraintsForTransfer = new ConstraintsTable();
            ConstraintsForTransfer.ConstraintsCollection = data.Constraints.Where(p =>p.SurveyId == surveyId).ToArray();
            var constraintz = JsonConvert.SerializeObject(ConstraintsForTransfer);
            ExcludedResultsTable ExcludedResultsForTransfer = new ExcludedResultsTable();
            ExcludedResultsForTransfer.ExcludedResults = data.ExcludedResults.Where(p => p.SurveyId == surveyId).ToArray();
            var surveyz = mapper.Map<Survey, SurveyDTO>(survey);
            var constraint1z = mapper.Map<ConstraintsTable, ConstraintsDTO[]>(ConstraintsForTransfer);
            var  surveyzToTransfer = JsonConvert.SerializeObject(surveyz);
            Pagination[] Pagination = data.Paginations.Where(p => p.SurveyId == surveyId).ToArray();
            Object[] objectForDataTransfer = new Object[5];
            objectForDataTransfer[0] = ConstraintsForTransfer;
            objectForDataTransfer[1] = surveyz;
            objectForDataTransfer[2] = ExcludedResultsForTransfer.ExcludedResults;
            objectForDataTransfer[3] = OtherQuestions;
            objectForDataTransfer[4] = Pagination;
            return JsonConvert.SerializeObject(objectForDataTransfer);
        }

        [HttpGet]
        public string DiarySurvey()
        {

            int surveyId = 2;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Survey, SurveyDTO>();
                cfg.CreateMap<Question, QuestionDTO>();
                cfg.CreateMap<PossibleAnswers, PossibleAnswerDTO>();
                cfg.CreateMap<SubQuestions, SubQuestionDTO>();
                cfg.CreateMap<ConstraintsTable, ConstraintsDTO[]>();
            });

            Survey survey = repository.GetSurvey(surveyId);
            OtherQuestions[] OtherQuestions = data.OtherQuestions.Where(p => p.SurveyId == surveyId).ToArray();
            var mapper = config.CreateMapper();
            ConstraintsTable ConstraintsForTransfer = new ConstraintsTable();
            ConstraintsForTransfer.ConstraintsCollection = data.Constraints.Where(p => p.SurveyId == surveyId).ToArray();
            var constraintz = JsonConvert.SerializeObject(ConstraintsForTransfer);
            ExcludedResultsTable ExcludedResultsForTransfer = new ExcludedResultsTable();
            ExcludedResultsForTransfer.ExcludedResults = data.ExcludedResults.Where(p => p.SurveyId == surveyId).ToArray();
            var surveyz = mapper.Map<Survey, SurveyDTO>(survey);
            var constraint1z = mapper.Map<ConstraintsTable, ConstraintsDTO[]>(ConstraintsForTransfer);
            var surveyzToTransfer = JsonConvert.SerializeObject(surveyz);
            Pagination[] Pagination = data.Paginations.Where(p => p.SurveyId == surveyId).ToArray();
            Object[] objectForDataTransfer = new Object[5];
            objectForDataTransfer[0] = ConstraintsForTransfer;
            objectForDataTransfer[1] = surveyz;
            objectForDataTransfer[2] = ExcludedResultsForTransfer.ExcludedResults;
            objectForDataTransfer[3] = OtherQuestions;
            objectForDataTransfer[4] = Pagination;
            return JsonConvert.SerializeObject(objectForDataTransfer);
        }

        [HttpGet]
        public string FinalSurvey()
        {
            int surveyId = 5;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Survey, SurveyDTO>();
                cfg.CreateMap<Question, QuestionDTO>();
                cfg.CreateMap<PossibleAnswers, PossibleAnswerDTO>();
                cfg.CreateMap<SubQuestions, SubQuestionDTO>();
                cfg.CreateMap<ConstraintsTable, ConstraintsDTO[]>();
            });

            Survey survey = repository.GetSurvey(surveyId);
            OtherQuestions[] OtherQuestions = data.OtherQuestions.Where(p => p.SurveyId == surveyId).ToArray();
            var mapper = config.CreateMapper();
            ConstraintsTable ConstraintsForTransfer = new ConstraintsTable();
            ConstraintsForTransfer.ConstraintsCollection = data.Constraints.Where(p => p.SurveyId == surveyId).ToArray();
            var constraintz = JsonConvert.SerializeObject(ConstraintsForTransfer);
            ExcludedResultsTable ExcludedResultsForTransfer = new ExcludedResultsTable();
            ExcludedResultsForTransfer.ExcludedResults = data.ExcludedResults.Where(p => p.SurveyId == surveyId).ToArray();
            var surveyz = mapper.Map<Survey, SurveyDTO>(survey);
            var constraint1z = mapper.Map<ConstraintsTable, ConstraintsDTO[]>(ConstraintsForTransfer);
            var surveyzToTransfer = JsonConvert.SerializeObject(surveyz);
            Pagination[] Pagination = data.Paginations.Where(p => p.SurveyId == surveyId).ToArray();
            Object[] objectForDataTransfer = new Object[5];
            objectForDataTransfer[0] = ConstraintsForTransfer;
            objectForDataTransfer[1] = surveyz;
            objectForDataTransfer[2] = ExcludedResultsForTransfer.ExcludedResults;
            objectForDataTransfer[3] = OtherQuestions;
            objectForDataTransfer[4] = Pagination;
            return JsonConvert.SerializeObject(objectForDataTransfer);
        }


        [HttpPost]
        public async  Task<string> SaveResults([FromBody]InProgResponseDto ResultsFromMethod)
        {
            InProgressResponses inProgressResults = await inProgressResultsRepository.GetResponses(ResultsFromMethod.UserId, ResultsFromMethod.SurveyId, ResultsFromMethod.ResponseCollection);
            if(inProgressResults != null)
            {
                return "Success";
            }
            else
            {
                return "Bad";
            }
        }
        /** checks to see if the provided UserId has any already existing uncompleted surveys*/
        public IActionResult FindResult([FromBody] FindResultsDto findResultsDTO)

        {
            InProgressResponses inProgressResults = data.InProgressResponses.Where(p => p.ParticipantId == findResultsDTO.participantID && p.SurveyId == findResultsDTO.surveyId).FirstOrDefault();
            
            if (inProgressResults != null)
            {
                inProgressResults.SavedResponses = data.InProgressResponse.Where(p => p.InprogressResponsesId == inProgressResults.InProgressResponsesId).ToArray();
                if( inProgressResults.SavedResponses != null)
                {
                    return Ok(JsonConvert.SerializeObject(inProgressResults));
                }
            }
            return NotFound("There are no saved results");
        }

        public IActionResult SaveResponses([FromBody] CreateCompleteResponsesDTO responses)
        {
            Task<string> result = repository.CreateResponseEntry(responses.ParticipantId, responses.Responses, responses.SurveyId);
            return Ok();
        }


    }
}
