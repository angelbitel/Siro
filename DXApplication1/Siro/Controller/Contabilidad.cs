using Siro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Siro.Controller
{
    public class Contabilidad
    {
        slContabilidad db;
        slEntities dbE;
        slPlanilla dbP;
        public Contabilidad()
        {
            db = new slContabilidad();
            dbE = new slEntities();
            dbP = new slPlanilla();
        }
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
        public List<Model.MaestroCuentas> Cuentas
        {
            get
            {
                var lst = new List<Model.MaestroCuentas>();
                db.MaestroCuentas.OrderBy(o => o.CuentaContable).ToList().ForEach(f => {
                    var cuenta = Regex.Replace(f.CuentaContable, "[^0-9.]", "");
                    lst.Add(new Model.MaestroCuentas { Codigo = cuenta.Trim(), Cuenta = f.Text.Trim(), IdMaestroCuenta = f.IdMaestroCuenta });
                });
                return lst;
            }
        }

        public string Mensaje { get; private set; }

        public List<Cuentas> CuentasMaestras()
        {
            var lst = new List<Cuentas>();
            var lstCUentas = db.VCuentasPrimarias.ToList();
            db.MaestroCuentas.Where(w => w.Habilitar == true).OrderBy(o => new { o.CuentaContable }).ToList().ForEach(f =>
            {
                lst.Add(new Cuentas
                {
                    ParentID = f.ParentID ?? 0,
                    Text = f.Text,
                    ID = f.IdMaestroCuenta,
                    Tipo = f.Tipo ?? 0,
                    Id = f.Id ?? 0,
                    CuentaContable = f.CuentaContable,
                    Nivel = f.Nivel ?? 0,
                    Nivel0 = f.Nivel0,
                    Nivel1 = f.Nivel1,
                    Nivel2 = f.Nivel2,
                    Nivel3 = f.Nivel3,
                    Habilitar = f.Habilitar,
                    SumaResta = f.SumaResta,
                    CuentaMadre = $"{f.Tipo} {Buscar(f.Tipo ?? 0, lstCUentas)}"
                });
            });
            return lst;
        }
        public List<Cuentas> CuentasMaestras(int idEmpresa)
        {
            var lst = new List<Cuentas>();
            var lstCUentas = db.VCuentasPrimarias.ToList();
            db.MaestroCuentas.Where(w => w.IdEmpresa == idEmpresa && w.Habilitar == true).OrderBy(o => new { o.Tipo, o.Id }).ToList().ForEach(f =>
               {
                   lst.Add(new Cuentas
                   {
                       ParentID = f.ParentID ?? 0,
                       Text = f.Text,
                       ID = f.IdMaestroCuenta,
                       Tipo = f.Tipo ?? 0,
                       Id = f.Id ?? 0,
                       CuentaContable = f.CuentaContable,
                       Nivel = f.Nivel ?? 0,
                       Nivel0 = f.Nivel0,
                       Nivel1 = f.Nivel1,
                       Nivel2 = f.Nivel2,
                       Nivel3 = f.Nivel3,
                       Habilitar = f.Habilitar,
                       SumaResta = f.SumaResta,
                       CuentaMadre = Buscar(f.Tipo ?? 0, lstCUentas)
                   });
               });
            return lst;
        }
        public List<Model.Cuentas> Personas(int idEmpresa)
        {
            var lst = new List<Model.Cuentas>();
            
            lst.Add(new Model.Cuentas
            {
                Text = "Proveedores",
                ID = 1,
                //Tipo = 1
            });
            lst.Add(new Model.Cuentas
            {
                Text = "Colaboradores",
                ID = 2,
                //Tipo = 2
            });
            lst.Add(new Model.Cuentas
            {
                Text = "Clientes",
                ID = 3,
                //Tipo = 3
            });
            db.provedores.ToList().ForEach(f =>
            {
                lst.Add(new Model.Cuentas
                {
                    Text = f.Proveedor,
                    ID = f.idProvedor+10,
                    //Tipo = 1,
                    ParentID = 1
                });
            });
            dbP.Colaboradores.Where(w => w.IdEmpresa == idEmpresa).ToList().ForEach(f =>
            {
                lst.Add(new Model.Cuentas
                {
                    Text = f.Colaborador,
                    ID = f.IdColaborador + 100,
                    //Tipo = 2,
                    ParentID = 2
                });
            });
            dbE.Clientes.ToList().ForEach(f =>
            {
                lst.Add(new Model.Cuentas
                {
                    Text = f.NombreCompleto,
                    ID = f.idCliente + 300,
                    //Tipo = 3,
                    ParentID = 3
                });
            });
            return lst;
        }
        public void Dispose() => db.Dispose();
        public List<Cuentas> LstCuentasFiltradas(int idEmpresa, int[] idTipo)
        {
            List<Cuentas> lst = new List<Cuentas>();
            int id = 0;
            db.MaestroCuentas.Where(w => w.IdEmpresa == idEmpresa && idTipo.Contains(w.Tipo ?? 0) && w.Habilitar==true).OrderBy(o => new { o.Tipo, o.Text }).ToList().ForEach(f =>
            {
                lst.Add(new Cuentas
                {
                    ParentID = f.ParentID??0,
                    Text = f.Text,
                    ID = f.IdMaestroCuenta,
                    Tipo = f.Tipo ?? 0
                });
                id++;
            });
            return lst;
        }
    }
}
