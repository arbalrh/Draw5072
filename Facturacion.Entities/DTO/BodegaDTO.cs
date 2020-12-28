using System;
using Facturacion.Entities.ViewModels;

namespace Facturacion.Entities.DTO
{
    public class BodegaDTO : GridTotal
    {
        public Guid BodegaId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Observaciones { get; set; }
    }
}
