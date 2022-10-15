using System;
using System.Linq;

namespace Siro.Controller
{
    public class Diario
    {
        slEntities db;
        public void Dispose() => db.Dispose();
        public Diario() => db = new slEntities();
        internal Asientos Asiento(int? idAsiento) => new slContabilidad().Asientos.SingleOrDefault(s => s.IdAsiento == idAsiento);
        /// <summary>
        /// Variable que es asignada al nuevo registro
        /// </summary>
        public int? NuevoId { get; set; }
        public string MSG { get; set; }
        /// <summary>
        /// Metodo Utilizado para agragar un nuevo asiento contable
        /// </summary>
        /// <returns></returns>
        public bool AgregarAsiento(Asientos asiento)
        {
            asiento.FechaCreacion = DateTime.Now;
            if (asiento.DetalleAsientos.Count() == 0)
            {
                MSG = "Seleccione las cuentas";
                return false;
            }
            if(asiento.DetalleAsientos.Sum(s=> s.Debito) != asiento.DetalleAsientos.Sum(s=> s.Credito))
            {
                decimal? d1 = Math.Abs(asiento.DetalleAsientos.Sum(s => s.Debito)??0m);
                decimal? d2 = Math.Abs(asiento.DetalleAsientos.Sum(s => s.Credito)??0m);
                MSG = "Sumatoria de debitos y los creditos no es igual";
                return false;
            }
            int idDetalle = 0;
            using (var context = new slContabilidad())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (asiento.IdAsiento == 0 || asiento.DetalleAsientos.Sum(s=> s.IdDetalleAsiento)==0)
                            context.Asientos.Add(asiento);
                        else
                        {
                            var asien = context.Asientos.SingleOrDefault(s => s.IdAsiento == asiento.IdAsiento);
                            asien.Comentario = asiento.Comentario;
                            asien.Fecha = asiento.Fecha;
                            asien.FechaCreacion = asiento.FechaCreacion;
                            asien.IdEmpresa = asiento.IdEmpresa;
                            asien.IdFactura = asiento.IdFactura;
                            asien.IdOrigen = asiento.IdOrigen;
                            asien.IdRegistroBanco = asiento.IdRegistroBanco;
                            asien.IdTipoAsiento = asiento.IdTipoAsiento;
                            asien.IdTransaccion = asiento.IdTransaccion;
                            asien.IdUser = asiento.IdUser;
                            asien.Importante = asiento.Importante;

                            asiento.DetalleAsientos.ToList().ForEach(f =>
                            {
                                idDetalle++;
                                if ((f.IdAsiento??0) == 0 && asiento.IdAsiento > 0)
                                    f.IdAsiento = asiento.IdAsiento;
                                if (f.IdDetalleAsiento == 0)
                                {
                                    if ((f.Debito??0) + (f.Credito??0) > 0)
                                        context.DetalleAsientos.Add(f);
                                }
                                else
                                {
                                    var detOrdOriginal = context.DetalleAsientos.Find(f.IdDetalleAsiento);
                                    if (detOrdOriginal != null)
                                        context.Entry(detOrdOriginal).CurrentValues.SetValues(f);
                                    else
                                    {
                                        f.IdDetalleAsiento = 0;
                                        context.DetalleAsientos.Add(f);
                                    }
                                }
                            });
                        }
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        NuevoId = asiento.IdAsiento;
                        MSG = "Datos Guardados Correctamente!!";
                        return true;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        MSG = $"OCURRIO UN ERROR: {ex.Message} EN LA FILA: {idDetalle}";
                        return false;
                    }
                }
            }
        }
        public bool EliminarAsiento(int idAsiento)
        {
            using (var context = new slContabilidad())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.DetalleAsientos.Where(w => w.IdAsiento == idAsiento).ToList().ForEach(f => context.DetalleAsientos.Remove(f));
                        context.Asientos.Where(w => w.IdAsiento == idAsiento).ToList().ForEach(f => context.Asientos.Remove(f));
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
        public bool EliminarDetalleAsiento(int idDetalle)
        {
            using (var context = new slContabilidad())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var detalleAsiento = context.DetalleAsientos.SingleOrDefault(s => s.IdDetalleAsiento == idDetalle);
                        context.DetalleAsientos.Remove(detalleAsiento);
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
    }
    /*
     * 
     * COLOCAR EN slEntities en caso de error cuando se regenera modelo
     public slEntities(DbConnection existingConnection, bool contextOwnsConnection)  
        : base(existingConnection, contextOwnsConnection){}
     * 
     */
}
