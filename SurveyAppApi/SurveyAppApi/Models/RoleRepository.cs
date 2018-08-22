using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAppApi.Models
{
    public interface IRoleRepository
    {
        string GetRole(int participantcId);
        Task<string> UpdateRole( int participantId, string oldRole);
        string CreateInitialRole(int participantId);
    }
    public class RoleRepository : IRoleRepository
    {
        private Data _Data;

        public RoleRepository(Data repo)
        {
            _Data = repo;
        }
        public  string GetRole(int participantId)
        {
            Role role = _Data.Roles.Where(p => p.ParticipantId == participantId).FirstOrDefault();
            if(role == null)
            {
               string answer =  CreateInitialRole(participantId);
                role = _Data.Roles.Where(p => p.ParticipantId == participantId).FirstOrDefault();
            }
            return role.RoleName;
        }
        public async Task<string> UpdateRole(int participantId, string currentRole)
        {
            string newRole = "";
            Role role = _Data.Roles.Where(p => p.ParticipantId == participantId).FirstOrDefault();
            if(role.RoleName != currentRole)
            {
                return "Not Successful";
            }
            else
            {
                if(currentRole == "Initial")
                {
                    newRole = "InitialIncentive";
                }
                else if (currentRole == "InitialIncentive")
                {
                    newRole = "Participant";
                }
                else if (currentRole == "Participant")
                {
                    newRole = "FinalSurvey";
                }
                else if( currentRole == "FinalSurvey")
                {
                    newRole = "FinalIncentive";
                }
                else if (currentRole == "FinalIncentive")
                {
                    newRole = "Inactive";
                }
            }
            role.RoleName = newRole;
            role.RoleCreatedOn = DateTime.Now;
            _Data.Update(role);
            await _Data.SaveChangesAsync();
            return role.RoleName;
        }
        public string CreateInitialRole(int participantId)
        {
            Role intiailRole = new Role
            {
                RoleName = "Initial",
                ParticipantId = participantId,
                RoleCreatedOn = DateTime.Now,   
            };
             _Data.Roles.Add(intiailRole);
             _Data.SaveChanges();
            return "Sucess";
        }
    }
}
