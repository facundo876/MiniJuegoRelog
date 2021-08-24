using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniJuegoRelog.Modelos
{
    public class Tiempos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Tiempo { get; set; }

        [Required]
        public int ParticipanteId { get; set; }
        public Participante Participante { get; set; }

        public Tiempos() {}

        public Tiempos(int id, int tiempo, Participante participante, int participanteId) 
        {
            this.Id = id;
            this.Tiempo = tiempo;
            this.ParticipanteId = participanteId;
            this.Participante = participante;
        }
    }
}
