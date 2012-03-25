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
    [Authorize(Roles = "Admin")]
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
                news.CreateDate = DateTime.Now;
                news.EditDate = DateTime.Now;
                news.EditUser = User.Identity.Name;           
                if (NewsRepository.Create(news))
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
                news.Text = HttpUtility.UrlDecode(news.Text, System.Text.Encoding.Default);
                news.EditDate = DateTime.Now;
                news.EditUser = User.Identity.Name;
                if (NewsRepository.Edit(news))
                    return RedirectToAction("Index");
                else
                    return View(news);
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
            if (NewsRepository.Delete(NewsRepository.GetNewByID(id)))
                return RedirectToAction("Index");
            else
                return View(NewsRepository.GetNewByID(id));
        }
    }
}