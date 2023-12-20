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
    [Table("TblAspirante")]
    public class Aspirante: BaseEntities
    {
        [Required]
        public string Nombres { get; set; }
        [Required]
        [ForeignKey("TipoDocumento")]
        public int IdTipoDocumento { get; set; }
        [ForeignKey("IdTipoDocumento")]
        public TipoDocumento TipoDocumento { get; set; }
        [Required]
        public string NumDocumento { get; set; }
        [Required]
        public string Telefono { get; set; }
        public string? Email { get; set; }

    }
}
