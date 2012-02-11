using System;
using System.Collections.Generic;
using System.Globalization;
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
		public ActionResult Index()
		{
		    var articles = GetLastArticles(5);

            return View(articles);
		}

		public ActionResult About()
		{
			return View();
		}

        #region News
        public ActionResult News()
        {
            return View(NewsRepository.GetAll());
        }

        public ActionResult Read(int id)
        {
            return View(NewsRepository.GetNewByID(id));
        }
        #endregion

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
                        MailMessage message;
                        using (var db = new AdminParamEntities())
                        {
                            message = new MailMessage(viewModel.Email,
                                                      db.AdminParams.First(p => p.Name == "adminemail").Value,
                                                      db.AdminParams.First(p => p.Name == "feedbacksubject").Value,
                                                      string.Format("From: {0}\nEmail: {1}\nDate: {2}\n\n{3}",
                                                                    model.FullName, model.Email, model.CreateDate, model.Message)
                                                       );
                        }
                        EmailService.SendMail(message);
                    }
                    catch (Exception)
                    {
                        //todo: Обработать ошибку отправки почты
                    }

                }).Start();

                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        private List<Article> GetLastArticles(int count)
        {
            var articlesDb = new ArticleEntities();
            
            return articlesDb.Articles
                .OrderByDescending(a => a.CreateDate)
                .ThenBy(a => a.DisplayOrder)
                .Where(a => a.IsDraft != true)
                .Take(count)
                .ToList();
        }
    }
}
