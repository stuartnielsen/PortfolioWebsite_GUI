using Portfolio.Shared;
using Portfolio.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Polly;
using Polly.Retry;

namespace Portfolio.BlazorWasm
{
    public class ProjectApiService
    {
        private readonly HttpClient client;
        readonly RetryPolicy<HttpResponseMessage> httpRetryPolicy;


        public ProjectApiService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<ProjectViewModel>> GetProjectsAsync()
        {
            var response = await client.GetAsync("api/project");
            return await client.GetFromJsonAsync<IEnumerable<ProjectViewModel>>("api/project");
            //httpRetryPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode).RetryAsync(3); //why does async not work here? RetryAsync(3)
        }

        public async Task SaveProjectAsync(ProjectViewModel project)
        {
            var response = await client.PostAsJsonAsync("api/project/update", project);
        }

        public async Task<ProjectViewModel> GetProjectByIDAsync(int id)
        {
            return await client.GetFromJsonAsync<ProjectViewModel>($"api/project/{id}");
        }
        public async Task RemoveProjectAsync(ProjectViewModel project)
        {
            await client.DeleteAsync($"/api/project/deleteproject/{project.Id}");
        }
        public async Task AddProjectAsync(ProjectViewModel project)
        {
            var response = await client.PostAsJsonAsync("/api/project", project);

        }
        public async Task AssignAsync(AssignRequest assignBody)
        {
            //var assignBody = new AssignRequest
            //{
            //    CategoryType = categoryType,
            //    Name = newName,
            //    ProjectId = projectId
            //};
            await client.PostAsJsonAsync($"api/project/assign/", assignBody);
        }

        public async Task<ProjectViewModel> GetProjectFromSlug(string Slug)
        {
            return await client.GetFromJsonAsync<ProjectViewModel>($"/api/project/projectdetails/{Slug}");
        }

        public async Task<IEnumerable<LanguageViewModel>> GetLanguages()
        {
            return await client.GetFromJsonAsync<IEnumerable<LanguageViewModel>>("/api/category/GetLanguages");
        }
        public async Task<IEnumerable<PlatformViewModel>> GetPlatforms()
        {
            return await client.GetFromJsonAsync<IEnumerable<PlatformViewModel>>("/api/category/GetPlatforms");
        }
        public async Task<IEnumerable<TechnologyViewModel>> GetTechnologies()
        {
            return await client.GetFromJsonAsync<IEnumerable<TechnologyViewModel>>("/api/category/GetTechnologies");
        }

    }
}