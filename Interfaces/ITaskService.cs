public interface ITaskService
{
  IEnumerable<WebApiEF.Models.Task> GetAll();
  System.Threading.Tasks.Task Save(WebApiEF.Models.Task task);
  System.Threading.Tasks.Task edit(WebApiEF.Models.Task task, Guid id);
  System.Threading.Tasks.Task Remove(Guid id);
}
