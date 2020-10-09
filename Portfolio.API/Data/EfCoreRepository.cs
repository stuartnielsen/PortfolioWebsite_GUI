using Microsoft.EntityFrameworkCore;
using Portfolio.Shared;
using Portfolio.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Data
{
    public class EfCoreRepository : IRepository
    {
        private readonly ApplicationDbContext context;

        public EfCoreRepository(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<Project> Projects => context.Projects;
        public IQueryable<Language> Languages => context.Languages;

        public IQueryable<Platform> Platforms => context.Platforms;

        public IQueryable<Technology> Technologies => context.Technologies;

        public async Task SaveProjectAsync(ProjectViewModel projectViewModel)
        {
            var project = new Project()
            {
                Title = projectViewModel.Title,
                Requirements = projectViewModel.Requirements,
                Design = projectViewModel.Design,
                CompletionDate = projectViewModel.CompletionDate,
            };

            if (project.Id == 0)
            {
                project.Slug = project.Title.ToSlug();
                context.Projects.Add(project);
            }
            else
            {
                project.Slug = project.Title.ToSlug();
                context.Projects.Update(project);
            }
            //context.Projects.Add(project);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await context.Projects.FindAsync(id);
            context.Projects.Remove(project);
            await context.SaveChangesAsync();
        }

        public async Task UpdateProjectDetailsAsync(ProjectViewModel projectViewModel)
        {
            var project = new Project()
            {
                Id = projectViewModel.Id,
                Title = projectViewModel.Title,
                Requirements = projectViewModel.Requirements,
                Design = projectViewModel.Design,
                CompletionDate = projectViewModel.CompletionDate,
            };

            context.Projects.Update(project);
            await context.SaveChangesAsync();
        }

        //public async Task AddCategoryAsync(Category category)
        //{
        //    context.Categories.Add(category);
        //    await context.SaveChangesAsync();
        //}

        //public async Task AssignCategoryAsync(ProjectCategory projectCategory)
        //{
        //    context.ProjectCategories.Add(projectCategory);
        //    await context.SaveChangesAsync();
        //}

        public async Task AssignCategoryAsync(AssignRequest assignRequest)
        {
            switch (assignRequest.CategoryType)
            {
                case Project.LanguageCategory:
                    var language = await context.Languages.FirstOrDefaultAsync(l => l.Name == assignRequest.Name);
                    if (language == null)
                    {
                        language = new Language { Name = assignRequest.Name };
                        context.Languages.Add(language);
                        await context.SaveChangesAsync();
                    }
                    var lc = new ProjectLanguage
                    {
                        ProjectId = assignRequest.ProjectId,
                        LanguageId = language.Id
                    };
                    context.ProjectLanguages.Add(lc);
                    await context.SaveChangesAsync();
                    break;

                case Project.PlatformCategory:
                    var platform = await context.Platforms.FirstOrDefaultAsync(p => p.Name == assignRequest.Name);
                    if (platform == null)
                    {
                        platform = new Platform { Name = assignRequest.Name };
                        context.Platforms.Add(platform);
                        await context.SaveChangesAsync();
                    }
                    var platformCategory = new ProjectPlatform
                    {
                        ProjectId = assignRequest.ProjectId,
                        PlatformId = platform.Id
                    };
                    context.ProjectPlatforms.Add(platformCategory);
                    await context.SaveChangesAsync();
                    break;

                case Project.TechnologyCategory:
                    var technology = await context.Technologies.FirstOrDefaultAsync(t => t.Name == assignRequest.Name);
                    if (technology == null)
                    {
                        technology = new Technology { Name = assignRequest.Name };
                        context.Technologies.Add(technology);
                        await context.SaveChangesAsync();
                    }
                    var technologyCategory = new ProjectTechnology
                    {
                        ProjectId = assignRequest.ProjectId,
                        TechnologyId = technology.Id
                    };
                    context.ProjectTechnologies.Add(technologyCategory);
                    await context.SaveChangesAsync();
                    break;

                default:
                    break;
            }
        }
    }
}
