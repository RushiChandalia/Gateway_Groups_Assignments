using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using NLog;
using productwebapi.Models;

namespace productwebapi.Controllers
{
    public class ProductsController : ApiController
    {

        Logger logger = LogManager.GetCurrentClassLogger();    //Created the object of logger
        private productApi_model db = new productApi_model();  //Created the object of database 

        // GET: api/Products
        //This function GETS all the products from database
        public IQueryable<Product> GetProducts()
        {
            logger.Info("GET products on" + DateTime.Now.ToString());
            return db.Products;
        }

        // GET: api/Products/5
        //This function GET the details of products 
        //parameter ID is passed through function
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            logger.Info("GET details of products(ID) on" + DateTime.Now.ToString());
            return Ok(product);
        }

        // PUT: api/Products/5
        //this function takes id as parameter
        //updates the selected product
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                logger.Info("PUT products on" + DateTime.Now.ToString());
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        //POST function to add product to database
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.Info("POST product on" + DateTime.Now.ToString());
            db.Products.Add(product);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            logger.Info("DELETE products on" + DateTime.Now.ToString());

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}