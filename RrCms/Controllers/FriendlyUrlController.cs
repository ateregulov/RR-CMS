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
        [NeedEditorRole]
        public ActionResult Index()
        {
            using (var db = new FriendlyUrlEntities())
            {
                return View(db.FriendlyUrls.ToList());
            }
        }

        //
        // GET: /FriendlyUrl/Create
        [NeedEditorRole]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /FriendlyUrl/Create
        [NeedEditorRole]
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
        [NeedEditorRole]
        public ActionResult Edit(int id)
        {
            using (var db = new FriendlyUrlEntities())
            {
                return View(db.FriendlyUrls.Find(id));
            }
        }

        //
        // POST: /FriendlyUrl/Edit/5
        [NeedEditorRole]
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
        [NeedEditorRole]
        public ActionResult Delete(int id)
        {
            using (var db = new FriendlyUrlEntities())
            {
                return View(db.FriendlyUrls.Find(id));
            }
        }

        //
        // POST: /FriendlyUrl/Delete/5
        [NeedEditorRole]
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
