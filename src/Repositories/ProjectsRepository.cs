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
                Company = "Neurando",
                Link = "http://www.ipsic.com.br",
                About = @"iPsic is a psychologist network that aims to reduce the gap between patients and therapists. 
This project is entirely built using new techs like asp net core. The project has a lot of useful tools either for professionals or patients. My job and the challenge in this project was use a brand new technology applying good practices in a tight deadline.",
                Length = "7 months",
                BuiltAt = new DateTime(2016, 02, 01),
                TechsAndTools = new List<string>
                {
                    "C#",
                    "Asp Net Core RC2",
                    "Microservices Structure",
                    "Angular JS",
                    "Vanilla JS",
                    "Bootstrap",
                    "Postgres",
                    "Ubuntu 14.04",
                    "Nginx",
                    "Digital Ocean",
                    "Visual Studio Code",
                    "OSX",
                    "Bash Script",
                    "SendGrid"
                },
                Tags = new List<string>
                {
                    "asp net core",
                    "postgres",
                    "c#",
                    "angular js"
                },
                FlickrAlbumUrl = "https://www.flickr.com/photos/144570475@N04/albums/72157670369440425",
                FlickrFirstPhotoUrl = "https://c2.staticflickr.com/8/7386/27355436033_80e2e0bd39_c.jpg"
            },

            new ProjectModel
            {
                Id = 2,
                Title = "Neurando - Connecting Solutions",
                Company = "Neurando",
                Link = "http://www.neurando.com",
                About = "This project consists in a website that presents the company Neurando. In this project I was responsable to build a website using cutting edge technologies like Asp Net Core. In addition, Wordpress was used as a blog platform.",
                Length = "2 months",
                BuiltAt = new DateTime(2015, 04, 01),
                TechsAndTools = new List<string>
                {
                    "C#",
                    "Asp Net Core RC2",
                    "Wordpress",
                    "Bootstrap",
                    "Ubuntu 14.04",
                    "Nginx",
                    "Digital Ocean",
                    "Visual Studio Code",
                    "SendGrid"
                },
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