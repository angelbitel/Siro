using Siro.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Siro.Controller
{
    internal class VMContabilidad
    {
        slContabilidad db;
        public VMContabilidad() => db = new slContabilidad();
        internal Model.Notificacion ExisteNuevaCuenta(string cuenta)
        {
            if (cuenta == null)
                return new Notificacion();
            cuenta = cuenta.Trim();
            var notific = new Model.Notificacion { };
            var cuentas = db.MaestroCuentas.Where(w => w.CuentaContable == cuenta).ToList();
            if (cuentas.Count() > 0)
            {
                notific.Existe = true;
                notific.Titulo = "CUENTA EXISTENTE";
                notific.Mensaje = $"EL NUMERO DE CUENTA {cuenta}, HACE REFERENCIA A LA CUENTA [{cuentas[0].Text}]; LA MISMA APARECE ({cuentas.Count()}) VECES";
            }
            return notific;
        }
        internal List<VCuentasPrimarias> LstCuentasMadres => db.VCuentasPrimarias.ToList();
        internal List<Model.MaestroCuentas> Cuenta
        {
            get
            {
                var lst = new List<Model.MaestroCuentas>();
                db.MaestroCuentas.OrderBy(o => o.CuentaContable).ToList().ForEach(f =>
                {
                    var cuenta = Regex.Replace(f.CuentaContable, "[^0-9.]", "");
                    lst.Add(new Model.MaestroCuentas { Codigo = cuenta.Trim(), Cuenta = f.Text.Trim(), IdMaestroCuenta = f.IdMaestroCuenta });
                });
                return lst;
            }
        }
        internal List<Model.MaestroCuentas> CuentaMayor
        {
            get
            {
                var lst = new List<Model.MaestroCuentas>();
                db.Database.SqlQuery<MaestroCuentas>("SELECT * FROM Contabilidad.MaestroCuentas WHERE Nivel3 is null and Nivel4 is null and Nivel1 is not null and Nivel2 is not null ORDER BY CuentaContable").ToList().ForEach(f =>
                {
                    lst.Add(new Model.MaestroCuentas { Codigo = f.CuentaContable.Trim(), Cuenta = $"{f.CuentaContable.Trim()} > {f.Text.Trim()}", IdMaestroCuenta = f.IdMaestroCuenta });
                });
                return lst;
            }
        }
        internal List<Model.MaestroCuentas> CuentaMayorNomayor
        {
            get
            {
                var lst = new List<Model.MaestroCuentas>();
                db.Database.SqlQuery<MaestroCuentas>("SELECT * FROM Contabilidad.MaestroCuentas WHERE c3 is not null and c4 is not null ORDER BY CuentaContable").ToList().ForEach(f =>
                {
                    if(f.CuentaContable.Length >0)
                        lst.Add(new Model.MaestroCuentas { Codigo = f.CuentaContable.Trim(), Cuenta = $"{f.CuentaContable.Trim()} > {f.Text.Trim()}", IdMaestroCuenta = f.IdMaestroCuenta });
                });
                return lst;
            }
        }
        internal List<Model.MaestroCuentas> CuentaMayorNomayorResumen
        {
            get
            {
                var query = @"SELECT 
	                 A.CuentaContable, A.Text, A.IdMaestroCuenta,
	                 B.Text AS Nivel0,
	                 C.Text AS Nivel1
                FROM 
	                Contabilidad.MaestroCuentas A INNER JOIN
	                (SELECT IdMaestroCuenta, Text FROM Contabilidad.MaestroCuentas) B ON A.C1 = B.IdMaestroCuenta INNER JOIN
	                (SELECT  IdMaestroCuenta, Text FROM Contabilidad.MaestroCuentas) C ON A.C2 = C.IdMaestroCuenta
                WHERE A.c3 is not null and A.c4 is not null and A.Text is not null and A.Text != '' AND A.CuentaContable != ''
                ORDER BY CuentaContable";
                var lst = new List<Model.MaestroCuentas>();
                db.Database.SqlQuery<CuentaMayor>(query).ToList().ForEach(f =>
                {
                    if (f.CuentaContable.Length > 0)
                        lst.Add(new Model.MaestroCuentas { Codigo = f.CuentaContable.Trim(), Cuenta = $"{f.CuentaContable.Trim()} > {f.Text.Trim()}", IdMaestroCuenta = f.IdMaestroCuenta, Nivel1 = f.Nivel0, Nivel2 = f.Nivel1 });
                });
                return lst;
            }
        }
        internal List<ResumenCreditos> TransaccionesMayor(int anio, int mes, string cuenta)
        {
            var lst = new List<ResumenCreditos>();
            db.Database.SqlQuery<Mayor>($"SELECT A.Fecha, A.Comentario, Abs(B.Credito) AS Credito, Abs(B.Debito) AS Debito, A.IdAsiento FROM Contabilidad.Asientos A INNER JOIN Contabilidad.DetalleAsientos B ON A.IdAsiento = B.IdAsiento INNER JOIN Contabilidad.MaestroCuentas C ON B.IdMaestroCuenta = C.IdMaestroCuenta WHERE YEAR(A.Fecha) = {anio} AND MONTH(A.Fecha) = {mes}  AND C.IdMaestroCuenta = '{cuenta}' AND A.IdEmpresa ={Principal.Bariables.IdEmpresa.Id} ORDER BY Fecha")
                .ToList().ForEach(f =>
            {
                int mov = 1;
                if (f.Credito > 0)
                    mov = 2;
                var comen = f.Comentario.Split('|');
                lst.Add(new ResumenCreditos { IdTipoMovimiento = mov, Comentario= comen[0], Monto = (f.Debito ?? 0m) + (f.Credito ?? 0m), IdFactura = f.IdAsiento,Fecha = f.Fecha, Referencia = comen.Count()>1? comen[1]:"" });
            });
            return CalcularBalance(lst.Sum(s=> s.Pago),lst);
        }
        internal List<ResumenCreditos> TransaccionesMayor(DateTime desde, DateTime hasta, int cuenta)
        {
            var lst = new List<ResumenCreditos>();
            var query = $" ProObtenerAsientosMayor '{cuenta}', '{Principal.Bariables.IdEmpresa.Id}', '{desde.ToString("yyyyMMdd")}', '{hasta.ToString("yyyyMMdd")}'";
            db.Database.SqlQuery<ObtenerMayor>(query).ToList().ForEach(action: f => {
                int mov = 1;
                if (f.Credito > 0)
                    mov = 2;
                var comen = (f.Comentario ?? "").Split('|');
                var row = new ResumenCreditos { IdTipoMovimiento = mov, Comentario = comen[0], Monto = (f.Debito ?? 0m) + (f.Credito ?? 0m), IdFactura = f.IdAsiento, Fecha = f.Fecha, Referencia = comen.Count() > 1 ? comen[1] : "", BalanceMes = f.BalanceMes, TotalMoroso = f.Balance, Beneficiario = f.PagadoA };
                if (string.IsNullOrEmpty(row.Referencia))
                    row.Referencia = f.NumeroCheque;
                lst.Add(row);
            });
            return lst;
            //return CalcularBalance(lst.Sum(s => s.Pago), lst);
        }
        internal List<ResumenCreditos> TransaccionesMayorProcedure(DateTime desde, DateTime hasta, int cuenta)
        {
            var lst = new List<ResumenCreditos>();
            var query = $" ProObtenerAsientosMayor '{cuenta}', '{Principal.Bariables.IdEmpresa}', '{desde.ToString("yyyyMMdd")}', '{hasta.ToString("yyyyMMdd")}'";
            db.Database.SqlQuery<ObtenerMayor>(query).ToList().ForEach(action: f => {
                int mov = 1;
                if (f.Credito > 0)
                    mov = 2;
                var comen = (f.Comentario ?? "").Split('|');
                var row = new ResumenCreditos { IdTipoMovimiento = mov, Comentario = comen[0], Monto = (f.Debito ?? 0m) + (f.Credito ?? 0m), IdFactura = f.IdAsiento, Fecha = f.Fecha, Referencia = comen.Count() > 1 ? comen[1] : "", BalanceMes = f.BalanceMes, TotalMoroso = f.Balance, Beneficiario = f.PagadoA };
                if (string.IsNullOrEmpty(row.Referencia))
                    row.Referencia = f.NumeroCheque;
                lst.Add(row);
            });
            return lst;
            //return CalcularBalance(lst.Sum(s => s.Pago), lst);
        }
        internal List<Model.ResumenCreditos> TransaccionesMayor(DateTime desde, DateTime hasta, string cuenta)
        {
            var lst = new List<ResumenCreditos>();
            try
            {
                db.Database.SqlQuery<Mayor>($"SELECT A.Fecha, A.Comentario, Abs(B.Credito) AS Credito, Abs(B.Debito) AS Debito, A.IdAsiento FROM Contabilidad.Asientos A INNER JOIN Contabilidad.DetalleAsientos B ON A.IdAsiento = B.IdAsiento INNER JOIN Contabilidad.MaestroCuentas C ON B.IdMaestroCuenta = C.IdMaestroCuenta WHERE CONVERT(CHAR(8),A.Fecha,112) >= {desde.ToString("yyyyMMdd")} AND CONVERT(CHAR(8),A.Fecha,112) <= {hasta.ToString("yyyyMMdd")}  AND (C.C3 = '{cuenta}' OR C.C4 = {cuenta}) AND A.IdEmpresa ={Principal.Bariables.IdEmpresa.Id} ORDER BY Fecha")
                    .ToList().ForEach(f =>
                    {
                        int mov = 1;
                        if (f.Credito > 0)
                            mov = 2;
                        var comen = (f.Comentario??"").Split('|');
                        lst.Add(new ResumenCreditos { IdTipoMovimiento = mov, Comentario = comen[0], Monto = (f.Debito ?? 0m) + (f.Credito ?? 0m), IdFactura = f.IdAsiento, Fecha = f.Fecha, Referencia = comen.Count() > 1 ? comen[1] : "" });
                    });
            }
            catch (Exception)
            {
                new List<ResumenCreditos>();
            }
            return CalcularBalance(lst.Sum(s => s.Pago), lst);
        }
        private List<Model.ResumenCreditos> CalcularBalance(decimal valPAgo, List<Model.ResumenCreditos> lstCredito)
        {
            decimal? TotalMoroso = 0;
            decimal pago = valPAgo;
            for (int i = 0; i < lstCredito.Count; i++)
            {
                TotalMoroso += lstCredito[i].Deuda - lstCredito[i].Pago;
                lstCredito[i].TotalMoroso = TotalMoroso;

                if (new[] { 1, 4 }.Contains(lstCredito[i].IdTipoMovimiento))
                {
                    if (pago > 0)
                    {
                        if ((pago - lstCredito[i].Deuda) > lstCredito[i].Deuda)
                        {
                            lstCredito[i].MontoPagado = lstCredito[i].Deuda;
                            pago = pago - lstCredito[i].MontoPagado;
                        }
                        else
                        {
                            if (pago - lstCredito[i].Deuda > 0)
                            {
                                lstCredito[i].MontoPagado = lstCredito[i].Deuda;
                                pago = pago - lstCredito[i].MontoPagado;
                            }
                            else
                            {
                                lstCredito[i].MontoPagado = pago;
                                pago = pago - lstCredito[i].Deuda;
                            }
                        }
                    }
                    else
                        lstCredito[i].MontoPagado = 0;
                }
                if (i != 0)
                    lstCredito[i].SaldoAnterior = lstCredito[i - 1].TotalMoroso;
            }
            return lstCredito;
        }
        internal string Mensaje { get; private set; }
        internal int Id { get; set; }
        internal bool Guardar(MaestroCuentas inf)
        {
            try
            {
                if (inf.IdMaestroCuenta != 0)
                    db.Entry(db.MaestroCuentas.Find(inf.IdMaestroCuenta)).CurrentValues.SetValues(inf);
                else
                    db.MaestroCuentas.Add(inf);
                inf.Id = inf.Id;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }
        internal bool Guardar(MaestroContable f)
        {
            try
            {
                var inf = new MaestroCuentas { IdMaestroCuenta = f.IdMaestroCuenta, CuentaContable = f.CuentaContable, Habilitar = true, Text = f.Text, Nivel0 = f.Nivel0, Nivel1 = f.Nivel1, Nivel2 = f.Nivel2, Nivel3 = f.Nivel3, Nivel4 = f.Nivel4, Tipo = f.Tipo, EsBanco = f.EsBanco, C1 = f.C1, C2 = f.C2, C3 = f.C3, Nivel = f.Nivel, C4 = f.C4, IdEmpresa = f.IdEmpresa };
                if (f.IdMaestroCuenta != 0)
                {
                    var original = db.MaestroCuentas.Find(inf.IdMaestroCuenta);
                    if (original != null)
                        db.Entry(original).CurrentValues.SetValues(inf);
                }
                else
                    db.MaestroCuentas.Add(inf);
                db.SaveChanges();
                Id = f.IdMaestroCuenta;
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }
        internal bool Guardar(Model.MaestroCuentas f)
        {
            try
            {
                var inf = new MaestroCuentas { IdMaestroCuenta = f.IdMaestroCuenta, CuentaContable = f.Codigo, Habilitar = true, Text = f.Cuenta, Nivel0 = f.Nivel1, Nivel1 = f.Nivel2, Nivel2 = f.Nivel3, Nivel3 = f.Nivel4, Nivel4 = f.Nivel5, Tipo = (f.Codigo != null ? int.Parse(f.Codigo.Substring(0, 1)) : 0), EsBanco = f.EsBanco, IdEmpresa = 1, C1 = f.C1, C2 = f.C2, C3 = f.C3, C4 = f.C4 };
                bool esNUevo = false;
                if (f.IdMaestroCuenta != 0)
                {
                    var original = db.MaestroCuentas.Find(inf.IdMaestroCuenta);
                    if (original != null)
                        db.Entry(original).CurrentValues.SetValues(inf);
                }
                else
                {
                    esNUevo = true;
                    db.MaestroCuentas.Add(inf);
                }
                db.SaveChanges();
                if (esNUevo)
                {
                    inf.C4 = inf.IdMaestroCuenta;
                    var original = db.MaestroCuentas.Find(inf.IdMaestroCuenta);
                    if (original != null)
                        db.Entry(original).CurrentValues.SetValues(inf);
                    db.SaveChanges();
                }
                Id = inf.IdMaestroCuenta;
                return true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return false;
            }
        }
        internal MaestroCuentas BuscarCuenta(int idMaestroCuenta) => db.MaestroCuentas.Find(idMaestroCuenta);
        private string Buscar(int tipo, List<VCuentasPrimarias> lst) => lst.SingleOrDefault(s => s.Tipo.Equals(tipo)) == null ? "" : lst.SingleOrDefault(s => s.Tipo.Equals(tipo)).Text;
        public List<MaestroContable> CuentaIntegras
        {
            get
            {
                var lst = new List<Model.MaestroContable>();
                db.MaestroCuentas.OrderBy(o => o.CuentaContable).ToList().ForEach(f => {
                    var cuenta = Regex.Replace(f.CuentaContable, "[^0-9.]", "");
                    lst.Add(new Model.MaestroContable { CuentaContable = f.CuentaContable, IdMaestroCuenta = f.IdMaestroCuenta, C1 = f.C1, C2 = f.C2, C3 = f.C3, C4 = f.C4, EsBanco = f.EsBanco, Nivel1 = f.Nivel1, Nivel2 = f.Nivel2, Nivel3 = f.Nivel3, Nivel4 = f.Nivel4, Nivel = f.Nivel, Habilitar = f.Habilitar, Nivel0 = f.Nivel0, Text = f.Text, Tipo = f.Tipo });
                });
                return lst;
            }
        }
        internal async Task<List<Model.MaestroContable>> CuentasContables()
        {
            var lst = new List<Model.MaestroContable>();
            var res = await db.MaestroCuentas.Select(s => new { s.Text, s.CuentaContable, s.IdMaestroCuenta }).ToListAsync();
            res.ForEach(f => lst.Add(new MaestroContable { IdMaestroCuenta = f.IdMaestroCuenta, CuentaContable = f.CuentaContable, Text = f.Text }));
            return lst;
        }
    }
}