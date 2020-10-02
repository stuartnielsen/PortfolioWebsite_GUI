using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Shared.ViewModels
{
    public class LanguageViewModel
    {
        public LanguageViewModel() { }
        public LanguageViewModel(Language l)
        {
            Id = l.Id;
            Name = l.Name;
            //Projects = new List<Project>();
            //foreach (var projectLanguage in l.ProjectLanguages)
            //{
            //    Projects.Add(projectLanguage.Project);
            //}

            //Projects = (from pl in l.ProjectLanguages
            //           select pl.Project).ToList();

            Projects = l.ProjectLanguages
                        .Select(pl => new BasicProject(pl.Project))
                        .ToList();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<BasicProject> Projects { get; set; }
    }
}

