using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookies_ASP.NETCoreAPI.Common
{
    public static class ConstantsStatus
    {
        public static readonly int Success = 1;
        public static readonly int Failed = -1;
    }
    public static class ConstantsStatusBulkDelete
    {
        public static readonly int AllRemoved = 1;
        public static readonly int OnlyValidRemoved = 0;
        public static readonly int NothingRemoved = -1;
    }

}
