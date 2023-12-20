using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OLSoftwareDBContext : DbContext
    {
        public OLSoftwareDBContext(DbContextOptions<OLSoftwareDBContext> options) : base(options) { }

        public virtual DbSet<Aspirante> Aspirante { get; set; }
        public virtual DbSet<EstadoPrueba> EstadoPrueba { get; set; }
        public virtual DbSet<NivelPrueba> NivelPrueba { get; set; }
        public virtual DbSet<PreguntasPrueba> PreguntasPrueba { get; set; }
        public virtual DbSet<PruebaSeleccion> PruebaSeleccion { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<TipoPrueba> TipoPrueba { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

    }
}
