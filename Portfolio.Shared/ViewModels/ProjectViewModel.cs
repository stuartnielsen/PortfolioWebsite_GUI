using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Shared.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel()
        {
            Languages = new List<BasicLanguage>();
            Platforms = new List<BasicPlatform>();
            Technologies = new List<BasicTechnology>();
        }

        public ProjectViewModel(Project p)
        {
            Id = p.Id;
            Title = p.Title;
            Requirements = p.Requirements;
            CompletionDate = p.CompletionDate;
            Design = p.Design;
            Languages = new List<BasicLanguage>(p.ProjectLanguages.Select(pl => new BasicLanguage(pl.Language)));
            Platforms = new List<BasicPlatform>(p.ProjectPlatforms.Select(pp => new BasicPlatform(pp.Platform)));
            Technologies = new List<BasicTechnology>(p.ProjectTechnologies.Select(pt => new BasicTechnology(pt.Technology)));
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Requirements { get; set; }
        public string Design { get; set; }
        public DateTime CompletionDate { get; set; }
        public IList<BasicLanguage> Languages { get; set; }
        public IList<BasicPlatform> Platforms { get; set; }
        public IList<BasicTechnology> Technologies { get; set; }
    }
}

