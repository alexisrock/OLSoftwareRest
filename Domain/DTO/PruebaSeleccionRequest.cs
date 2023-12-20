using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class PruebaSeleccionRequest
    {
        public string Descripcion { get; set; }
        public int IdAspirante { get; set; }          
        public string? LenguajeEvaluar { get; set; }     
        public int IdTipoPrueba { get; set; }
        public int IdNivelPruebas { get; set; }
        public List<PreguntasPruebaRequest> ListPreguntas { get; set; }

    }
}
