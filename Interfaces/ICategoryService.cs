using WebApiEF.Models;

public interface ICategoryService
{
  IEnumerable<Category> GetAll();
  System.Threading.Tasks.Task Save(Category category);
  System.Threading.Tasks.Task edit(Category category, Guid id);
  System.Threading.Tasks.Task Remove(Guid id);
}