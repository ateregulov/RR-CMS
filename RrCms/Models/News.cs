//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace RrCms.Models
{
    public partial class News
    {
        public int NewsId { get; set; }
        public int DisplayOrder { get; set; }
        public string Title { get; set; }
        public string MenuTitle { get; set; }
        public string HtmlDesription { get; set; }
        public string HtmlKeywords { get; set; }
        public string FriendlyUrl { get; set; }
        public string Text { get; set; }
        public string TextMain { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public bool IsDraft { get; set; }
    }
    
}
