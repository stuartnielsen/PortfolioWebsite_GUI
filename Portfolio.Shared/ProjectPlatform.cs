using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared
{
    public class ProjectPlatform
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
