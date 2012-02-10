using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RrCms.Models;
using RrCms.Controllers.Models;

namespace RrCms.Controllers
{
    [NeedEditorRole]
    public class NewsController : Controller
    {        
        //
        // GET: /Default1/

        public ViewResult Index()
        {
            return View(NewsRepository.GetAll());
        }

        //
        // GET: /Default1/Details/5

        public ViewResult Details(int id)
        {            
            return View(NewsRepository.GetNewByID(id));
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                news.Text = HttpUtility.UrlDecode(news.Text, System.Text.Encoding.Default);
                if (NewsRepository.Create(news, User.Identity.Name))
                    return RedirectToAction("Index");
                else
                    return View(news);
            }

            return View(news);
        }
        
        //
        // GET: /Default1/Edit/5
 
        public ActionResult Edit(int id)
        {            
            return View(NewsRepository.GetNewByID(id));
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(news).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        //
        // GET: /Default1/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(NewsRepository.GetNewByID(id));
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = NewsRepository.GetNewByID(id);
            
            return RedirectToAction("Index");
        }
    }
}