//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RrCms.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Article
    {
        public int ArticleId { get; set; }
        public int DisplayOrder { get; set; }
        public string Title { get; set; }
        public string MenuTitle { get; set; }
        public string HtmlDesription { get; set; }
        public string HtmlKeywords { get; set; }
        public string Text { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool IsDraft { get; set; }
    }
}
