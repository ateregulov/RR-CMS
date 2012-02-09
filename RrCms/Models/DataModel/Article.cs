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
    }
}