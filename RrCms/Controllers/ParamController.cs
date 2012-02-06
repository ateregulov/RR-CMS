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
    public class ParamController : Controller
    {
        //
        // GET: /Param/
        [NeedEditorRole]
        public ActionResult Index()
        {
            using (var db = new AdminParamEntities())
            {
                return View(db.AdminParams.ToList());
            }
        }
        
        //
        // GET: /Param/Edit/5
        [NeedEditorRole]
        public ActionResult Edit(int id)
        {
            using (var db = new AdminParamEntities())
            {
                return View(db.AdminParams.Find(id));
            }
        }

        //
        // POST: /Param/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, AdminParam param)
        {
            try
            {
                using (var db = new AdminParamEntities())
                {
                    db.Entry(param).State = EntityState.Modified;
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
