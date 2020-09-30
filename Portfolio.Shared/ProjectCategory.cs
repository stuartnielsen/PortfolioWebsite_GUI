using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared
{
    public class ProjectCategory
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int CategoryId { get; set; }
        public Project Project { get; set; }
        public Category Category { get; set; }
    }
}