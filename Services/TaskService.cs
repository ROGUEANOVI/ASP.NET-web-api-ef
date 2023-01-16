using WebApiEF.DbContexts;
using WebApiEF.Models;

namespace WebApiEF.Services;

public class TaskService : ITaskService
{

  TaskContext dbContext;

  public TaskService(TaskContext _dbContext)
  {
    dbContext = _dbContext;
  }

  public IEnumerable<Models.Task> GetAll()
  {
    return dbContext.Tasks!;
  }

  public async System.Threading.Tasks.Task Save(Models.Task task)
  {
    task.TaskId = Guid.NewGuid();
    task.CreationDate = DateTime.Now;
    dbContext.Add(task);
    await dbContext.SaveChangesAsync();
  }

  public async  System.Threading.Tasks.Task edit(Models.Task task, Guid id)
  {
    var currentTask = dbContext.Tasks!.Find(id);
    if(currentTask != null)
    {
      currentTask.Title = task.Title;
      currentTask.Description = task.Description;
      currentTask.TaskPriority = task.TaskPriority;
      currentTask.CategoryId = task.CategoryId;
      
      await dbContext.SaveChangesAsync();
    }
  }

   public async  System.Threading.Tasks.Task Remove(Guid id)
  {
    var currentTask = dbContext.Tasks!.Find(id);
    if(currentTask != null)
    {
      dbContext.Remove(currentTask);
      await dbContext.SaveChangesAsync();
    }
  }

}

// public interface ITaskService
// {
//   IEnumerable<Models.Task> GetAll();
//   System.Threading.Tasks.Task Save(Models.Task task);
//   System.Threading.Tasks.Task edit(Models.Task task, Guid id);
//   System.Threading.Tasks.Task Remove(Guid id);
// }
