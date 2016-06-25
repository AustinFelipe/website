using System;
using System.Collections.Generic;
using AustinSite.Utils;

namespace AustinSite.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime BuiltAt { get; set; }

        public List<string> Tags { get; set; }

        public string FormattedBuiltAt()
        {
            return DateFormatter.GetMonthYear(BuiltAt);
        }
    }
}