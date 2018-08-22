using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurveyAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAppApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    public class AdminController : Controller
    {
        Data Data;
        ISurveyRepository repository;


        public AdminController(Data data, ISurveyRepository repository)
        {
            this.repository = repository;
            Data = data;
        }

        public ActionResult GetSurveys()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Survey, SurveyDTO>();
                cfg.CreateMap<Question, QuestionDTO>();
                cfg.CreateMap<PossibleAnswers, PossibleAnswerDTO>();
                cfg.CreateMap<SubQuestions, SubQuestionDTO>();
            });
            var mapper = config.CreateMapper();

            int[] surveyIds = repository.GetSurveyIds();
            Object[] surveysForTransfer = new Object[surveyIds.Length];
            for(int x = 0; x < surveyIds.Length;x++)
            {
                Survey survey = repository.GetSurvey(surveyIds[x]);

                var surveyz = mapper.Map<Survey, SurveyDTO>(survey);
                surveysForTransfer[x] = surveyz;
            }
            Pagination[] pagination = Data.Paginations.ToArray();
            Object[] objectForDataTransfer = new object[2];
            objectForDataTransfer[0] = surveysForTransfer;
            objectForDataTransfer[1] = pagination;
            return Ok(objectForDataTransfer);
        }

        [HttpPost]
        public ActionResult EditQuestion([FromBody]QuestionEditDTO revisedQuestion)
        {
            string result = repository.EditQuestion(revisedQuestion);
            return Ok("Sucess");
        }

        [HttpPost]
        public IActionResult CreateNewQuestion([FromBody]QuestionCreateDTO newQuestion)
        {
            return null;
        }

    }
}
