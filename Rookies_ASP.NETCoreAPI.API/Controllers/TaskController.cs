using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookies_ASP.NETCoreAPI.API.Dtos.RequestDtos;
using Rookies_ASP.NETCoreAPI.API.Services;
using Rookies_ASP.NETCoreAPI.Common;

namespace Rookies_ASP.NETCoreAPI.API.Controllers
{
    [Route("tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        public IActionResult GetTasks()
        {
            return Ok(_taskService.GetTasks());
        }
        [HttpGet("{id}")]
        public IActionResult GetTask(Guid id)
        {
            return Ok(_taskService.GetTask(id));
        }
        [HttpPost]
        public IActionResult Add(RequestTaskDto taskDto)
        {
            int status = _taskService.Add(taskDto);
            if (status == ConstantsStatus.Success)
            {
                return Ok("Create a new task successfully!");
            }
            else
            {
                return BadRequest("Create a new task failed!");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] RequestTaskDto taskDto)
        {
            int status = _taskService.Update(id, taskDto);
            if (status == ConstantsStatus.Success)
            {
                return Ok("Update task successfully!");
            }
            else
            {
                return BadRequest("Update task failed!");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            int status = _taskService.Delete(id);
            if (status == ConstantsStatus.Success)
            {
                return Ok("Delete task successfully!");
            }
            else
            {
                return BadRequest("Delete task failed!");
            }
        }
        [HttpPost("/bulk")]
        public IActionResult BulkAdd(List<RequestTaskDto> taskDtos)
        {
            int status = _taskService.BulkAdd(taskDtos);
            if (status == ConstantsStatus.Success)
            {
                return Ok("Create list new tasks successfully!");
            }
            else
            {
                return BadRequest("Create list new tasks failed!");
            }
        }
        [HttpDelete("/bulk")]
        public IActionResult BulkDelete(List<Guid> ids)
        {
            int status = _taskService.BulkDelete(ids);
            if (status == ConstantsStatus.Success)
            {
                return Ok("Delete list tasks successfully!");
            }
            else
            {
                return BadRequest("Delete list tasks failed!");
            }
        }
    }
}
