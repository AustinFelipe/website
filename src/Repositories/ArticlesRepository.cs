using System;
using System.Collections.Generic;
using AustinSite.Models;

namespace AustinSite.Repositories
{
    public class ArticlesRepository
    {
        public List<ArticleModel> Articles { get; set; } = new List<ArticleModel>
        {
            new ArticleModel 
            { 
                Id = 1, 
                Title = "Change Kestrel default url on Asp Net Core",
                PublishedAt = new DateTime(2016, 05, 26),
                Tags = new List<string>
                {
                    "asp net core",
                    "kestrel configuration",
                    "c#"
                },
                Link = "https://austinfelipe.wordpress.com/2016/05/26/change-kestrel-default-url-on-asp-net-core/" 
            }
        };
    }
}