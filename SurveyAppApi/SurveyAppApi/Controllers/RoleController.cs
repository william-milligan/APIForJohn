using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SurveyAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAppApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    public class RoleController
    {
        private readonly Data _Data;
        private IRoleRepository _RoleRepo;
        
        public RoleController(Data data, IRoleRepository role)
        {
            _Data = data;
            _RoleRepo = role;
        }
        [HttpPost]
        public string GetRole([FromBody]RoleDto roleDto)
        {
            string roleToReturn =  _RoleRepo.GetRole(Int32.Parse(roleDto.ParticipantId));
            return roleToReturn;
        }
        [HttpPost]
        [DisableCors]
        public async Task<string> UpdateRole([FromBody]RoleUpdateDTO roleDto)
        {   
            string roleToReturn = await _RoleRepo.UpdateRole(Int32.Parse(roleDto.ParticipantId), roleDto.ParticipantRole);
            return roleToReturn;
        }
    }
}
