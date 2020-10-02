using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data;
using Portfolio.Shared.ViewModels;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository repository;

        public CategoryController(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("[action]")]
        public async Task<List<LanguageViewModel>> GetLanguages()
        {
            return await repository.Languages
                .Include(l => l.ProjectLanguages)
                .ThenInclude(pl => pl.Project)
                .Select(p => new LanguageViewModel(p))
                .ToListAsync();
        }

        [HttpGet("[action]")]
        public async Task<List<PlatformViewModel>> GetPlatforms()
        {
            return await repository.Platforms
                    .Select(p => new PlatformViewModel(p))
                .ToListAsync();
        }

        [HttpGet("[action]")]
        public async Task<List<TechnologyViewModel>> GetTechnologies()
        {
            return await repository.Technologies
                    .Select(p => new TechnologyViewModel(p))
                .ToListAsync();
        }

        [HttpGet("/language")]
        public async Task<List<LanguageViewModel>> GetLangaugesWithProjects()
        {
            return await repository.Languages
                .Include(l => l.ProjectLanguages)
                    .ThenInclude(pl => pl.Project)
                    .Select(p => new LanguageViewModel(p))
                .ToListAsync();
        }
    }
}
