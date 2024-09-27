using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siro.Controller
{
    class HoraTrabjada
    {/// <summary>
        /// Variable que es asignada al nuevo registro
        /// </summary>
        public int? NuevoId { get; set; }
        public string MSG { get; set; }
        /// <summary>
        /// Metodo Utilizado para agragar un nuevo asiento contable
        /// </summary>
        /// <returns></returns>
        public bool Guardar(HorasTrabajadas entidad)
        {
            entidad.FechaProceso = DateTime.Now;
            entidad.Procesado = false;

            using (var context = new slPlanilla())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (entidad.IdHoraTrabjada == 0)
                        {
                            context.HorasTrabajadas.Add(entidad);
                        }
                        else
                        {
                            context.Entry(entidad).State = EntityState.Modified;
                        }

                        context.SaveChanges();

                        NuevoId = entidad.IdHoraTrabjada;
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
}
