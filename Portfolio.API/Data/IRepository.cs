using Portfolio.Shared;
using Portfolio.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Data
{
    public interface IRepository
    {
        IQueryable<Project> Projects { get; }
        IQueryable<Language> Languages { get; }
        IQueryable<Platform> Platforms { get; }
        IQueryable<Technology> Technologies { get; }
        Task SaveProjectAsync(ProjectViewModel project);
        Task DeleteProjectAsync(int id);
        Task UpdateProjectDetailsAsync(ProjectViewModel project);
        Task AssignCategoryAsync(AssignRequest assignRequest);
    }
}
