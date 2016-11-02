using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siro.Model
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string CedulaRuc { get; set; }
        public string NombreCompleto { get; set; }
        public Nullable<int> IdTipoCliente { get; set; }
        public Nullable<int> IdClaseCliente { get; set; }
        public Nullable<int> IdRepresentanteLegal { get; set; }
        public Nullable<int> IdProvincia { get; set; }
        public Nullable<int> IdDistrito { get; set; }
        public Nullable<int> IdCorregimiento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string TelefonoOficina { get; set; }
        public string TelefonoMovil { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> FechaCumpleaño { get; set; }
        public Nullable<int> idContacto { get; set; }
        public Nullable<decimal> LimiteCredito { get; set; }
        public Nullable<int> DiasMorosidad { get; set; }
        public string Comentarios { get; set; }
        public byte[] img { get; set; }
        public string Titulo { get; set; }
        public Nullable<System.DateTime> fechaCreacion { get; set; }
        public Nullable<bool> EsDiplomatico { get; set; }
        public Nullable<bool> EsProvedor { get; set; }
    }
}
