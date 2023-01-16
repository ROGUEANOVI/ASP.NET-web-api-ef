using Microsoft.AspNetCore.Mvc;
using WebApiEF.Models;
using WebApiEF.Services;

namespace WebApiEF.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase 
{

  ITaskService taskService;
  public TaskController( ITaskService _taskService)
  {
    taskService = _taskService;
  }

  [HttpGet]
  public IActionResult GetAll()
  {
    return Ok(taskService.GetAll());
  }

  [HttpPost]
  public IActionResult Post([FromBody] Models.Task task)
  {
    taskService.Save(task);
    return Ok();
  }

  [HttpPut("{id}")]
  public IActionResult Put([FromBody] Models.Task task, [FromRoute] Guid id)
  {
    taskService.edit(task, id);
    return Ok();
  }

  [HttpDelete("{id}")]
  public IActionResult Delete([FromRoute] Guid id)
  {
    taskService.Remove(id);
    return Ok();
  }

}