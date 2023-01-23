using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.DataAccess;
using Microsoft.AspNetCore.Authorization;

namespace IdentityAjaxClient.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            return View();
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Id = id;
            return View();
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            //passing msg edit sucessfully to Index
            TempData["edtmsg"] = "Edit Successfully";
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.Id = id;
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            //passing msg delete sucessfully to Index
            TempData["delmsg"] = "Delete Successfully";
            return RedirectToAction(nameof(Index));
        }

        // private bool ProductExists(int id)
        // {
        //     return _context.Products.Any(e => e.ProductId == id);
        // }
    }
}
