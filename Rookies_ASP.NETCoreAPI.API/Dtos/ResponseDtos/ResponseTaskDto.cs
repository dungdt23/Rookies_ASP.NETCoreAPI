using System.ComponentModel.DataAnnotations;

namespace Rookies_ASP.NETCoreAPI.API.Dtos
{
    public class ResponseTaskDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        public bool Status { get; set; }
    }
}
