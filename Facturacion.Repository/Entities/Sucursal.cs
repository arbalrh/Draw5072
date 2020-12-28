using System;


namespace Facturacion.Repository.Entities
{
    public partial class Sucursal
    {
        public Guid SucursalId { get; set; }
        public Guid CompaniaId { get; set; }
        public Guid EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string direccion { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Telefono3 { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }

    }
}
