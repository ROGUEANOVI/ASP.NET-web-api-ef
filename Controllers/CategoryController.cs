using Microsoft.AspNetCore.Mvc;
using WebApiEF.Models;
using WebApiEF.Services;

namespace WebApiEF.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
  ICategoryService categoryService;
  public CategoryController( ICategoryService _categoryService)
  {
    categoryService = _categoryService;
  }

  [HttpGet]
  public IActionResult GetAll()
  {
    return Ok(categoryService.GetAll());
  }

  [HttpPost]
  public IActionResult Post([FromBody] Category category)
  {
    categoryService.Save(category);
    return Ok();
  }

  [HttpPut("{id}")]
  public IActionResult Put([FromBody] Category category, [FromRoute] Guid id)
  {
    categoryService.edit(category, id);
    return Ok();
  }

  [HttpDelete("{id}")]
  public IActionResult Delete([FromRoute] Guid id)
  {
    categoryService.Remove(id);
    return Ok();
  }
}