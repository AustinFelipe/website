using System;
using System.Collections.Generic;
using AustinSite.Utils;

namespace AustinSite.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PublishedAt { get; set; }

        public string Link { get; set; }

        public List<string> Tags { get; set; }

        public ArticleModel()
        {
            Tags = new List<string>();
        }

        public string FormattedPublishedAt()
        {
            return DateFormatter.GetFormattedDate(PublishedAt);
        }
    }
}