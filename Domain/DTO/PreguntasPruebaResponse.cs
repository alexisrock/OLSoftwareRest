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
    public class PreguntasPruebaResponse
    {
        public string Pregunta { get; set; }
        public string Respueta { get; set; }       
        public int IdPruebaSeleccion { get; set; }
       
    }
}
