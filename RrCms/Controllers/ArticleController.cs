using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RrCms.Controllers.Models;
using RrCms.Models;

namespace RrCms.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/
        
        public ActionResult Index()
        {
            using (var db = new ArticleEntities())
            {
                return View(db.Articles.ToList());
            }
        }

        //
        // GET: /Article/Create
        [Authorize(Roles="Editor, Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Article/Create
        [Authorize(Roles = "Editor, Admin")]
        [HttpPost]
        public ActionResult Create(Article article)
        {
            string url = article.FriendlyUrl;
            try
            {
                using (var db = new ArticleEntities())
                {
                    article.CreateDate = DateTime.Now;
                    article.EditDate = DateTime.Now;
                    article.EditUser = User.Identity.Name;
                    article.Text = HttpUtility.UrlDecode(article.Text, System.Text.Encoding.Default);
                    db.Articles.Add(article);
                    db.SaveChanges();
                    
                    article.AddUrl(article.ArticleId, article.FriendlyUrl);
                    db.Entry(article).State = EntityState.Modified;
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
        // GET: /Article/Details/5

        public ActionResult Details(int id)
        {
            using (var db = new ArticleEntities())
            {
                return View(db.Articles.Find(id));
            }
        }

        //
        // GET: /Article/Edit/5
        [Authorize(Roles = "Editor, Admin")]
        public ActionResult Edit(int id)
        {
            using (var db = new ArticleEntities())
            {
                return View(db.Articles.Find(id));
            }
        }

        //
        // POST: /Article/Edit/5
        [Authorize(Roles = "Editor, Admin")]
        [HttpPost]
        public ActionResult Edit(int id, Article article)
        {
            try
            {
                using (var db = new ArticleEntities())
                {
                    article.EditDate = DateTime.Now;
                    article.EditUser = User.Identity.Name;
                    article.Text = HttpUtility.UrlDecode(article.Text, System.Text.Encoding.Default);
                    db.Entry(article).State = EntityState.Modified;
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
        // GET: /Article/Delete/5
        [Authorize(Roles = "Editor, Admin")]
        public ActionResult Delete(int id)
        {
            using (var db = new ArticleEntities())
            {
                return View(db.Articles.Find(id));
            }
        }

        //
        // POST: /Article/Delete/5
        [Authorize(Roles = "Editor, Admin")]
        [HttpPost]
        public ActionResult Delete(int id, Article article)
        {
            try
            {
                using (var db = new ArticleEntities())
                {
                    db.Entry(article).State = EntityState.Deleted;
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
