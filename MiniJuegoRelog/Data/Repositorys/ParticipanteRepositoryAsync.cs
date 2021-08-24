using Microsoft.EntityFrameworkCore;
using MiniJuegoRelog.Interfaces;
using MiniJuegoRelog.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniJuegoRelog.Data.Repositoriys
{
    public class ParticipanteRepositoryAsync : GenericRepositoryAsync<Participante>, IParticipanteRepositoryAsync
    {
        private readonly DbSet<Participante> _participante;
        public ParticipanteRepositoryAsync(ApplicatinDbContext dbContext) : base(dbContext)
        {
            this._participante = dbContext.Set<Participante>();
        }
    }
}
