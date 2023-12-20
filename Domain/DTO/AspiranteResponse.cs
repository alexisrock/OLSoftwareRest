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
    public class AspiranteResponse
    {

        public int Id { get; set; }
        public string Nombres { get; set; }       
        public int IdTipoDocumento { get; set; }   
        public string NumDocumento { get; set; }  
        public string Telefono { get; set; }
        public string? Email { get; set; }
    }
}
