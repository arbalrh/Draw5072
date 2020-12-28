using System;
using Facturacion.Entities.ViewModels;

namespace Facturacion.Entities.DTO
{
    public class ProductoDTO : GridTotal
    {
        public Guid ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int UnidadMedida { get; set; }
        public string UsuarioCreador { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }
        public Guid BodegaId { get; set; }
    }
}
