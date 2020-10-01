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
            Languages = new List<LanguageViewModel>();
            Platforms = new List<PlatformViewModel>();
            Technologies = new List<TechnologyViewModel>();
        }

        public ProjectViewModel(Project p)
        {
            Id = p.Id;
            Title = p.Title;
            Requirements = p.Requirements;
            CompletionDate = p.CompletionDate;
            Design = p.Design;
            Languages = new List<LanguageViewModel>(p.ProjectLanguages.Select(pl => new LanguageViewModel(pl.Language)));
            Platforms = new List<PlatformViewModel>(p.ProjectPlatforms.Select(pp => new PlatformViewModel(pp.Platform)));
            Technologies = new List<TechnologyViewModel>(p.ProjectTechnologies.Select(pt => new TechnologyViewModel(pt.Technology)));
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Requirements { get; set; }
        public string Design { get; set; }
        public DateTime CompletionDate { get; set; }
        public IList<LanguageViewModel> Languages { get; set; }
        public IList<PlatformViewModel> Platforms { get; set; }
        public IList<TechnologyViewModel> Technologies { get; set; }
    }
}

