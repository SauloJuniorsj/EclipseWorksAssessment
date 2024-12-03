using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Application.Services.Implementations;
using EclipseWorksAssessment.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorksAssessment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        /// <summary>
        ///  Vizualiza todas as tarefas de um projeto específico
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet("{taskId}")]
        public async Task<ActionResult> Get(int taskId)
        {
            var task = await _taskService.GetTaskById(taskId);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateTaskInputModel task)
        {
            var Id = await _taskService.CreateTask(task);

            return CreatedAtAction(nameof(Get), new { id = Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateTaskInputModel task)
        {
            var result = await _taskService.Update(task);

            return Ok(result);
        }
    }
}
