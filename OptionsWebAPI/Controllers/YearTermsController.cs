﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DiplomaDataModel;
using System.Collections;

namespace OptionsWebAPI.Controllers
{
    public class YearTermsController : ApiController
    {
        private DiplomaContext db = new DiplomaContext();

        // GET: api/YearTerms
        public IEnumerable GetYearTerms()
        {
            var yearterms = (from y in db.YearTerms.ToList() select new { YearTermId = y.YearTermId, Year = y.Year, Term = y.Term, IsDefault = y.IsDefault, Name = GetYearTermName(y.Term, y.Year) });

            return yearterms;
        }

        // GET: api/YearTerms/5
        [ResponseType(typeof(YearTerm))]
        public IHttpActionResult GetYearTerm(int id)
        {
            YearTerm yearTerm = db.YearTerms.Find(id);
            if (yearTerm == null)
            {
                return NotFound();
            }

            return Ok(yearTerm);
        }

        // PUT: api/YearTerms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutYearTerm(int id, YearTerm yearTerm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != yearTerm.YearTermId)
            {
                return BadRequest();
            }

            db.Entry(yearTerm).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YearTermExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/YearTerms
        [ResponseType(typeof(YearTerm))]
        public IHttpActionResult PostYearTerm(YearTerm yearTerm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.YearTerms.Add(yearTerm);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = yearTerm.YearTermId }, yearTerm);
        }

        // DELETE: api/YearTerms/5
        [ResponseType(typeof(YearTerm))]
        public IHttpActionResult DeleteYearTerm(int id)
        {
            YearTerm yearTerm = db.YearTerms.Find(id);
            if (yearTerm == null)
            {
                return NotFound();
            }

            db.YearTerms.Remove(yearTerm);
            db.SaveChanges();

            return Ok(yearTerm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool YearTermExists(int id)
        {
            return db.YearTerms.Count(e => e.YearTermId == id) > 0;
        }

        private string GetYearTermName(int term, int year) {
            if (term == 10) {
                return year + " - Winter";
            } else if (term == 20) {
                return year + " - Spring/Summer";
            } else {
                return year + " - Fall";
            }
        }
    }
}