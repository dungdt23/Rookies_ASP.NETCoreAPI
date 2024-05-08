using AutoMapper;
using Rookies_ASP.NETCoreAPI.API.Dtos;
using Rookies_ASP.NETCoreAPI.API.Dtos.RequestDtos;
using Rookies_ASP.NETCoreAPI.Infrastructure.Repositories;
using Task = Rookies_ASP.NETCoreAPI.Infrastructure.Models.Task;

namespace Rookies_ASP.NETCoreAPI.API.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public int Add(RequestTaskDto taskDto)
        {
            var task = _mapper.Map<Task>(taskDto);
            task.Id = new Guid();
            return _taskRepository.Add(task);
        }
        public int BulkAdd(List<RequestTaskDto> taskDtos)
        {
            var tasks = _mapper.Map<List<Task>>(taskDtos);
            tasks.ForEach(task => task.Id = Guid.NewGuid());
            return _taskRepository.BulkAdd(tasks);
        }

        public int BulkDelete(List<Guid> ids)
        {
            return _taskRepository.BulkDelete(ids);
        }

        public int Delete(Guid id)
        {
            return _taskRepository.Delete(id);
        }

        public ResponseTaskDto? GetTask(Guid id)
        {
            var task = _taskRepository.GetTask(id);
            var taskDto = _mapper.Map<ResponseTaskDto>(task);
            return taskDto;
        }

        public IEnumerable<ResponseTaskDto> GetTasks()
        {
            var tasks = _taskRepository.GetTasks();
            var tasksDto = _mapper.Map<IEnumerable<ResponseTaskDto>>(tasks);
            return tasksDto;
        }

        public int Update(Guid id, RequestTaskDto taskDto)
        {
            var task = _mapper.Map<Task>(taskDto);
            return _taskRepository.Update(id, task);
        }
    }
}
