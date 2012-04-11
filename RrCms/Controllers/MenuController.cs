﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RrCms.Models;

namespace RrCms.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/

        public ActionResult Index()
        {
            using (var db = new ArticleEntities())
            {
                var articles = db.Articles.OrderBy(x => x.DisplayOrder).ToList();
                foreach (Article article in articles)
                {
                    article.FriendlyUrl = article.GetUrl(article.ArticleId);
                }
                return PartialView(articles);
            }
                       
        }

    }
}
