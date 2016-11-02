using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siro.Controller
{
    public class RA
    {
        //slEntities db;
        //slContabilidad db2;
        slSiro db3;
        public RA()
        {
            //db = new slEntities();
            //db2 = new slContabilidad();
            db3 = new slSiro();
        }
        public void Dispose()
        {
            //db.Dispose();
            //db2.Dispose();
            db3.Dispose();
        }
        public List<Model.EntradasSalidas> LstInventario(DateTime desde, DateTime hasta)
        {
            List<Model.EntradasSalidas> lstR = new List<Model.EntradasSalidas>();
             db3.Kardex.Where(w => DbFunctions.TruncateTime(w.Fecha) >= DbFunctions.TruncateTime(desde) && DbFunctions.TruncateTime(w.Fecha) <= DbFunctions.TruncateTime(hasta)).ToList().ForEach(f => {
                 lstR.Add(new Model.EntradasSalidas
                 {
                     IdAlmacen = f.IdAlmacen ?? 0,
                     Cantidad = f.Cantidad ?? 0,
                     Comentario = f.Comentario,
                     Fecha = f.Fecha ?? DateTime.Now,
                     IdInventario = f.IdInventario,
                     IdProducto = f.IdProducto ?? 1,
                     IdTipoMovimiento = f.IdTipoMovimiento ?? 1,
                     IdUser = Principal.Bariables.IdUsuario,
                     Modificado = false,
                     PorcentajeDesCuentoSilo = f.PorcentajeDescuentoSilo ?? 0m,
                     Precio = f.Precio ?? 0m,
                     Total = f.Total ?? 0m
                 });
            });
             return lstR;
        }
        public void Agregarkardex(Kardex kar)
        {
            var k = new Kardex { };
            using (var context = new slSiro())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (kar.IdInventario == 0)
                            context.Kardex.Add(kar);
                        else
                            context.Entry(kar).State = EntityState.Modified;
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        NuevoId = kar.IdInventario;
                        Ejecuto = true;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        MSG = "Ocurrio un error: " + ex.Message;
                        Ejecuto = false;
                    }
                }
            }

        }
        public bool Guardar(Siro.RA entidad)
        {
            using (var context = new slSiro())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (entidad.IdEntradaArroz == 0)
                            context.RA.Add(entidad);
                        else
                            context.Entry(entidad).State = EntityState.Modified;
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        int idK=0;
                        var sIdA = context.Kardex.SingleOrDefault(s => s.IdRa == entidad.IdEntradaArroz);
                        if (sIdA != null)
                            idK = sIdA.IdInventario;
                        Agregarkardex(new Kardex
                        {
                            Fecha = entidad.Fecha,
                            Cantidad = entidad.Neto,
                            IdRa = entidad.IdEntradaArroz,
                            IdTipoMovimiento = 5,
                            IdUser = Principal.Bariables.IdUsuario,
                            Precio = entidad.Total,
                            IdInventario=idK,
                            IdAlmacen = entidad.IdAlmacen
                        });

                        NuevoId = entidad.IdEntradaArroz;
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
        public bool Guardar(Siro.CicloAlmacenaje entidad)
        {
            using (var context = new slSiro())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (entidad.IdPeridoSilo == 0)
                            context.CicloAlmacenaje.Add(entidad);
                        else
                            context.Entry(entidad).State = EntityState.Modified;
                        context.SaveChanges();
                        dbContextTransaction.Commit();

                        NuevoId = entidad.IdPeridoSilo;
                        context.Kardex.Where(w => w.IdAlmacen == entidad.IdAlmacen && w.IdPeridoSilo == null).ToList().ForEach(f => {
                            f.IdPeridoSilo = entidad.IdPeridoSilo;
                        });
                        context.RA.Where(w => w.IdAlmacen == entidad.IdAlmacen && w.IdPeridoSilo == null).ToList().ForEach(f =>
                        {
                            f.IdPeridoSilo = entidad.IdPeridoSilo;
                        });
                        context.SaveChanges();
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
        public int MaxSilo()
        {
            var dt = db3.RA.Where(w1 => w1.EstaPilado == false).Min(m => m.Fecha)??DateTime.Now;
            var x = db3.RA.Where(w => w.Fecha.Value.Year == dt.Year && w.Fecha.Value.Month == dt.Month && w.Fecha.Value.Day == dt.Day).Select(s => new { s.IdAlmacen }).Take(1);
            var y = x.SingleOrDefault();
            if (y == null) return 1; else return y.IdAlmacen ?? 1;
        }
        public int NuevoId { get; set; }
        public string MSG { get; set; }
        public bool Ejecuto { get; set; }
        public VValoresAlmacenaje ValoresAlmacenaje(int idAlmacen)
        {
            return db3.VValoresAlmacenaje.SingleOrDefault(s => s.IdAlmacen == idAlmacen);
        }
    }
}
