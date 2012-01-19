using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RrCms.Models;

namespace RrCms.Controllers.Models
{
	public class RedirectManager
	{
		public static FriendlyUrl GetFriendlyUrlByUrl(string friendlyUrl)
		{
			FriendlyUrl page = null;

			using (var ctx = new FriendlyUrlEntities())
			{
				page = ctx.FriendlyUrls.SingleOrDefault(c => c.FriendlyUrl == friendlyUrl);
				
			}


			return null;
		}

	}


}