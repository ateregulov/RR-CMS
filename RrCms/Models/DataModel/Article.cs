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

        public void AddUrl(int id, string url)
        {
            using (var ctx = new FriendlyUrlEntities())
            {

                FriendlyUrl friendlyUrl = new FriendlyUrl()
                {
                    FriendlyUrl1 = this.FriendlyUrl,
                    ContentId = this.id,
                    ControllerName = "Article",
                    ActionName = "Details"
                };
                ctx.FriendlyUrls.Add(friendlyUrl);
                ctx.SaveChanges();
            }

        }
    }
}