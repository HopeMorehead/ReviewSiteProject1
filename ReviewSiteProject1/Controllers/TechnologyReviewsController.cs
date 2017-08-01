using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReviewSiteProject1.Models;

namespace ReviewSiteProject1.Controllers
{
    public class TechnologyReviewsController : Controller
    {
        private ReviewSiteProject1Context db = new ReviewSiteProject1Context();

        // GET: TechnologyReviews
        public ActionResult Index()
        {
            var technologyReviews = db.TechnologyReviews.Include(t => t.Category);
            return View(technologyReviews.ToList());
        }

        // GET: TechnologyReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnologyReview technologyReview = db.TechnologyReviews.Find(id);
            if (technologyReview == null)
            {
                return HttpNotFound();
            }
            return View(technologyReview);
        }

        // GET: TechnologyReviews/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            return View();
        }

        // POST: TechnologyReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewID,Product,Description,Price,post,CategoryID")] TechnologyReview technologyReview)
        {
            if (ModelState.IsValid)
            {
                db.TechnologyReviews.Add(technologyReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", technologyReview.CategoryID);
            return View(technologyReview);
        }

        // GET: TechnologyReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnologyReview technologyReview = db.TechnologyReviews.Find(id);
            if (technologyReview == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", technologyReview.CategoryID);
            return View(technologyReview);
        }

        // POST: TechnologyReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewID,Product,Description,Price,post,CategoryID")] TechnologyReview technologyReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technologyReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", technologyReview.CategoryID);
            return View(technologyReview);
        }

        // GET: TechnologyReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnologyReview technologyReview = db.TechnologyReviews.Find(id);
            if (technologyReview == null)
            {
                return HttpNotFound();
            }
            return View(technologyReview);
        }

        // POST: TechnologyReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TechnologyReview technologyReview = db.TechnologyReviews.Find(id);
            db.TechnologyReviews.Remove(technologyReview);
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
