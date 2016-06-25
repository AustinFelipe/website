using System;
using System.Collections.Generic;
using System.Linq;
using AustinSite.Models;
using AustinSite.Utils;

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

        public List<ArticleModel> GetArticlesByTitleAndTag(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                return Articles
                    .OrderByDescending(t => t.PublishedAt)
                    .ToList();

            var normalized = StringUtils.RemoveInvalidCharsAndNormalize(filter);

            return Articles
                .Where(t => t.Title.ToLower().Contains(filter) || t.Tags.Any(tag => tag.Contains(filter)))
                .OrderByDescending(t => t.PublishedAt)
                .ToList();
        }
    }
}