using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Siro.Controller
{
    public class Diario
    {
        slEntities db;
        public void Dispose()
        {
            db.Dispose();
        }
        public Diario()
        {
            db = new slEntities();
        }
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
                decimal? d1 = asiento.DetalleAsientos.Sum(s => s.Debito);
                decimal? d2 = asiento.DetalleAsientos.Sum(s => s.Credito);
                MSG = "Sumatoria de debitos y los creditos no es igual";
                return false;
            }
            using (var context = new slContabilidad())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (asiento.IdAsiento == 0)
                            context.Asientos.Add(asiento);
                        else
                            context.Entry(asiento).State = EntityState.Modified;
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        NuevoId = asiento.IdAsiento;
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
    }
    /*
     * 
     * COLOCAR EN slEntities en caso de error cuando se regenera modelo
     public slEntities(DbConnection existingConnection, bool contextOwnsConnection)  
        : base(existingConnection, contextOwnsConnection){}
     * 
     */
}
