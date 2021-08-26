using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniJuegoRelog.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> Commit();
    }
}
