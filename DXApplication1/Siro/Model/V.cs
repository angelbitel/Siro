using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siro.Model
{
    public class V
    {
        /// <summary>
        /// Cierra o no el formulario principal
        /// </summary>
        public bool HabilitarP { get; set; }

        /// <summary>
        /// Variable hace referencia a base datos
        /// </summary>
        public slEntities db { get; set; }

        /// <summary>
        /// IdUsuario
        /// </summary>
        public int IdUsuario { get; set; }
        public Model.Empresa IdEmpresa { get; set; }
        public DateTime PeridoContable { get; set; }
        public List<AsientoContable> Asiento { get; set; }

        public int IdCuentaProveedor { get; set; }
        public int IdCuentaCliente { get; set; }
        public int IdCuentaEmpleado { get; set; }
        public int IdCuentaItbm { get; set; }
        public int IdCuentaBanco { get; set; }
        public int IdCaja { get; set; }
        public int IdBancoCXC { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
    }
}
