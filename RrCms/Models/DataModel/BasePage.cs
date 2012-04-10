using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RrCms.Models
{
    public abstract class BasePage
    {
        /// <summary>
        /// Имя Controller-а, который будет отвечать за вывод страницы
        /// </summary>
        protected abstract string ControllerName { get; }
        /// <summary>
        /// Имя Action-а, который будет отвечать за вывод страницы
        /// </summary>
        protected abstract string ActionName { get; }
        /// <summary>
        /// Идентификатор страницы с которым он будет храниться в базе FriendlyUrl
        /// </summary>
        protected abstract int id { get; }

        /// <summary>
        /// FriendlyUrl из базы FriendlyUrl
        /// </summary>
        public string FriendlyUrl
        {
            get
            {
                using (var ctx = new FriendlyUrlEntities())
                {
                    var row = ctx.FriendlyUrls.Where
                        (c => c.ContentId == this.id &&
                        c.ControllerName == ControllerName
                        && c.ActionName == ActionName).
                        //сортировка нужна на случай если в втаблице будет несколько записей относящихся к данной записи
                        OrderByDescending(c => c.Id).FirstOrDefault();
                    if (row != null)
                        return row.FriendlyUrl1;
                    return null;
                }
            }
            set
            {
                using (var ctx = new FriendlyUrlEntities())
                {
                    //удаление
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        var row = ctx.FriendlyUrls.FirstOrDefault(c => c.ContentId == this.id);
                        if (row != null)
                            ctx.FriendlyUrls.Remove(row);
                    }
                    //обновление
                    if (ctx.FriendlyUrls.Any(c => c.ContentId == this.id))
                    {
                        var row = ctx.FriendlyUrls.Where
                        (c => c.ContentId == this.id &&
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
                            ContentId = this.id,
                            ControllerName = ControllerName,
                            ActionName = ActionName
                        };
                        ctx.FriendlyUrls.Add(friendlyUrl);

                    }
                    ctx.SaveChanges();
                }
            }
        }
    }
}