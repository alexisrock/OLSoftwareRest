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
    [Table("TblTipoPrueba")]
    public class TipoPrueba : BaseEntities
    {
        [Required]
        public string Descripcion { get; set; }

    }    
}
