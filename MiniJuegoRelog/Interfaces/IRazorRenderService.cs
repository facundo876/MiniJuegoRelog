using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniJuegoRelog.Interfaces
{
    public interface IRazorRenderService
    {
        Task<string> ToStringAsync<T>(string viewName, T model);
    }
}
