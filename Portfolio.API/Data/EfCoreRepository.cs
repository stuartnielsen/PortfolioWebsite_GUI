using Microsoft.EntityFrameworkCore;
using Portfolio.Shared;
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

        public async Task SaveProjectAsync(Project project)
        {
            //if (project.Id == 0)
            //{
            //    context.Projects.Add(project);
            //}
            //else
            //{
            //    context.Projects.Update(project);
            //}
            context.Projects.Add(project);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await context.Projects.FindAsync(id);
            context.Projects.Remove(project);
            await context.SaveChangesAsync();
        }

        public async Task UpdateProjectDetailsAsync(Project project)
        {
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
                default:
                    break;
            }
        }
    }
}
