using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class PruebaSeleccionResponse
    {

        public string Descripcion { get; set; }       
        public int IdAspirante { get; set; }  
        public DateTime FechaInicio { get; set; }
        public DateTime? Fechafinalizacion { get; set; }
        public string? LenguajeEvaluar { get; set; }
        public int? CantidadPreguntas { get; set; }      
        public int IdTipoPrueba { get; set; }      
        public int IdNivelPruebas { get; set; }            
        public int IdEstadoPrueba { get; set; }        
        public decimal Calificacion { get; set; }
    }
}
