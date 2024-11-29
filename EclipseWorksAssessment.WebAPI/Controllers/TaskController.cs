using EclipseWorksAssessment.Application.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace EclipseWorksAssessment.WebAPI.Controllers
{
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

        // POST: ProjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }

        // GET: ProjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return Ok();
        }

        // POST: ProjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }
    }
}
