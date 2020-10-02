using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Shared.ViewModels
{
    public class TechnologyViewModel
    {
        public TechnologyViewModel() { }
        public TechnologyViewModel(Technology technology)
        {
            Id = technology.Id;
            Name = technology.Name;
            Projects = technology.ProjectTechnologies
                        .Select(pt => new BasicProject(pt.Project))
                        .ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<BasicProject> Projects { get; set; }
    }
}

