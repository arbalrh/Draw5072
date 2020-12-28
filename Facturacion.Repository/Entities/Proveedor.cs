using System;


namespace Facturacion.Repository.Entities
{
    public partial class Proveedor
    {
        public Guid ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Email { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Fax { get; set; }
        public string Celular { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }
    }
}
