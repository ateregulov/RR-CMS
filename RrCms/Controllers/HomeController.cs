using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using RrCms.Common;
using RrCms.Models;
using RrCms.Models.ViewModels;

namespace RrCms.Controllers
{
	public class HomeController : Controller
	{
	    readonly ArticleEntities _articlesDb = new ArticleEntities();

		public ActionResult Index()
		{
		    var articles = GetLastArticles(5);

            return View(articles);
		}

		public ActionResult About()
		{
			return View();
		}

        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(ContacFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = new FeedBack();
                TryUpdateModel(model);
                model.CreateDate = DateTime.Now;

                using (var context = new FeedBackEntities())
                {
                    context.FeedBacks.Add(model);
                    context.SaveChanges();
                }

                new Thread(() =>
                {
                    try
                    {
                        var mailService = new EmailService();
                        var mesage = new MailMessage(viewModel.Email, "admin@mail.com", "Contact Us Message",
                                                             DateTime.Now.ToString() + ": " + viewModel.Message);
                        mailService.SendByGoogle(mesage);
                    }
                    catch (Exception)
                    {
                        //write into log
                    }

                }).Start();

                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        private List<Article> GetLastArticles(int count)
        {
            return _articlesDb.Articles
                .OrderByDescending(a => a.CreateDate)
                .ThenBy(a => a.DisplayOrder)
                .Where(a => a.IsDraft != true)
                .Take(count)
                .ToList();
        }
    }
}
