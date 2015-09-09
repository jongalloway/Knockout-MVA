using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Services_Common.Models;

namespace Services_Common.Controllers
{
    public class BugsController : ApiController
    {
        private TrackerContext db = new TrackerContext();

        // GET: api/Bugs
        public IQueryable<Bug> GetBugs()
        {
            return db.Bugs;
        }

        // GET: api/Bugs/5
        [ResponseType(typeof(Bug))]
        public IHttpActionResult GetBug(int id)
        {
            Bug bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return NotFound();
            }

            return Ok(bug);
        }

        // PUT: api/Bugs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBug(int id, Bug bug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bug.ID)
            {
                return BadRequest();
            }

            db.Entry(bug).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BugExists(id))
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

        // POST: api/Bugs
        [ResponseType(typeof(Bug))]
        public IHttpActionResult PostBug(Bug bug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bugs.Add(bug);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bug.ID }, bug);
        }

        // DELETE: api/Bugs/5
        [ResponseType(typeof(Bug))]
        public IHttpActionResult DeleteBug(int id)
        {
            Bug bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return NotFound();
            }

            db.Bugs.Remove(bug);
            db.SaveChanges();

            return Ok(bug);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BugExists(int id)
        {
            return db.Bugs.Count(e => e.ID == id) > 0;
        }
    }
}