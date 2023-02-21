using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tasks.Application.Requests;
using Tasks.Application.Services;

namespace Tasks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectRequest request)
        {
            await _projectService.CreateProjectAsync(request);
            return Ok();
        }
    }
}
