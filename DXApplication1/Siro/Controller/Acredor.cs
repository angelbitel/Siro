using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siro.Controller
{
    public class Acredor
    {/// <summary>
        /// Variable que es asignada al nuevo registro
        /// </summary>
        public int? NuevoId { get; set; }
        public string MSG { get; set; }
        /// <summary>
        /// Metodo Utilizado para agragar un nuevo asiento contable
        /// </summary>
        /// <returns></returns>
        public bool Guardar(Colaboradores entidad)
        {
            entidad.FechaIngreso = DateTime.Now;

            using (var context = new slPlanilla())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (entidad.IdColaborador == 0)
                            context.Colaboradores.Add(entidad);
                        else
                            context.Entry(entidad).State = EntityState.Modified;

                        context.SaveChanges();

                        NuevoId = entidad.IdColaborador;
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
        
        public List<Acredores> LstAcredores()
        {
            using (var context = new slPlanilla())
            {
                return context.Acredores.ToList();
            }
        }
    }
}
