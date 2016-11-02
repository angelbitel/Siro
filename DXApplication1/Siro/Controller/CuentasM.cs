using Siro.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Siro.Controller
{
    public class CuentasM
    {
        slContabilidad db;
        public void Dispose()
        {
            db.Dispose();
        }
        public CuentasM()
        {
            db = new slContabilidad();
        }
        public List<CuentasMaestras> LstCuentasFiltradas(int idEmpresa, int[] idTipo)
        {
            List<CuentasMaestras> lst = new List<CuentasMaestras>();
            int id = 0;
            db.MaestroCuentas.Where(w => w.IdEmpresa == idEmpresa && idTipo.Contains(w.Tipo??0)).OrderBy(o => new { o.Tipo, o.Text }).ToList().ForEach(f =>
            {
                lst.Add(new CuentasMaestras
                {
                    IdEmpresa = f.IdEmpresa,
                    IdMaestroCuenta = f.IdMaestroCuenta,
                    ParentID = f.ParentID,
                    Text = f.Text,
                    Nivel = f.Nivel,
                    Id = f.Id??0,
                    ID = f.IdMaestroCuenta,
                    Tipo = f.Tipo ?? 0
                });
                id++;
            });
            return lst;
        }
        public List<CuentasMaestras> LstCuentas(int idEmpresa)
        {
            List<CuentasMaestras> lst = new List<CuentasMaestras>();
            int id = 0;
            db.MaestroCuentas.Where(w => w.IdEmpresa == idEmpresa && w.Habilitar==true).OrderBy(o => new { o.Tipo, o.Text }).ToList().ForEach(f =>
            {
                lst.Add(new CuentasMaestras
                {
                    IdEmpresa = f.IdEmpresa,
                    IdMaestroCuenta = f.IdMaestroCuenta,
                    ParentID = f.ParentID,
                    Text = f.Text,
                    Nivel = f.Nivel,
                    //Id = id,
                    Id= f.Id??0,
                    ID = f.IdMaestroCuenta,
                    Tipo = f.Tipo ?? 0
                });
                id++;
            });
            return lst;
        }
        public string MSG {get; set;}
        public bool Eliminar(int id)
        {
            try
            {
                db.MaestroCuentas.Remove(db.MaestroCuentas.SingleOrDefault(s => s.IdMaestroCuenta == id));
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MSG = "Ocurrio un error: " + ex.Message;
                return false;
            }
        }
        public int AgregarCuenta(MaestroCuentas entidad)
        {
            using (var db = new slContabilidad())
            {
                if (entidad.IdMaestroCuenta == 0)
                    db.MaestroCuentas.Add(entidad);
                else
                    db.Entry(entidad).State = EntityState.Modified;
                db.SaveChanges();
                return entidad.IdMaestroCuenta;
            }
        }
        public void ActualizarPadrent(int idCuentaMaestra, int idParent)
        {
            using (var db = new slContabilidad())
            {
                var entidad =db.MaestroCuentas.Single(s => s.IdMaestroCuenta == idCuentaMaestra);
                entidad.ParentID = idParent;
                db.Entry(entidad).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public int MaxId(int idEmpresa)
        {
            return db.MaestroCuentas.Max(m => m.Id)??0;
        }
        public List<Empresas> Empresa(int p)
        { 
            using(var db= new slEntities())
            {
                return db.Empresas.Where(w=> w.IdEmpresa != p).ToList();
            }
        }
        public int IdParent(int idCuenta, int idEmpresa)
        {
            var row= db.MaestroCuentas.SingleOrDefault(w=> w.IdMaestroCuenta == idCuenta);
            var row2 = db.MaestroCuentas.SingleOrDefault(s => s.Id == row.Id && s.IdEmpresa == idEmpresa);
            return row2.IdMaestroCuenta;
        }
    }
}
