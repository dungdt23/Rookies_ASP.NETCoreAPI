using Task = Rookies_ASP.NETCoreAPI.Infrastructure.Models.Task;


namespace Rookies_ASP.NETCoreAPI.Infrastructure.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetTasks();
        Task? GetTask(Guid id);
        int Add(Task task);
        int Update(Guid id, Task task);
        int Delete(Guid id);
        int BulkDelete(List<Guid> ids);
        int BulkAdd(List<Task> tasks);
    }
}
