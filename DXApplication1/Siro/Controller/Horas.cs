using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siro.Controller
{
    internal class Horas
    {
        public Horas()
        {
            db = new slContabilidad();
            dbE = new slEntities();
            dbP = new slPlanilla();
        }
        slContabilidad db;
        slEntities dbE;
        slPlanilla dbP;
        internal List<Model.ConfiguracionHoras> LstColumnaOrigen => dbP.Database.SqlQuery<Model.ConfiguracionHoras>(
             "SELECT IdCampo As Id, Origen, Destino from [Planilla].[ConfiguracionArchivoReloj]").ToList();
        public string Mensaje { get; private set; }

        private string Buscar(int tipo, List<VCuentasPrimarias> lst) => lst.SingleOrDefault(s => s.Tipo.Equals(tipo)) == null ? "" : lst.SingleOrDefault(s => s.Tipo.Equals(tipo)).Text;
        public bool Guardar(MaestroCuentas inf)
        {
            try
            {
                if (inf.IdMaestroCuenta != 0)
                    db.Entry(db.MaestroCuentas.Find(inf.IdMaestroCuenta)).CurrentValues.SetValues(inf);
                else
                    db.MaestroCuentas.Add(inf);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }
        internal List<Model.Factor> LstFactura
        {
            get
            {
                var lst = new List<Model.Factor>();
                dbP.Factores.ToList().ForEach(f => lst.Add(new Model.Factor { IdFactor = f.IdFactor, TipoFactor = f.TiposFactor.Factor, Factor1 = f.Factor, DescripcionFactor = f.DescripcionFactor }));
                return lst;
            }
        }
        internal List<DateTime> DiasFeriados
        {
            get
            {
                var dias = new List<DateTime>();
                // Add Panama public holidays for 2024 and 2025
                dias.AddRange(
                new DateTime[]
                {
                    // 2024 Public Holidays in Panama
                    new DateTime(2024, 1, 1),   // New Year's Day
                    new DateTime(2024, 1, 9),   // Martyrs' Day
                    new DateTime(2024, 2, 12),  // Carnival Monday
                    new DateTime(2024, 2, 13),  // Carnival Tuesday
                    new DateTime(2024, 4, 1),   // Holy Thursday
                    new DateTime(2024, 4, 2),   // Good Friday
                    new DateTime(2024, 5, 1),   // Labour Day
                    new DateTime(2024, 11, 3),  // Independence from Colombia
                    new DateTime(2024, 11, 4),  // National Flag Day
                    new DateTime(2024, 11, 5),  // Colon Day
                    new DateTime(2024, 11, 10), // Los Santos Uprising
                    new DateTime(2024, 11, 28), // Independence from Spain
                    new DateTime(2024, 12, 8),  // Mother's Day
                    new DateTime(2024, 12, 25), // Christmas Day

                    // 2025 Public Holidays in Panama
                    new DateTime(2025, 1, 1),   // New Year's Day
                    new DateTime(2025, 1, 9),   // Martyrs' Day
                    new DateTime(2025, 2, 24),  // Carnival Monday
                    new DateTime(2025, 2, 25),  // Carnival Tuesday
                    new DateTime(2025, 4, 17),  // Good Friday
                    new DateTime(2025, 5, 1),   // Labour Day
                    new DateTime(2025, 11, 3),  // Independence from Colombia
                    new DateTime(2025, 11, 4),  // National Flag Day
                    new DateTime(2025, 11, 5),  // Colon Day
                    new DateTime(2025, 11, 10), // Los Santos Uprising
                    new DateTime(2025, 11, 28), // Independence from Spain
                    new DateTime(2025, 12, 8),  // Mother's Day
                    new DateTime(2025, 12, 25)  // Christmas Day
                }
                );
                return dias;
            }
        }

        public int Id { get; set; }

        internal async Task<bool> EliminarHorasProcesadas(DateTime fecha)
        {
            try
            {
                using (var context = new slPlanilla())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var registros = await context.HorasTrabajadas
                                .Where(h => DbFunctions.TruncateTime(fecha) == DbFunctions.TruncateTime(h.FechaProceso))
                                .ToListAsync();
                            if (registros.Count() > 0)
                            {
                                Id = registros.Count();
                                context.HorasTrabajadas.RemoveRange(registros);
                                await context.SaveChangesAsync();
                                dbContextTransaction.Commit();
                            }
                            return true;
                        }
                        catch (Exception ex)
                        {
                            Mensaje = ex.Message;
                            dbContextTransaction.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }
    }
}
