﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SurveyAppApi.Models;
using System;

namespace SurveyAppApi.Migrations
{
    [DbContext(typeof(Data))]
    [Migration("20180708172215_SurveyId")]
    partial class SurveyId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SurveyAppApi.Models.CompletedSurvey", b =>
                {
                    b.Property<int>("CompletedSurveyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SurveyId");

                    b.Property<int>("UserId");

                    b.HasKey("CompletedSurveyId");

                    b.HasIndex("SurveyId");

                    b.ToTable("CompletedSurveys");
                });

            modelBuilder.Entity("SurveyAppApi.Models.Constraints", b =>
                {
                    b.Property<int>("ConstraintsId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConstraintType");

                    b.Property<string>("PossibleAnswersId");

                    b.Property<int>("QuestionIdTriggeringConstraint");

                    b.Property<int>("QuestionIdWithConstraint");

                    b.Property<int>("SurveyId");

                    b.HasKey("ConstraintsId");

                    b.ToTable("Constraints");
                });

            modelBuilder.Entity("SurveyAppApi.Models.PossibleAnswers", b =>
                {
                    b.Property<int>("PossibleAnswersId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int>("QuestionId");

                    b.HasKey("PossibleAnswersId");

                    b.HasIndex("QuestionId");

                    b.ToTable("PossibleAnswers");
                });

            modelBuilder.Entity("SurveyAppApi.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("HasSubQuestions");

                    b.Property<string>("QuestionAsked");

                    b.Property<int>("QuestionNumber");

                    b.Property<int>("SurveyId");

                    b.Property<bool>("TriggersConstraint");

                    b.Property<string>("Type");

                    b.HasKey("QuestionId");

                    b.HasIndex("SurveyId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("SurveyAppApi.Models.Responce", b =>
                {
                    b.Property<int>("ResponceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<int>("CompletedSurveyId");

                    b.Property<int>("QuestionId");

                    b.Property<int>("QuestionNumber");

                    b.Property<int>("UserId");

                    b.HasKey("ResponceId");

                    b.HasIndex("CompletedSurveyId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Responces");
                });

            modelBuilder.Entity("SurveyAppApi.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ParticipantId");

                    b.Property<DateTime>("RoleCreatedOn");

                    b.Property<string>("RoleName");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SurveyAppApi.Models.SubQuestions", b =>
                {
                    b.Property<int>("SubQuestionsId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int>("QuestionId");

                    b.Property<int?>("QuestionNumber");

                    b.HasKey("SubQuestionsId");

                    b.HasIndex("QuestionId");

                    b.ToTable("SubQuestions");
                });

            modelBuilder.Entity("SurveyAppApi.Models.Survey", b =>
                {
                    b.Property<int>("SurveyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("TimeForUserAccess");

                    b.HasKey("SurveyId");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("SurveyAppApi.Models.CompletedSurvey", b =>
                {
                    b.HasOne("SurveyAppApi.Models.Survey", "SurveyTemplate")
                        .WithMany()
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SurveyAppApi.Models.PossibleAnswers", b =>
                {
                    b.HasOne("SurveyAppApi.Models.Question", "Question")
                        .WithMany("PossibleAnswers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SurveyAppApi.Models.Question", b =>
                {
                    b.HasOne("SurveyAppApi.Models.Survey", "Survey")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SurveyAppApi.Models.Responce", b =>
                {
                    b.HasOne("SurveyAppApi.Models.CompletedSurvey", "CompletedSurvey")
                        .WithMany("Responces")
                        .HasForeignKey("CompletedSurveyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SurveyAppApi.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SurveyAppApi.Models.SubQuestions", b =>
                {
                    b.HasOne("SurveyAppApi.Models.Question")
                        .WithMany("SubQuestions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
