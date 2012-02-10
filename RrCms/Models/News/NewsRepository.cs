using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RrCms.Models;

namespace RrCms.Models
{
    public class NewsRepository
    {
        public static List<News> GetAll()
        {
            using(NewsEntities db = new NewsEntities())
            {
                try
                {
                    var result = db.News.OrderByDescending(x => x.CreateDate)
                        .ThenBy(x => x.DisplayOrder)
                        .Where(x => x.IsDraft != false)
                        .ToList();
                    if (result.Count > 0)
                        return result;
                    //var result = db.News.ToList();
                    //return result;
                }
                catch(Exception)
                {
                    return null;
                }
            }
            return null;
        }

        public static News GetNewByID(int id)
        {
            using(NewsEntities db = new NewsEntities())
            {
                try
                {
                   News news = db.News.Find(id);
                   return news;
                }
                catch (Exception)
                {
                    return null;
                }                
            }
        }

        public static bool Create(News news, string user)
        {
            using (NewsEntities db = new NewsEntities())
            {
                try
                {
                    news.CreateDate = DateTime.Now;
                    news.EditDate = DateTime.Now;
                    news.EditUser = user;                    

                    db.News.Add(news);                    
                    db.SaveChanges();
                    db.Dispose();
                }
                catch (Exception) 
                {
                    return false;
                }
            }
            return true;
        }

        public static void Delete(News news)
        {
            using (NewsEntities db = new NewsEntities())
            {
                try
                {
                    db.News.Remove(news);
                    db.SaveChanges();                    
                }
                catch (Exception) {}
            }
        }
    }
}