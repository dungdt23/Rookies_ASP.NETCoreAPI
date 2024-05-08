using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookies_ASP.NETCoreAPI.Infrastructure.Models
{
    public class Task
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        public bool Status { get; set; }
    }
}
