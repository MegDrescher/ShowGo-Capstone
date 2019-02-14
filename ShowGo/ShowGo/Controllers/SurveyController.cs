using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShowGo.Controllers
{
    public class SurveyController : Controller
    {
        // GET: Survey
        public ActionResult Index()
        {
            return View();
        }

        // GET: Survey/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Survey/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Survey/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Survey/Edit/5
        public ActionResult Edit(int id)
        {
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
