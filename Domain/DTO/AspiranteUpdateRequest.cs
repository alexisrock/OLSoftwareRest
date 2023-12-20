using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class AspiranteUpdateRequest: AspiranteRequest
    {
        public int Id { get; set; }        
        public int? IdUsuario { get; set; }         
    }
}
