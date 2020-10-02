using Portfolio.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared
{
    public class ProjectLanguage
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        //public BasicProject BasicProject { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
