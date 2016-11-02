using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siro.Controller
{
    public class Factura
    {
        /// <summary>
        /// Variable que es asignada al nuevo registro
        /// </summary>
        public int? NuevoId { get; set; }
        public string MSG { get; set; }
        /// <summary>
        /// Metodo Utilizado para agragar un nuevo asiento contable
        /// </summary>
        /// <returns></returns>

        public Transacciones TransaccionRealizada { get; set; }
        public bool AgregarFactura(Transacciones transac, bool notaCredito)
        {
            //transac.FechaTransaccion = DateTime.Now;
            if (transac.DetallesTransaccione.Count() == 0)
            {
                MSG = "Seleccione Productos O Servicios";
                return false;
            }
            if (transac.FPagoUilizada.Count() == 0)
            {
                MSG = "Falta la forma de pago";
                return false;
            }            
            if(notaCredito)
            {
                transac.Monto = transac.Monto * -1;
                transac.MontoImpuestos = transac.MontoImpuestos * -1;
                transac.DetallesTransaccione.ToList().ForEach(f => { f.Monto = f.Monto * -1; f.ITBM = f.ITBM * -1; f.Total = f.Total * -1; });
            }               
            using (var context = new slEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Transacciones.Add(transac);
                        context.SaveChanges();
                        NuevoId = transac.IdTransaccion;
                        dbContextTransaction.Commit();
                        MSG = "Datos Guardados Correctamente!!";
                        TransaccionRealizada = transac;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        MSG = "Ocurrio un error: " + ex.Message;
                        return false;
                    }
                }
            }
        }
        public void Dispose()
        {
            db.Dispose();
        }
        slEntities db;
        public Factura()
        {
            db = new slEntities();
        }
        public Clientes Cliente(int idCliente)
        {
            return db.Clientes.SingleOrDefault(w => w.idCliente == idCliente);
        }
    }
}
