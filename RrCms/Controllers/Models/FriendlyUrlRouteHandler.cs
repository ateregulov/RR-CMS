using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Web.Routing;
using RrCms.Models;

namespace RrCms.Controllers.Models
{
	public class FriendlyUrlRouteHandler : MvcRouteHandler
	{
		private static readonly Regex TypicalLink = new Regex("^.+/.+(/.*)?");

		protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
		{
			var url = requestContext.HttpContext.Request.Path.TrimStart('/');

			if (!string.IsNullOrEmpty(url) && !TypicalLink.IsMatch(url))
			{
				FriendlyUrl page = RedirectManager.GetFriendlyUrlByUrl(url);
				if (page != null)
				{
					FillRequest(page.ControllerName,
						page.ActionName ?? "GetStatic",
						page.Id.ToString(),
						requestContext);
				}
			}

			return base.GetHttpHandler(requestContext);
		}


		/// <summary> Заполнение request-контекста данными о контроллере, экшне и параметрах </summary>
		private static void FillRequest(string controller, string action, string id, RequestContext requestContext)
		{
			if (requestContext == null)
			{
				throw new ArgumentNullException("requestContext");
			}

			requestContext.RouteData.Values["controller"] = controller;
			requestContext.RouteData.Values["action"] = action;
			requestContext.RouteData.Values["id"] = id;
		}
	}
}