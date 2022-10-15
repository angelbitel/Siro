using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siro.Controller
{
    internal class VMSesiones
    {
        slContabilidad db = new slContabilidad();
        internal string Msg { get; set; }
        internal int Id { get; set; }
        //var b = JsonConvert.DeserializeObject<Model.GastoNuevo>(movGasto.ClaseGatos);
        // JsonConvert.SerializeObject(Gasto[0]);
        internal bool GuardarSesion(DateTime fecha, string comentario,List<Model.AsientoContable> lstAsiento, string tipo, int idSesion)
        {
            var ls = new List<Model.DetalleAsientoCorto>();
            lstAsiento.ForEach(f =>{
                ls.Add(new Model.DetalleAsientoCorto
                {
                    Comentario = f.Comentario,
                    Credito = f.Credito,
                    CuentaContable = f.CuentaContable,
                    CuentasCombinadas = f.CuentasCombinadas,
                    Debito = f.Debito,
                    Detlle = f.Detlle,
                    Fecha = f.Fecha,
                    IdAsiento = f.IdAsiento,
                    IdBanco = f.IdBanco,
                    IdCliente = f.IdCliente,
                    IdColaborador = f.IdColaborador,
                    IdCuentaContable = f.IdCuentaContable,
                    IdDetalleAsiento = f.IdDetalleAsiento,
                    IdProveedor = f.IdProveedor,
                    IdUsuario = f.IdUsuario,
                    Mayor = f.Mayor,
                    Monto = f.Monto
                });
            });
            var b = JsonConvert.SerializeObject(ls);
            try
            {
                if (idSesion != 0)
                {
                    var sesio = db.SesionesAplicacion.SingleOrDefault(s => s.IdSesion == idSesion);
                    sesio.Fecha = fecha;
                    sesio.Comentario = comentario;
                    sesio.Sesion = b;
                    db.SaveChanges();
                }
                else
                {
                    var sesion = new SesionesAplicacion { Comentario = comentario, Fecha = fecha, IdUsuario = Principal.Bariables.IdUsuario, SeGuardo = false, Tipo = "Diario", Sesion = b };
                    db.SesionesAplicacion.Add(sesion);
                    db.SaveChanges();
                    Id = sesion.IdSesion;
                }
                return true;
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }
        }
        internal List<SesionesAplicacion> SesionesAbiertas => db.SesionesAplicacion.Where(w => w.SeGuardo == false && w.IdUsuario == Principal.Bariables.IdUsuario).ToList();
        internal bool ActualizarSesion(int idSesion)
        {
            try
            {
                var sesion = db.SesionesAplicacion.SingleOrDefault(s=> s.IdSesion == idSesion);
                if (sesion != null)
                {
                    sesion.SeGuardo = true;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }
        }
    }
}
