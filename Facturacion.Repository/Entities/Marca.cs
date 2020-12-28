using System;

namespace Facturacion.Repository.Entities
{
    public partial class Marca
    {
        public Guid MarcaId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }
    }
}
