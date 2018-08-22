using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAppApi.Models
{
    public class Data : DbContext
    {
        public Data(DbContextOptions<Data> options)
             : base(options) { }

        public DbSet<PossibleAnswers> PossibleAnswers { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<Response> Responses { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<CompletedSurvey> CompletedSurveys { get; set; }

        public DbSet<SubQuestions> SubQuestions { get; set; }

        public DbSet<Constraints> Constraints { get; set; }

        public DbSet<ExcludedResult> ExcludedResults { get; set; }

        public DbSet<InProgressResponses> InProgressResponses { get; set; }

        public DbSet<InProgressResponse> InProgressResponse { get; set; }
        
        public DbSet<OtherQuestions> OtherQuestions { get; set; }

        public DbSet<Pagination> Paginations { get; set; }
        /**
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelbuilder);
        } */
    }
}

