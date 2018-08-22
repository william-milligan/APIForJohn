using SurveyAppApi.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAppApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Survey, SurveyDTO>();
            CreateMap<SurveyDTO, Survey>();
            CreateMap<ConstraintsTable, ConstraintsDTO[]>();
        }
    }
}
