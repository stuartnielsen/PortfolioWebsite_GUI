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
        public async Task<IEnumerable<Project>> Get() => await repository.Projects.ToListAsync();

        [HttpPost]
        public async Task Post(Project project)
        {
            await repository.SaveProjectAsync(project);
        }

        [HttpGet("projectdetails/{id}")]
        public IQueryable<Project> GetProjectDetailsById(int id)
        {
            return repository.Projects.Where(b => b.Id == id);
        }
        [HttpDelete]
        public async void DeleteProject(Project project)
        {
            await repository.DeleteProjectAsync(project);
        }

        [HttpPost("Update")]
        public async void UpdateProjectDetails(Project project)
        {
            await repository.UpdateProjectDetailsAsync(project);
        }

    }
}
