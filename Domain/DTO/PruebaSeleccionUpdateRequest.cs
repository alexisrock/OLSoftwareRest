using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class PruebaSeleccionUpdateRequest: PruebaSeleccionRequest
    {      
        public int IdEstadoPrueba { get; set; }
        public int Id { get; set; }
        public decimal Calificacion { get; set; }
        public int? IdUsuario { get; set; }
    }
}
