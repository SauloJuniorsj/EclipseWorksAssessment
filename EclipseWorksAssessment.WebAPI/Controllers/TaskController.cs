using EclipseWorksAssessment.Application.InputModels;
using EclipseWorksAssessment.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorksAssessment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IProjectService _projectService;

        public TaskController(ITaskService taskService, IProjectService projectService)
        {
            _taskService = taskService;
            _projectService = projectService;
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

        /// <summary>
        /// Cria uma nova tarefa Status :"0 - Pendente" "1 - Em Andamento" "2 - Concluída" Prioridade : "0 - Baixa" "1 - Média" "2 - Alta"
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateTaskInputModel task)
        {
            var Id = await _taskService.CreateTask(task);

            return Ok(Id);
        }

        /// <summary>
        /// Atualiza uma tarefa Status :"0 - Pendente" "1 - Em Andamento" "2 - Concluída" Prioridade : "0 - Baixa" "1 - Média" "2 - Alta"
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateTaskInputModel task)
        {
            var result = await _taskService.Update(task);

            return Ok(result);
        }

        /// <summary>
        /// Deleta uma tarefa
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> Delete(int taskId)
        {
            await _taskService.Delete(taskId);
            return Ok();
        }
    }
}
