using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication5Angular.Controllers
{
    public class Integration : Controller
    {
        // GET: IntegrationProblem
        public ActionResult Index()
        {
            return View();
        }

        // GET: IntegrationProblem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IntegrationProblem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IntegrationProblem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IntegrationProblem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IntegrationProblem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IntegrationProblem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IntegrationProblem/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
