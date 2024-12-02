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
        public ActionResult Get(int taskId)
        {
            var task = _taskService.GetTaskById(taskId);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }
        [HttpPost]
        public ActionResult Post([FromBody] CreateTaskInputModel task)
        {
            var Id = _taskService.Create(task);

            return CreatedAtAction(nameof(Get), new { id = Id }, task);
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] UpdateTaskInputModel task)
        {
            return Ok();
        }
    }
}
