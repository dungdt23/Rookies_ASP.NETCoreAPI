using System.ComponentModel.DataAnnotations;

namespace Rookies_ASP.NETCoreAPI.API.Dtos.RequestDtos
{
    public class RequestTaskDto
    {
        [Required]
        public string Title { get; set; } = null!;
        public bool Status { get; set; }
    }
}
