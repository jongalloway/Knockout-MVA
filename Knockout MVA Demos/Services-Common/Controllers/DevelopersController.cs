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
    public class DevelopersController : ApiController
    {
        private TrackerContext db = new TrackerContext();

        // GET: api/Developers
        public IQueryable<Developer> GetDevelopers()
        {
            return db.Developers;
        }

        // GET: api/Developers/5
        [ResponseType(typeof(Developer))]
        public IHttpActionResult GetDeveloper(int id)
        {
            Developer developer = db.Developers.Find(id);
            if (developer == null)
            {
                return NotFound();
            }

            return Ok(developer);
        }

        // PUT: api/Developers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeveloper(int id, Developer developer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != developer.ID)
            {
                return BadRequest();
            }

            db.Entry(developer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeveloperExists(id))
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

        // POST: api/Developers
        [ResponseType(typeof(Developer))]
        public IHttpActionResult PostDeveloper(Developer developer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Developers.Add(developer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = developer.ID }, developer);
        }

        // DELETE: api/Developers/5
        [ResponseType(typeof(Developer))]
        public IHttpActionResult DeleteDeveloper(int id)
        {
            Developer developer = db.Developers.Find(id);
            if (developer == null)
            {
                return NotFound();
            }

            db.Developers.Remove(developer);
            db.SaveChanges();

            return Ok(developer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeveloperExists(int id)
        {
            return db.Developers.Count(e => e.ID == id) > 0;
        }
    }
}