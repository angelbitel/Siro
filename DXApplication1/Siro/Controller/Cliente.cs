using Siro.Model;
using System.Collections.Generic;
using System.Linq;

namespace Siro.Controller
{
    public class Cliente
    {
        public Cliente()
        {
            CargarDatosClientes();
        }
        public List<ClienteMini> lstClientes = new List<ClienteMini>();
        private void CargarDatosClientes()
        {
            using (var dbContext = new Siro.slEntities())
            {
                dbContext.Clientes.Select(s => new { s.idCliente, s.NombreCompleto, s.CedulaRuc, s.IdPrecio }).OrderBy(o=>o.NombreCompleto).ToList().ForEach(f =>
                {
                    lstClientes.Add(new ClienteMini
                    {
                        CedulaRuc = f.CedulaRuc,
                        idCliente = f.idCliente,
                        NombreCompleto = f.NombreCompleto,
                        IdPrecio = f.IdPrecio??0
                    });
                });
            }
        }
    }
}
