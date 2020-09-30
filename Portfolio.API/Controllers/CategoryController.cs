using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Data;
using Portfolio.Shared;

namespace Portfolio.Api.Controllers
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
        [HttpPost("[action]/{category}")]
        public async Task Add(string category)
        {
            var newCategory = new Category()
            {
                Name = category
            };
            await repository.AddCategoryAsync(newCategory);
        }
    }
}