using Microsoft.EntityFrameworkCore;
using Portfolio.Shared;
using Portfolio.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<ProjectViewModel> ProjectViewModels { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<ProjectLanguage> ProjectLanguages { get; set; }
        public DbSet<ProjectPlatform> ProjectPlatforms { get; set; }
        public DbSet<ProjectTechnology> ProjectTechnologies { get; set; }
    }
}
