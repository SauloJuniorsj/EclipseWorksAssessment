using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorksAssessment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("GetAll/{userId}")]

        public async Task<ActionResult> GetAll(int userId)
        {
            var projects = await _projectService.GetAll(userId);
            return Ok(projects);
        }

        /// <summary>
        /// Retrieves a project by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the project to retrieve.</param>
        /// <returns>An IActionResult containing the retrieved project, or a 404 result if the project is not found.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var project = await _projectService.GetById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        /// <summary>
        /// Creates a new project based on the provided input model.
        /// </summary>
        /// <param name="createProject">The input model containing the project details.</param>
        /// <returns>An IActionResult indicating the result of the creation operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectInputModel createProject)
        {
            var Id = await _projectService.Create(createProject);

            return CreatedAtAction(nameof(GetById), new { id = Id }, createProject);
        }
    }
}
