using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class AspiranteRequest
    {
        public string Nombres { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string Telefono { get; set; }
        public string? Email { get; set; }
    }
}
