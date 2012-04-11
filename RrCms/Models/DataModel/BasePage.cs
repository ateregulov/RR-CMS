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
        public string FriendlyUrl { get; set; }
       
    }
}