using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siro.Controller
{
    public class Cotizacion
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
        public bool Agregar(Cotizaciones transac)
        {
            transac.Fecha = DateTime.Now;
            if (transac.DetalleCotizacion.Count() == 0)
            {
                MSG = "Seleccione Productos O Servicios";
                return false;
            }


            using (var context = new slEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (transac.IdCotizacion == 0)
                            context.Cotizaciones.Add(transac);
                        else
                            context.Entry(transac).State = EntityState.Modified;
                        context.SaveChanges();
                        NuevoId = transac.IdCotizacion;
                        dbContextTransaction.Commit();
                        MSG = "Datos Guardados Correctamente!!";
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
        public BindingList<Model.DetalleTransaccion> BuscarCotizacion(int idCotizacion)
        {
            var lst = new BindingList<Model.DetalleTransaccion>();

            using (var context = new slEntities())
            {
                context.Cotizaciones.Where(w => w.IdCotizacion == idCotizacion).ToList().ForEach(f => {
                    f.DetalleCotizacion.ToList().ForEach(g => {
                        lst.Add(new Model.DetalleTransaccion
                        {
                            Cantidad = g.Cantidad,
                            IdCliente = f.idCliente ?? 0,
                            IdServicio = g.IdServicio,
                            Descripcion = g.Descripcion,
                            Monto = g.Monto,
                            ITBM = g.Itbm,
                            Total = g.Total
                        });
                    });
                });
            }
            return lst;
        }
    }
}
