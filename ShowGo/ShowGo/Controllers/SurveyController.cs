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
            Survey survey = new Survey();
            survey.SurveyTitle = questions.SurveyTitle;
            ApplicationUser concertGoer = db.Users.Find(User.Identity.GetUserId());
            survey.CreatedBy = concertGoer;
            foreach (var text in questions.SurveyQuestions)
            {
                survey.Questions.Add(text);
            }
            db.Surveys.Add(survey);
            await.db.SaveChangesAsync();
            return RedirectToAction("Index");
                    
        }

        // GET: Survey/Edit/5
        public ActionResult Edit(int? id)
        {   
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            


            return View();
        }

        // POST: Survey/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Survey/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Survey/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
