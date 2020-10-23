using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data;
using Portfolio.Shared;
using Portfolio.Shared.ViewModels;
using Microsoft.AspNetCore.SignalR.Protocol;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IRepository repository;
        //readonly RetryPolicy<HttpResponseMessage> httpRetryPolicy;

        public ProjectController(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            //httpRetryPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode).Retry(3); //why does async not work here? RetryAsync(3)
        }

        [HttpGet()]
        public async Task<List<ProjectViewModel>> Get()
        {
            return await repository.Projects
                .Include(p => p.ProjectLanguages)
                    .ThenInclude(pc => pc.Language)
                .Include(p => p.ProjectPlatforms)
                    .ThenInclude(pc => pc.Platform)
                .Include(p => p.ProjectTechnologies)
                    .ThenInclude(pc => pc.Technology)
                    .Select(p => new ProjectViewModel(p))
                .ToListAsync();
        }

        [HttpPost]
        [Authorize]
        public async Task Post(ProjectViewModel project)
        {
            await repository.SaveProjectAsync(project);
        }

        //[HttpGet("projectdetails/{id}")]
        //public async Task <ProjectViewModel> GetProjectDetailsById(int id)
        //{
        //    var project = await repository.Projects
        //       .Include(p => p.ProjectLanguages)
        //           .ThenInclude(pc => pc.Language)
        //        .Include(p => p.ProjectPlatforms)
        //            .ThenInclude(pc => pc.Platform)
        //        .Include(p => p.ProjectTechnologies)
        //            .ThenInclude(pc => pc.Technology)
        //           .FirstOrDefaultAsync(p => p.Id == id);
               
        //    return new ProjectViewModel(project);
        //}

        [HttpGet("projectdetails/{slug}")]
        public async Task<ProjectViewModel> GetProjectDetailsBySlug(string slug)
        {
            try
            {
                var project = await repository.Projects
                .Include(p => p.ProjectTechnologies)
                   .ThenInclude(pc => pc.Technology)
                .Include(p => p.ProjectPlatforms)
                   .ThenInclude(pc => pc.Platform)
               .Include(p => p.ProjectLanguages)
                   .ThenInclude(pc => pc.Language)
                    .FirstOrDefaultAsync(p => p.Slug == slug);
                return new ProjectViewModel(project);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("[action]/{id}")]
        public async Task DeleteProject(int id)
        {
            await repository.DeleteProjectAsync(id);
        }

        [HttpPost("Update")]
        public async Task UpdateProjectDetails(ProjectViewModel project)
        {
            await repository.UpdateProjectDetailsAsync(project);
        }

        [HttpPost("[action]")]
        public async Task Assign(AssignRequest assignRequest)
        {
            await repository.AssignCategoryAsync(assignRequest);
        }

    }
}
