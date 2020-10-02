using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared
{
    public class Technology
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ProjectTechnology> ProjectTechnologies { get; set; }
        public Technology()
        {
            ProjectTechnologies = new List<ProjectTechnology>();
        }
    }
}
