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

        [HttpGet("[action]")]
        public async Task DefaultData()
        {
            await repository.SaveProjectAsync(new Project
            {
                Title = "Project 1",
                Requirements = "Demonstrate APIs with a database"
            });


            await repository.SaveProjectAsync(new Project
            {
                Title = "Project 2",
                Requirements = "No, seriously. Do that."
            });
        }
    }
}
