using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RrCms.Controllers.Models
{
	public abstract class BaseController : Controller
	{
		/// <summary> Получение страницы из базы
		public virtual ActionResult GetStatic(int id)
		{
			return HttpNotFound();
		}

	}
}