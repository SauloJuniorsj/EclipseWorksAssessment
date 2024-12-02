using EclipseWorksAssessment.Application.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorksAssessment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        /// <summary>
        ///  Vizualiza todas as tarefas de um projeto específico
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet("{projectId}")]
        public ActionResult Get(int projectId)
        {
            return Ok();
        }
        [HttpPost]
        public ActionResult Post([FromBody] CreateTaskInputModel task)
        {
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] UpdateTaskInputModel task)
        {
            return Ok();
        }
    }
}
