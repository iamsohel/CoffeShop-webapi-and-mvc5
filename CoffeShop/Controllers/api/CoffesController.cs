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
using CoffeShop.Models;

namespace CoffeShop.Controllers.api
{
    public class CoffesController : ApiController
    {
        private CoffeshopContext db = new CoffeshopContext();

        // GET api/Coffes
        public IQueryable<Coffe> GetCoffes()
        {
            return db.Coffes;
        }

        // GET api/Coffes/5
        [ResponseType(typeof(Coffe))]
        public IHttpActionResult GetCoffe(int id)
        {
            Coffe coffe = db.Coffes.Find(id);
            if (coffe == null)
            {
                return NotFound();
            }

            return Ok(coffe);
        }

        // PUT api/Coffes/5
        public IHttpActionResult PutCoffe(int id, Coffe coffe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coffe.Id)
            {
                return BadRequest();
            }

            db.Entry(coffe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoffeExists(id))
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

        // POST api/Coffes
        [ResponseType(typeof(Coffe))]
        public IHttpActionResult PostCoffe(Coffe coffe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coffes.Add(coffe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = coffe.Id }, coffe);
        }

        // DELETE api/Coffes/5
        [ResponseType(typeof(Coffe))]
        public IHttpActionResult DeleteCoffe(int id)
        {
            Coffe coffe = db.Coffes.Find(id);
            if (coffe == null)
            {
                return NotFound();
            }

            db.Coffes.Remove(coffe);
            db.SaveChanges();

            return Ok(coffe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoffeExists(int id)
        {
            return db.Coffes.Count(e => e.Id == id) > 0;
        }
    }
}