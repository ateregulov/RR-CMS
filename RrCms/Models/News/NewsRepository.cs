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

        public static bool Create(News news)
        {
            using (NewsEntities db = new NewsEntities())
            {
                try
                {
                    int len = 45;
                    if (news.Text.Length <= len)
                        news.TextMain = news.Text.Remove(len) + " ...";
                    else
                        news.TextMain = news.Text;
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

        public static bool Delete(News news)
        {
            using (NewsEntities db = new NewsEntities())
            {
                try
                {
                    db.Entry(news).State = System.Data.EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception) 
                {
                    return false;
                }
            }
        }

        public static bool Edit(News news)
        {
            using (NewsEntities db = new NewsEntities())
            {
                try
                {
                    db.Entry(news).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private string texttitle(string text)
        {
            return text;
        }
    }
}