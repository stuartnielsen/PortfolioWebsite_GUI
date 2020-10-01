using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portfolio.Shared
{
    public class Project
    {
        public const string LanguageCategory = "language";
        public const string PlatformCategory = "platform";
        public const string TechnologyCategory = "technology";

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("requirments")]
        public string Requirements { get; set; }

        [JsonPropertyName("design")]
        public string Design { get; set; }

        [JsonPropertyName("datecreated")]
        public DateTime CompletionDate { get; set; }

        [JsonPropertyName("categories")]
        public List<ProjectLanguage> ProjectLanguages { get; set; }

        [JsonPropertyName("categories")]
        public List<ProjectPlatform> ProjectPlatforms { get; set; }

        [JsonPropertyName("categories")]
        public List<ProjectTechnology> ProjectTechnologies { get; set; }
    }
}


