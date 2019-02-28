namespace ShowGo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ShowGo.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ShowGo.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShowGo.Models.ApplicationDbContext context)
        {
            context.Surveys.AddOrUpdate(
                survey => new { survey.Id, survey.Title },
                new Survey { Id = 1, Title = "What is your favorite music genre?" });

            context.SaveChanges();

            context.Questions.AddOrUpdate(
                question => new { question.Body, question.Type, question.SurveyId},
                new Question
                {
                    Body = "On a scale of 0 to 5 how often do you listen to Rock?",
                    Type = QuestionType.Numeric,
                    SurveyId = 1
                },
                new Question
                {
                    Body = "On a scale of 0 to 5 how often do you listen to Country?",
                    Type = QuestionType.Numeric,
                    SurveyId = 1
                },
                new Question
                {
                    Body = "On a scale of 0 to 5 how often do you listen to EDM?",
                    Type = QuestionType.Numeric,
                    SurveyId = 1
                },
                new Question
                {
                    Body = "On a scale of 0 to 5 how often do you listen to Blues?",
                    Type = QuestionType.Numeric,
                    SurveyId = 1
                },
                new Question
                {
                    Body = "Do you live in Wisconsin?",
                    Type = QuestionType.YesNo,
                    SurveyId = 1
                });

            context.SaveChanges();
        }
    }
}

