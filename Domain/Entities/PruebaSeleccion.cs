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
    [Table("TblPruebaSeleccion")]
    public class PruebaSeleccion:  BaseEntities
    {

        [Required]
        public string Descripcion { get; set; }
        [Required]
        [ForeignKey("Aspirante")]
        public int IdAspirante { get; set; }
        [ForeignKey("IdAspirante")]
        public Aspirante Aspirante { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        public DateTime? Fechafinalizacion { get; set; }
        public string? LenguajeEvaluar { get; set; }
        public int? CantidadPreguntas { get; set; }
        [Required]
        [ForeignKey("TipoPrueba")]
        public int IdTipoPrueba { get; set; }
        [ForeignKey("IdTipoPrueba")]
        public TipoPrueba TipoPrueba { get; set; }
        [Required]
        [ForeignKey("NivelPrueba")]
        public int IdNivelPruebas { get; set; }
        [ForeignKey("IdNivelPruebas")]
        public NivelPrueba NivelPrueba { get; set; }
        [Required]
        [ForeignKey("EstadoPrueba")]
        public int IdEstadoPrueba { get; set; }
        [ForeignKey("IdEstadoPrueba")]
        public EstadoPrueba EstadoPrueba { get; set; }
        public decimal? Calificacion { get; set; }

    }
}
