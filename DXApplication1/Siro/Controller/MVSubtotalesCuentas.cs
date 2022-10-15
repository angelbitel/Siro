using Siro.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Siro.Controller
{
    internal class MVSubtotalesCuentas
    {
        slContabilidad db;
        public MVSubtotalesCuentas() => db = new slContabilidad();
        List<Model.Acumulado> lstAcumula { get; set; }
        public string Mensaje { get; private set; }
        internal void Calcular(int idPeriodoFiscal)
        {
            lstAcumula = new List<Model.Acumulado>();
            db.Database.SqlQuery<Model.Acumulado>($"SELECT IdAcumuladoCuentas, Año, Mes, IdMaestroCuentas, Debito, Credito, ABS(ISNULL(Debito,0)) - ABS(ISNULL(Credito,0)) AS SubTotal, SaldoAnterior, Total, IdPeriodoFiscal FROM AcumuladosCuenta WHERE IdEmpresa = {Principal.Bariables.IdEmpresa.Id} ORDER BY  Año, Mes,IdMaestroCuentas").ToList().ForEach(f => lstAcumula.Add(f));

            lstAcumula.GroupBy(n => n.IdMaestroCuentas).Select(s => new { IdMaestroCuentas = s.Key }).ToList().ForEach(f =>
            {

                var lstAgrupaCuenta = lstAcumula.Where(w => w.IdMaestroCuentas == f.IdMaestroCuentas).ToList();
                for (int i = 0; i < lstAgrupaCuenta.Count; i++)
                {
                    if (i == 0)
                    {
                        lstAgrupaCuenta[i].SaldoAnterior = lstAgrupaCuenta[0].SubTotal ?? 0;
                        lstAgrupaCuenta[i].Total = lstAgrupaCuenta[0].SubTotal ?? 0;
                    }
                    else
                    {
                        lstAgrupaCuenta[i].SaldoAnterior = lstAgrupaCuenta[i - 1].Total ?? 0;
                        lstAgrupaCuenta[i].Total = lstAgrupaCuenta[i].SubTotal + (lstAgrupaCuenta[i - 1].Total ?? 0);
                    }
                }

            });
            using (var con = new SqlConnection(Settings.Default.CnnReport))
            {
                DataTable mappingTbl = ListToDataTable(lstAcumula.Where(w=> w.IdPeriodoFiscal == idPeriodoFiscal).ToList());
                con.Open();
                SqlCommand cmd = new SqlCommand("ProGetTableAcumulado", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AcumuladosCuenta", mappingTbl);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Mensaje = ex.Message;
                }
            }
        }
        public DataTable ListToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }

            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        internal async Task<bool> ReiniciarTablas(int idPeriodoFiscal)
        {
            try
            {
                await db.Database.ExecuteSqlCommandAsync($"ProReiniciarTablaAcumulacion {idPeriodoFiscal}, {Principal.Bariables.IdEmpresa.Id}");
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }
        }
        internal List<Model.PeriodoFiscal> LstPeriodoFiscal {
            get
            {
                return db.Database.SqlQuery<Model.PeriodoFiscal>("SELECT IdPeriodoFiscal, Desde, Hasta, Comentario FROM PeriodosFiscales").ToList();
            }
        }
    }
    //internal class Acumulado
    //{
    //    IdAcumuladoCuentas, Año, Mes, IdMaestroCuentas, Debito, Credito, SubTotal, SaldoAnterior, Total, Indice, IdPeriodoFiscal
    //}
}
