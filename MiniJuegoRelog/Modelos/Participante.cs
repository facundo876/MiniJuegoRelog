using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniJuegoRelog.Modelos
{
    public class Participante
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de creación")]
        public DateTime? FechaCreacion { get; set; }

        public Participante() { }

        public Participante(int id, string name, string email, DateTime fechaCreacion) 
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.FechaCreacion = fechaCreacion;
        }
    }
}
