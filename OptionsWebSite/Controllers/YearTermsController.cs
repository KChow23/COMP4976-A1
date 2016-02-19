using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiplomaDataModel;

namespace OptionsWebSite
{
    [Authorize(Roles = "Admin")]
    public class YearTermsController : Controller
    {
        private DiplomaContext db = new DiplomaContext();

        // GET: YearTerms
        public ActionResult Index()
        {
            return View(db.YearTerms.ToList());
        }

        // GET: YearTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearTerm yearTerm = db.YearTerms.Find(id);
            if (yearTerm == null)
            {
                return HttpNotFound();
            }
            return View(yearTerm);
        }

        // GET: YearTerms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YearTerms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YearTermId,Year,Term,IsDefault")] YearTerm yearTerm)
        {
            if (ModelState.IsValid) {

                // If this new YearTerm is default, set all the others to false
                if (yearTerm.IsDefault == true) {
                    List<YearTerm> YearTerms = db.YearTerms.Where(p => p.IsDefault == true).ToList();

                    foreach (YearTerm yt in YearTerms) {
                        yt.IsDefault = false;
                    }

                }
                else
                {
                    var defaultYear = db.YearTerms.Where(prev => prev.IsDefault == true && prev.YearTermId != yearTerm.YearTermId).Count();
                    if(defaultYear <= 0)
                    {
                        yearTerm.IsDefault = true;
                    }
                }

                db.YearTerms.Add(yearTerm);
                db.SaveChanges();


                return RedirectToAction("Index");
            }

            return View(yearTerm);
        }

        // GET: YearTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearTerm yearTerm = db.YearTerms.Find(id);
            if (yearTerm == null)
            {
                return HttpNotFound();
            }
            return View(yearTerm);
        }

        // POST: YearTerms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YearTermId,Year,Term,IsDefault")] YearTerm yearTerm)
        {
            if (ModelState.IsValid)
            {

                // If this edited YearTerm is default, set all the others to false
                if (yearTerm.IsDefault == true) {
                    List<YearTerm> YearTerms = db.YearTerms.Where(p => p.IsDefault == true).ToList();

                    foreach (YearTerm yt in YearTerms) {
                        yt.IsDefault = false;
                    }
                }
                else
                {
                    var defaultYear = db.YearTerms.Where(prev => prev.IsDefault == true && prev.YearTermId != yearTerm.YearTermId).Count();
                    if (defaultYear <= 0)
                    {
                        yearTerm.IsDefault = true;
                    }
                }

                db.Entry(yearTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yearTerm);
        }

        // GET: YearTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearTerm yearTerm = db.YearTerms.Find(id);
            if (yearTerm == null)
            {
                return HttpNotFound();
            }
            return View(yearTerm);
        }

        // POST: YearTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YearTerm yearTerm = db.YearTerms.Find(id);
            db.YearTerms.Remove(yearTerm);
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
