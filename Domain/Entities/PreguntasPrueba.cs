using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("TblPreguntasPrueba")]
    public class PreguntasPrueba : BaseEntities
    {
        [Required]
        public string Pregunta { get; set; }
        public string? Respueta { get; set; }
        [Required]
        [ForeignKey("PruebaSeleccion")]
        public int IdPruebaSeleccion { get; set; }
        [ForeignKey("IdPruebaSeleccion")]
        public PruebaSeleccion PruebaSeleccion { get; set; }

    }
}
