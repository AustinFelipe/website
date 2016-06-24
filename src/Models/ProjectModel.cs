using System.Collections.Generic;

namespace AustinSite.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<TagModel> Tags { get; set; }
    }
}