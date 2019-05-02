using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ShowGo.Models;
using ShowGo.ViewModels;

namespace ShowGo.Controllers
{   
    [Authorize]
    public class SurveyController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Survey
        public ActionResult Index()
        {   

            return View(db.Surveys.ToList());
        }

        // GET: Survey/Details/5
        public ActionResult Details(int? id)
        {   
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);         
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // GET: Survey/Create
        public ActionResult Create()
        {
            //Survey survey = new Survey();
            SurveyQuestionViewModel surveyViewModel = new SurveyQuestionViewModel();
            surveyViewModel.SurveyQuestions.Add(new Question());
            return View(surveyViewModel);
        }

        // POST: Survey/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SurveyQuestionViewModel questions)
        {
            Survey survey = new Survey
            {
                SurveyTitle = questions.SurveyTitle
            };
            ApplicationUser concertGoer = db.Users.Find(User.Identity.GetUserId());
            survey.CreatedBy = concertGoer;
            foreach (var text in questions.SurveyQuestions)
            {
                survey.Questions.Add(text);
            }
            db.Surveys.Add(survey);
            db.SaveChangesAsync();
            return RedirectToAction("Index");                   
        }

        // GET: Survey/Edit/5
        public ActionResult Edit(int? id)
        {   
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SurveyQuestionViewModel surveyQuestionViewModel = new SurveyQuestionViewModel();
            surveyQuestionViewModel = db.Survey
                .Where(x => x.SurveyId == id)
                .Select(x => new SurveyQuestionViewModel
                {
                    SurveyTitle = x.SurveyTitle,
                    SurveyId = x.Id,
                    SurveyQuestions = x.Questions
                }).FirstorDefault();

        
            return View(surveyQuestionViewModel);
        }

        // POST: Survey/Edit/5
        [HttpPost]
        public ActionResult Edit(Survey survey, SurveyQuestionViewModel surveyViewModel)
        {
            survey.SurveyTitle = surveyViewModel.SurveyTitle;
            if (ModelState.IsValid)
            {
                foreach (var question in surveyViewModel.SurveyQuestions)
                {
                    var existingQuestion = db.Questions.Where(x => x.QuestionId == question.Id).FirstOrDefault();
                    if (existingQuestion == null)
                    {
                        question.SurveyId = survey.SurveyId;
                        db.Questions.Add(question);                   
                    }
                    else
                    {
                        existingQuestion.SurveyQuestion = question.SurveyQuestion;
                        survey.Questions.Add(existingQuestion);
                    }
                }

                db.Entry(survey).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(surveyViewModel);
        }

        // GET: Survey/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Survey/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey survey = db.Surveys.Find(id);
            db.Surveys.Remove(survey);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TakeSurvey(int id)
        {
            SurveyResponseViewModel surveyResponse = new SurveyResponseViewModel();
            surveyResponse = db.Surveys
                .Where(x => x.SurveyId == id)
                .Select(x => new SurveyResponseViewModel
                {
                    SurveyId = x.Id,
                    SurveyTitle = x.SurveyTitle,
                    //SurveyQuestions = x.Questions
                }).FirstOrDefault();
            foreach (var item in surveyResponse.SurveyQuestions)
            {
                Answer answer = new Answer
                {
                    Question = item,
                    QuestionId = item.Id
                };
                surveyResponse.QuestionAnswers.Add(answer);
            }
            return View(surveyResponse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TakeSurvey(SurveyResponseViewModel SurveyResponseViewModel)
        {
            ApplicationUser concertgoer = db.Users.Find(User.Identity.GetUserId());   
            
            foreach(var response in SurveyResponseViewModel.QuestionAnswers)
            {
                response.AnsweredBy = concertgoer;
                var question = db.Questions.Where(x => x.Id == response.QuestionId).FirstOrDefault();
                question.Answers.Add(response);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            
            }
            base.Dispose(disposing);
        }
    }
}
