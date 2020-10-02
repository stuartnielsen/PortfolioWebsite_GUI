using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Shared.ViewModels
{
    public class BasicProject
    {
        public BasicProject() { }
        //{
        //    Languages = new List<BasicLanguage>();
        //    Platforms = new List<PlatformViewModel>();
        //    Technologies = new List<TechnologyViewModel>();
        //}

        public BasicProject(Project p)
        {
            Id = p.Id;
            Title = p.Title;
            Requirements = p.Requirements;
            CompletionDate = p.CompletionDate;
            Design = p.Design;
            //Languages = new List<BasicLanguage>(p.ProjectLanguages.Select(pl => new BasicLanguage(pl.Language)));
            //Platforms = new List<PlatformViewModel>(p.ProjectPlatforms.Select(pp => new PlatformViewModel(pp.Platform)));
            //Technologies = new List<TechnologyViewModel>(p.ProjectTechnologies.Select(pt => new TechnologyViewModel(pt.Technology)));
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Requirements { get; set; }
        public string Design { get; set; }
        public DateTime CompletionDate { get; set; }
        //public IList<BasicLanguage> Languages { get; set; }
        //public IList<PlatformViewModel> Platforms { get; set; }
        //public IList<TechnologyViewModel> Technologies { get; set; }
    }
}

