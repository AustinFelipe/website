using System;
using System.Collections.Generic;

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
            var days = new string[]
            {
                "Sunday",
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday"
            };

            var months = new string[]
            {
                "Jan",
                "Fev",
                "Mar",
                "Apr",
                "May",
                "Jun",
                "Jul",
                "Ago",
                "Set",
                "Out",
                "Nov",
                "Dez"
            };

            return $"{days[(int)PublishedAt.DayOfWeek]} {months[(int)PublishedAt.Month]} {PublishedAt.Day} {PublishedAt.Year}";
        }
    }
}