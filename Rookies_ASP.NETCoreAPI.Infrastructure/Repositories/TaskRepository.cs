using Rookies_ASP.NETCoreAPI.Common;
using Task = Rookies_ASP.NETCoreAPI.Infrastructure.Models.Task;


namespace Rookies_ASP.NETCoreAPI.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public static IEnumerable<Task> _tasks;
        public TaskRepository()
        {
            _tasks = InitialTaskData();
        }
        public IEnumerable<Task> GetTasks()
        {
            return _tasks;
        }
        public Task? GetTask(Guid id)
        {
            return _tasks.FirstOrDefault(task => task.Id == id);
        }
        public int Add(Task task)
        {
            var taskList = _tasks.ToList();
            taskList.Add(task);
            if (taskList.Count > _tasks.Count())
            {
                _tasks = taskList;
                return ConstantsStatus.Success;
            }
            else return ConstantsStatus.Failed;
        }
        public int Update(Guid id, Task task)
        {
            var updateTask = _tasks.FirstOrDefault(task => task.Id == id);
            if (updateTask != null)
            {
                updateTask.Title = task.Title;
                updateTask.Status = task.Status;
                return ConstantsStatus.Success;
            }
            else return ConstantsStatus.Failed;
        }
        public int Delete(Guid id)
        {
            var deleteTask = _tasks.FirstOrDefault(task => task.Id == id);
            if (deleteTask != null)
            {
                var taskList = _tasks.ToList();
                if (taskList.Remove(deleteTask))
                {
                    _tasks = taskList;
                    return ConstantsStatus.Success;
                }
                else return ConstantsStatus.Failed;
            }
            else return ConstantsStatus.Failed;
        }
        public int BulkDelete(List<Guid> ids)
        {
            var taskList = _tasks.ToList();
            int numberOfRecordsRemoved = taskList.RemoveAll(task => ids.Contains(task.Id));
            if (numberOfRecordsRemoved == 0)
                return ConstantsStatusBulkDelete.NothingRemoved;
            else
            {
                _tasks = taskList;
                //compare number of records remove with number of input id
                if (numberOfRecordsRemoved == ids.Count())
                    return ConstantsStatusBulkDelete.AllRemoved;
                else
                    return ConstantsStatusBulkDelete.OnlyValidRemoved;
            }
        }
        public int BulkAdd(List<Task> tasks)
        {
            var taskList = _tasks.ToList();
            taskList.AddRange(tasks);
            if (taskList.Count > _tasks.Count())
            {
                _tasks = taskList;
                return ConstantsStatus.Success;
            }
            else return ConstantsStatus.Failed;
        }
        private IEnumerable<Task> InitialTaskData()
        {
            IEnumerable<Task> tasks = new List<Task>
            {
                new Task
                {
                    Id = Guid.NewGuid(),
                    Title = "Task1",
                    Status = true,
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Title = "Task2",
                    Status = false,
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Title = "Task3",
                    Status = true,
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Title = "Task4",
                    Status = false,
                },
                new Task
                {
                    Id = Guid.NewGuid(),
                    Title = "Task5",
                    Status = false,
                },
            };
            return tasks;
        }
    }
}
