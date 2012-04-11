using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RrCms.Models
{
    public partial class Article : BasePage
    {
        protected override string ControllerName
        {
            get { return "Article"; }
        }

        protected override string ActionName
        {
            get { return "Details"; }
        }

        protected override int id
        {
            get { return ArticleId; }
        }

        public void AddUrl(int id, string value)
        {
            using (var ctx = new FriendlyUrlEntities())
            {
                //удаление
                if (string.IsNullOrWhiteSpace(value))
                {
                    var row = ctx.FriendlyUrls.FirstOrDefault(c => c.ContentId == id);
                    if (row != null)
                        ctx.FriendlyUrls.Remove(row);
                }
                //обновление
                if (ctx.FriendlyUrls.Any(c => c.ContentId == id))
                {
                    var row = ctx.FriendlyUrls.Where
                    (c => c.ContentId == id &&
                    c.ControllerName == ControllerName
                    && c.ActionName == ActionName).
                        //сортировка нужна на случай если в втаблице будет несколько записей относящихся к данной записи
                    OrderByDescending(c => c.Id).FirstOrDefault();
                    row.FriendlyUrl1 = value;
                    row.ControllerName = ControllerName;
                    row.ActionName = ActionName;
                }
                //добавление    
                else
                {

                    FriendlyUrl friendlyUrl = new FriendlyUrl()
                    {
                        FriendlyUrl1 = value,
                        ContentId = id,
                        ControllerName = ControllerName,
                        ActionName = ActionName
                    };
                    ctx.FriendlyUrls.Add(friendlyUrl);

                }
                ctx.SaveChanges();
            }



        }

        public string GetUrl(int id)
        {

            using (var ctx = new FriendlyUrlEntities())
            {
                var row = ctx.FriendlyUrls.Where
                    (c => c.ContentId == id &&
                    c.ControllerName == ControllerName
                    && c.ActionName == ActionName).
                    //сортировка нужна на случай если в втаблице будет несколько записей относящихся к данной записи
                    OrderByDescending(c => c.Id).FirstOrDefault();
                if (row != null)
                    return row.FriendlyUrl1;
                return null;
            }


        }
    }
}