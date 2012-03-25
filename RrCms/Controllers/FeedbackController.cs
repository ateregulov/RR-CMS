using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RrCms.Controllers.Models;
using RrCms.Models;

namespace RrCms.Controllers
{
    public class FeedbackController : Controller
    {
        //
        // GET: /Feedback/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            using (var db = new FeedBackEntities())
            {
                return View(db.FeedBacks.ToList());
            }
        }

        //
        // GET: /Feedback/Delete/5
        [Authorize(Roles="Admin")]
        public ActionResult Delete(int id)
        {
            using (var db = new FeedBackEntities())
            {
                return View(db.FeedBacks.Find(id));
            }
        }

        //
        // POST: /Feedback/Delete/5
        [Authorize(Roles="Admin")]
        [HttpPost]
        public ActionResult Delete(int id, FeedBack feedBack)
        {
            try
            {
                using (var db = new FeedBackEntities())
                {
                    db.Entry(feedBack).State = EntityState.Deleted;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
