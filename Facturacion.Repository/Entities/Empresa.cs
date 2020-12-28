using System;

namespace Facturacion.Repository.Entities
{
    public partial class Empresa
    {
        public Guid EmpresaId { get; set; }
        public Guid CompaniaId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Contacto { get; set; }
        public string Descripcion { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Telefono3 { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActulizacion { get; set; }
    }
}
