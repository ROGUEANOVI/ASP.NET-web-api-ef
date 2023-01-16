using WebApiEF.DbContexts;
using WebApiEF.Models;

namespace WebApiEF.Services;

public class CategoryService : ICategoryService
{
  TaskContext dbContext;

  public CategoryService(TaskContext _dbContext)
  {
    dbContext = _dbContext;
  }

  public IEnumerable<Category> GetAll()
  {
    return dbContext.Categories!;
  }
  
  public async System.Threading.Tasks.Task Save(Category category)
  {
    category.CategoryId = Guid.NewGuid();
    dbContext.Add(category);
    await dbContext.SaveChangesAsync();
  }

  public async  System.Threading.Tasks.Task edit(Category category, Guid id)
  {
    var currentCategory = dbContext.Categories!.Find(id);
    if(currentCategory != null)
    {
      currentCategory.Name = category.Name;
      currentCategory.Description = category.Description;
      currentCategory.Weight = category.Weight;
      
      await dbContext.SaveChangesAsync();
    }
  }

  public async  System.Threading.Tasks.Task Remove(Guid id)
  {
    var currentCategory = dbContext.Categories!.Find(id);
    if(currentCategory != null)
    {
      dbContext.Remove(currentCategory);
      await dbContext.SaveChangesAsync();
    }
  }
}

// public interface ICategoryService
// {
//   IEnumerable<Category> GetAll();
//   System.Threading.Tasks.Task Save(Category category);
//   System.Threading.Tasks.Task edit(Category category, Guid id);
//   System.Threading.Tasks.Task Remove(Guid id);
// }
