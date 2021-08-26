using Microsoft.EntityFrameworkCore;
using MiniJuegoRelog.Data.Repositoriys;
using MiniJuegoRelog.Interfaces;
using MiniJuegoRelog.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniJuegoRelog.Data.Repositorys
{
    public class TiemposRepositoryAsync : GenericRepositoryAsync<Tiempos>, ITiemposRepositoryAsync
    {
        private readonly DbSet<Tiempos> _tiempo;
        public TiemposRepositoryAsync(ApplicatinDbContext dbContext) : base(dbContext)
        {
            this._tiempo = dbContext.Set<Tiempos>();
        }
    }
}
