﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace RrCms.Models
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class SimpleModelContainer : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new SimpleModelContainer object using the connection string found in the 'SimpleModelContainer' section of the application configuration file.
        /// </summary>
        public SimpleModelContainer() : base("name=SimpleModelContainer", "SimpleModelContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new SimpleModelContainer object.
        /// </summary>
        public SimpleModelContainer(string connectionString) : base(connectionString, "SimpleModelContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new SimpleModelContainer object.
        /// </summary>
        public SimpleModelContainer(EntityConnection connection) : base(connection, "SimpleModelContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Article> Articles
        {
            get
            {
                if ((_Articles == null))
                {
                    _Articles = base.CreateObjectSet<Article>("Articles");
                }
                return _Articles;
            }
        }
        private ObjectSet<Article> _Articles;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Articles EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToArticles(Article article)
        {
            base.AddObject("Articles", article);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="SimpleModel", Name="Article")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Article : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Article object.
        /// </summary>
        /// <param name="articleId">Initial value of the ArticleId property.</param>
        public static Article CreateArticle(global::System.Int32 articleId)
        {
            Article article = new Article();
            article.ArticleId = articleId;
            return article;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ArticleId
        {
            get
            {
                return _ArticleId;
            }
            set
            {
                if (_ArticleId != value)
                {
                    OnArticleIdChanging(value);
                    ReportPropertyChanging("ArticleId");
                    _ArticleId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ArticleId");
                    OnArticleIdChanged();
                }
            }
        }
        private global::System.Int32 _ArticleId;
        partial void OnArticleIdChanging(global::System.Int32 value);
        partial void OnArticleIdChanged();

        #endregion
    
    }

    #endregion
    
}
