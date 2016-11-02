using System;
namespace Siro.Controller
{
    public class Banco
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
        public bool Agregar(RegistrosBanco entidad)
        {
            entidad.FechaRegistro = DateTime.Now;
            if (entidad.IdBanco == 0)
            {
                MSG = "Seleccione Banco";
                return false;
            }
            //if (entidad.IdCliente == 0)
            //{
            //    MSG = "Seleccione Cliente";
            //    return false;
            //}
            if (entidad.IdUser == 0)
            {
                MSG = "Seleccione Usuario";
                return false;
            }
            if (entidad.NumeroCheque.Trim() == string.Empty)
            {
                MSG = "Coloque Numero Cheque";
                return false;
            }
            if (entidad.Monto == 0)
            {
                MSG = "Coloque El Monto Del Cheque";
                return false;
            }
            using (var context = new slEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.RegistrosBanco.Add(entidad);
                        context.SaveChanges();
                        NuevoId = entidad.IdRegistroBanco;
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
