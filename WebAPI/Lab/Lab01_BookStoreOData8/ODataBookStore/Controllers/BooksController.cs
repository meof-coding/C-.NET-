using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using ODataBookStore.EDM;

namespace ODataBookStore.Controllers
{
    public class BooksController : ODataController
    {
        private BookStoreContext db;

        public BooksController(BookStoreContext context)
        {
            db = context;
            db.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
            if (context.Books.Count() == 0)
            {
                foreach (var b in DataSource.GetBooks())
                {
                    context.Books.Add(b);
                    context.Presses.Add(b.Press);
                }
                context.SaveChanges();
            }
        }

        //[EnableQuery(PageSize =2)]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(db.Books);
        }

        //Put
        [EnableQuery]
        public IActionResult Patch([FromODataUri] int key,
            [FromBody] Book book
            //Delta<Book> book
            )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingBook = db.Books.FindAsync(key);
            if (existingBook == null)
            {
                return NotFound();
            }
            db.Update<Book>(book);

            //book.Patch(existingBook);
            try
            {
                db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Updated(existingBook);
        }

        [EnableQuery]
        public IActionResult Get(int key, string version)
        {
            //include press in book
            return Ok(db.Books.Include(c => c.Press).FirstOrDefault(c => c.Id == key));
        }

        [EnableQuery]
        public IActionResult Post([FromBody] Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return Created(book);
        }

        [EnableQuery]
        public IActionResult Delete([FromODataUri] int key)
        {
            var book = db.Books.FirstOrDefault(b => b.Id == key);
            if (book == null)
            {
                return NotFound();
            }
            db.Books.Remove(book);
            db.SaveChanges();
            return Ok();
        }
    }
}
