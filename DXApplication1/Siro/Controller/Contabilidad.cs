using Siro.Model;
using System.Collections.Generic;
using System.Linq;

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
        public List<Cuentas> CuentasMaestras(int idEmpresa)
        {
            var lst = new List<Cuentas>();
            db.MaestroCuentas.Where(w => w.IdEmpresa == idEmpresa && w.Habilitar==true).OrderBy(o => new {o.Tipo, o.Id }).ToList().ForEach(f =>
            {
                lst.Add(new Cuentas
                {
                    ParentID = f.ParentID,
                    Text = f.Text,
                    ID = f.IdMaestroCuenta,
                    Tipo = f.Tipo??0,
                    Id = f.Id??0
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
        public void Dispose()
        {
            db.Dispose();
        }
        public List<Cuentas> LstCuentasFiltradas(int idEmpresa, int[] idTipo)
        {
            List<Cuentas> lst = new List<Cuentas>();
            int id = 0;
            db.MaestroCuentas.Where(w => w.IdEmpresa == idEmpresa && idTipo.Contains(w.Tipo ?? 0) && w.Habilitar==true).OrderBy(o => new { o.Tipo, o.Text }).ToList().ForEach(f =>
            {
                lst.Add(new Cuentas
                {
                    ParentID = f.ParentID,
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
