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
using WebApiProducts.Models;

namespace WebApiProducts.Controllers
{
    public class Product_TableController : ApiController
    {
        private Product_model db = new Product_model();

        // GET: api/Product_Table
        public IQueryable<Product_Table> GetProduct_Table()
        {
            return db.Product_Table;
        }

        // GET: api/Product_Table/5
        [ResponseType(typeof(Product_Table))]
        public IHttpActionResult GetProduct_Table(int id)
        {
            Product_Table product_Table = db.Product_Table.Find(id);
            if (product_Table == null)
            {
                return NotFound();
            }

            return Ok(product_Table);
        }

        // PUT: api/Product_Table/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct_Table(int id, Product_Table product_Table)
        {
          

            if (id != product_Table.Id)
            {
                return BadRequest();
            }

            db.Entry(product_Table).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product_TableExists(id))
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

        // POST: api/Product_Table
        [ResponseType(typeof(Product_Table))]
        public IHttpActionResult PostProduct_Table(Product_Table product_Table)
        {
        

            db.Product_Table.Add(product_Table);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product_Table.Id }, product_Table);
        }

        // DELETE: api/Product_Table/5
        [ResponseType(typeof(Product_Table))]
        public IHttpActionResult DeleteProduct_Table(int id)
        {
            Product_Table product_Table = db.Product_Table.Find(id);
            if (product_Table == null)
            {
                return NotFound();
            }

            db.Product_Table.Remove(product_Table);
            db.SaveChanges();

            return Ok(product_Table);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Product_TableExists(int id)
        {
            return db.Product_Table.Count(e => e.Id == id) > 0;
        }
    }
}