using Rookies_ASP.NETCoreAPI.API.Dtos;
using Rookies_ASP.NETCoreAPI.API.Dtos.RequestDtos;

namespace Rookies_ASP.NETCoreAPI.API.Services
{
    public interface ITaskService
    {
        IEnumerable<ResponseTaskDto> GetTasks();
        ResponseTaskDto? GetTask(Guid id);
        int Add(RequestTaskDto taskDto);
        int Update(Guid id, RequestTaskDto taskDto);
        int Delete(Guid id);
        int BulkDelete(List<Guid> ids);
        int BulkAdd(List<RequestTaskDto> taskDtos);
    }
}
