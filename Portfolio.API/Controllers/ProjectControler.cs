using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data;
using Portfolio.Shared;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IRepository repository;

        public ProjectController(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet()]
        public async Task<IEnumerable<Project>> Get()
        //=> await repository.Projects.ToListAsync();
        {
            return await repository.Projects
                .Include(p => p.ProjectCategories)
                    .ThenInclude(pc => pc.Category)
                .ToListAsync();
        }

        [HttpPost]
        public async Task Post(Project project)
        {
            await repository.SaveProjectAsync(project);
        }

        [HttpGet("projectdetails/{id}")]
        public async Task <string> GetProjectDetailsById(int id)
        {
            var projects = await repository.Projects
               .Include(p => p.ProjectCategories)
                   .ThenInclude(pc => pc.Category)
               .ToListAsync();
            return $"Project Id: {id}";
        }
        [HttpDelete("[action]/{id}")]
        public async Task DeleteProject(int id)
        {
            await repository.DeleteProjectAsync(id);
        }

        [HttpPost("Update")]
        public async Task UpdateProjectDetails(Project project)
        {
            await repository.UpdateProjectDetailsAsync(project);
        }

        [HttpPost("[action]")]
        public async Task AssignCategory(ProjectCategory projectCategory)
        {
            await repository.AssignCategoryAsync(projectCategory);
        }

    }
}
