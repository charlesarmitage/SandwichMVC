using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SandwichChoices.net.Models;

namespace SandwichChoices.net.Controllers
{
    public class SandwichController : ApiController
    {
        private SandwichDbContext db = new SandwichDbContext();

        // GET api/Sandwich
        public IEnumerable<Sandwich> GetSandwiches()
        {
            return db.Sandwiches.AsEnumerable();
        }

        // GET api/Sandwich/5
        public Sandwich GetSandwich(int id)
        {
            Sandwich sandwich = db.Sandwiches.Find(id);
            if (sandwich == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return sandwich;
        }

        // PUT api/Sandwich/5
        public HttpResponseMessage PutSandwich(int id, Sandwich sandwich)
        {
            if (ModelState.IsValid && id == sandwich.ID)
            {
                db.Entry(sandwich).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Sandwich
        public HttpResponseMessage PostSandwich(Sandwich sandwich)
        {
            if (ModelState.IsValid)
            {
                db.Sandwiches.Add(sandwich);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, sandwich);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = sandwich.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Sandwich/5
        public HttpResponseMessage DeleteSandwich(int id)
        {
            Sandwich sandwich = db.Sandwiches.Find(id);
            if (sandwich == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Sandwiches.Remove(sandwich);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, sandwich);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}