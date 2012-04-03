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
    public class FriendlyUrlController : Controller
    {
        //
        // GET: /FriendlyUrl/
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Index()
        {
            using (var db = new FriendlyUrlEntities())
            {
                return View(db.FriendlyUrls.ToList());
            }
        }

        //
        // GET: /FriendlyUrl/Create
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /FriendlyUrl/Create
        [Authorize(Roles = "Admin, Editor")]
        [HttpPost]
        public ActionResult Create(FriendlyUrl url)
        {
            try
            {
                using (var db = new FriendlyUrlEntities())
                {
                    db.FriendlyUrls.Add(url);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /FriendlyUrl/Edit/5
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Edit(int id)
        {
            using (var db = new FriendlyUrlEntities())
            {
                return View(db.FriendlyUrls.Find(id));
            }
        }

        //
        // POST: /FriendlyUrl/Edit/5
        [Authorize(Roles = "Admin, Editor")]
        [HttpPost]
        public ActionResult Edit(int id, FriendlyUrl link)
        {
            try
            {
                using (var db = new FriendlyUrlEntities())
                {
                    db.Entry(link).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /FriendlyUrl/Delete/5
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Delete(int id)
        {
            using (var db = new FriendlyUrlEntities())
            {
                return View(db.FriendlyUrls.Find(id));
            }
        }

        //
        // POST: /FriendlyUrl/Delete/5
        [Authorize(Roles = "Admin, Editor")]
        [HttpPost]
        public ActionResult Delete(int id, FriendlyUrl link)
        {
            try
            {
                using (var db = new FriendlyUrlEntities())
                {
                    db.Entry(link).State = EntityState.Deleted;
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
