using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ProjectLanguage> ProjectLanguages { get; set; }
        public Language()
        {
            ProjectLanguages = new List<ProjectLanguage>();
        }
    }
}
