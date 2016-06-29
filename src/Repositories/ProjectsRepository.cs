using System;
using System.Collections.Generic;
using System.Linq;
using AustinSite.Models;
using AustinSite.Utils;

namespace AustinSite.Repositories
{
    public class ProjectsRepository
    {
        public List<ProjectModel> Projects { get; set; } = new List<ProjectModel>
        {
            new ProjectModel 
            { 
                Id = 1, 
                Title = "iPsic - Encontre um psicólogo a qualquer hora",
                BuiltAt = new DateTime(2016, 02, 01),
                Tags = new List<string>
                {
                    "asp net core",
                    "postgres",
                    "c#",
                    "angular js"
                }
            },

            new ProjectModel
            {
                Id = 2,
                Title = "Neurando - We build websites",
                BuiltAt = new DateTime(2015, 04, 01),
                Tags = new List<string>
                {
                    "asp net mvc 4",
                    "boostrap",
                    "jquery",
                    "c#"
                }
            }
        };

        public List<ProjectModel> GetProjectList(string filter = "")
        {
            if (string.IsNullOrEmpty(filter))
                return Projects
                    .OrderByDescending(t => t.BuiltAt)
                    .ToList();

            var normalized = StringUtils.RemoveInvalidCharsAndNormalize(filter);

            return Projects
                .Where(t => t.Title.ToLower().Contains(filter) || t.Tags.Any(tag => tag.Contains(filter)))
                .OrderByDescending(t => t.BuiltAt)
                .ToList();
        }

        public ProjectModel GetProjectById(int id)
        {
            return Projects
                .Where(t => t.Id == id)
                .FirstOrDefault();
        }
    }
}