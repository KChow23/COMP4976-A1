using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiplomaDataModel;

namespace OptionsWebSite.Controllers
{
    public class ChoicesController : Controller
    {
        private DiplomaContext db = new DiplomaContext();

        // GET: Choices
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var choices = db.Choices.Include(c => c.FirstOption).Include(c => c.FourthOption).Include(c => c.SecondOption).Include(c => c.ThirdOption).Include(c => c.YearTerm);
            return View(choices.ToList());
        }

        // GET: Choices/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = db.Choices.Find(id);
            if (choice == null)
            {
                return HttpNotFound();
            }
            return View(choice);
        }

        // GET: Choices/Create
        [Authorize(Roles = "Student,Admin")]
        public ActionResult Create()
        {
            var option = from a in db.Options
                         where a.IsActive.Equals(true)
                         select a;

            ViewBag.FirstChoiceOptionId = new SelectList(option, "OptionId", "Title");
            ViewBag.FourthChoiceOptionId = new SelectList(option, "OptionId", "Title");
            ViewBag.SecondChoiceOptionId = new SelectList(option, "OptionId", "Title");
            ViewBag.ThirdChoiceOptionId = new SelectList(option, "OptionId", "Title");
            ViewBag.YearTermId = new SelectList(db.YearTerms, "YearTermId", "YearTermId");
            ViewBag.StudentId = User.Identity.Name;

            var query = from a in db.YearTerms
                        where a.IsDefault.Equals(true)
                        select a;

            var term = query.FirstOrDefault();

            if(term.Term == 10)
            {
                ViewBag.YearTermCurrent = term.Year + " Winter";
            }
            else if (term.Term == 20)
            {
                ViewBag.YearTermCurrent = term.Year + " Spring/Summer";
            }
            else if (term.Term == 30)
            {
                ViewBag.YearTermCurrent = term.Year + " Fall";
            }

            ViewBag.YearId = term.YearTermId;

            return View();
        }

        // POST: Choices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Student,Admin")]
        public ActionResult Create([Bind(Include = "ChoiceId,YearTermId,StudentId,StudentFirstName,StudentLastName,FirstChoiceOptionId,SecondChoiceOptionId,ThirdChoiceOptionId,FourthChoiceOptionId,SelectionDate")] Choice choice)
        {
            if (db.Choices.Where(c => c.StudentId == User.Identity.Name).Where(c => c.YearTermId == choice.YearTermId).FirstOrDefault() != null) {

                ModelState.AddModelError("", "You have already submitted your selections.");
            }

            var list = new List<int>();
            
            // Ensure no choices were left unselected
            if (choice.FirstChoiceOptionId == null
                || choice.SecondChoiceOptionId == null
                || choice.ThirdChoiceOptionId == null
                || choice.FourthChoiceOptionId == null) {
                ModelState.AddModelError("", "Cannot leave choices empty.");
            } else {
                list.Add((int) choice.FirstChoiceOptionId);
                list.Add((int) choice.SecondChoiceOptionId);
                list.Add((int) choice.ThirdChoiceOptionId);
                list.Add((int) choice.FourthChoiceOptionId);
                // Ensure no duplicate options were selected
                if (list.Count != list.Distinct().Count())
                {
                    ModelState.AddModelError("", "Cannot have duplicate options");
                }

            }


            if (ModelState.IsValid)
            {
                
                db.Choices.Add(choice);
                db.SaveChanges();

                return View("success");
            }

            var option = from a in db.Options
                         where a.IsActive.Equals(true)
                         select a;

            ViewBag.FirstChoiceOptionId = new SelectList(option, "OptionId", "Title", choice.FirstChoiceOptionId);
            ViewBag.FourthChoiceOptionId = new SelectList(option, "OptionId", "Title", choice.FourthChoiceOptionId);
            ViewBag.SecondChoiceOptionId = new SelectList(option, "OptionId", "Title", choice.SecondChoiceOptionId);
            ViewBag.ThirdChoiceOptionId = new SelectList(option, "OptionId", "Title", choice.ThirdChoiceOptionId);
            ViewBag.YearTermId = new SelectList(db.YearTerms, "YearTermId", "YearTermId", choice.YearTermId);
            ViewBag.StudentId = User.Identity.Name;

            var query = from a in db.YearTerms
                        where a.IsDefault.Equals(true)
                        select a;

            var term = query.FirstOrDefault();

            if (term.Term == 10)
            {
                ViewBag.YearTermCurrent = term.Year + " Winter";
            }
            else if (term.Term == 20)
            {
                ViewBag.YearTermCurrent = term.Year + " Spring/Summer";
            }
            else if (term.Term == 30)
            {
                ViewBag.YearTermCurrent = term.Year + " Fall";
            }

            ViewBag.YearId = term.Term;
            return View(choice);
        }

        // GET: Choices/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = db.Choices.Find(id);
            if (choice == null)
            {
                return HttpNotFound();
            }
            var option = from a in db.Options
                         where a.IsActive.Equals(true)
                         select a;

            ViewBag.FirstChoiceOptionId = new SelectList(option, "OptionId", "Title", choice.FirstChoiceOptionId);
            ViewBag.FourthChoiceOptionId = new SelectList(option, "OptionId", "Title", choice.FourthChoiceOptionId);
            ViewBag.SecondChoiceOptionId = new SelectList(option, "OptionId", "Title", choice.SecondChoiceOptionId);
            ViewBag.ThirdChoiceOptionId = new SelectList(option, "OptionId", "Title", choice.ThirdChoiceOptionId);
            ViewBag.YearTermId = new SelectList(db.YearTerms, "YearTermId", "YearTermId", choice.YearTermId);
            return View(choice);
        }

        // POST: Choices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ChoiceId,YearTermId,StudentId,StudentFirstName,StudentLastName,FirstChoiceOptionId,SecondChoiceOptionId,ThirdChoiceOptionId,FourthChoiceOptionId,SelectionDate")] Choice choice)
        {
            var list = new List<int>();
            list.Add((int)choice.FirstChoiceOptionId);
            list.Add((int)choice.SecondChoiceOptionId);
            list.Add((int)choice.ThirdChoiceOptionId);
            list.Add((int)choice.FourthChoiceOptionId);

            if (list.Count != list.Distinct().Count())
            {
                ModelState.AddModelError("", "Cannot have duplicate options");
            }

            if (ModelState.IsValid)
            {
                db.Entry(choice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var option = from a in db.Options
                         where a.IsActive.Equals(true)
                         select a;
            ViewBag.FirstChoiceOptionId = new SelectList(option, "OptionId", "Title", choice.FirstChoiceOptionId);
            ViewBag.FourthChoiceOptionId = new SelectList(option, "OptionId", "Title", choice.FourthChoiceOptionId);
            ViewBag.SecondChoiceOptionId = new SelectList(option, "OptionId", "Title", choice.SecondChoiceOptionId);
            ViewBag.ThirdChoiceOptionId = new SelectList(option, "OptionId", "Title", choice.ThirdChoiceOptionId);
            ViewBag.YearTermId = new SelectList(db.YearTerms, "YearTermId", "YearTermId", choice.YearTermId);
            return View(choice);
        }

        // GET: Choices/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = db.Choices.Find(id);
            if (choice == null)
            {
                return HttpNotFound();
            }
            return View(choice);
        }

        // POST: Choices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Choice choice = db.Choices.Find(id);
            db.Choices.Remove(choice);
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
