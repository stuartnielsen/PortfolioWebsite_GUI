using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared
{
    public class Platform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ProjectPlatform> ProjectPlatforms { get; set; }
        public Platform()
        {
            ProjectPlatforms = new List<ProjectPlatform>();
        }
    }
}
