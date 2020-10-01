using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared
{
    public class ProjectTechnology
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }
    }
}
