using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siro.Controller
{
    public class Lst
    {
        slEntities db;
        slContabilidad db2;
        slSiro db3;
        slPlanilla db4;
        public Lst()
        {
            db = new slEntities();
            db2 = new slContabilidad();
            db3 = new slSiro();
            db4 = new slPlanilla();
        }
        public void Dispose()
        {
            db.Dispose();
            db2.Dispose();
            db3.Dispose();
        }
        public List<Recibidos> Recibido {
            get
            {
                return db3.Recibidos.ToList();
            }
        }
        public List<Almacenes> Almacenes
        {
            get
            {
                return db2.Almacenes.ToList();
            }
        }
        public List<Almacenaje> AlmacenesProduccion
        {
            get
            {
                var lst = new List<Almacenaje>();
                db3.Almacenaje.Join(db3.RA, a => a.IdAlmacen, b => b.IdAlmacen, (a, b) => new { a, b }).Where(w => w.b.IdPeridoSilo == null).Select(s => new { s.a }).ToList().ForEach(f =>
                {
                    lst.Add(new Almacenaje { IdAlmacen = f.a.IdAlmacen, Almacen = f.a.Almacen });
                });
                return lst;
            }
        }
        public List<provedores> Proveedores
        {
            get
            {
                return db2.provedores.Where(w=> w.EsProductor==true).ToList();
            }
        }
        public List<TiposArroz> Productos
        {
            get
            {
                return db3.TiposArroz.ToList();
            }
        }
        public List<Model.TipoFlete> TiposFlete
        {
            get
            {
                var l = new List<Model.TipoFlete>();
                l.Add(new Model.TipoFlete { IdTipoFlete = 1, TiposFlete = "Flete Paga Productor" });
                l.Add(new Model.TipoFlete { IdTipoFlete = 2, TiposFlete = "Flete Paga Molino" });
                l.Add(new Model.TipoFlete { IdTipoFlete = 3, TiposFlete = "Flete paga el molino y retiene dinero al productor" });
                return l;
            }
        }
        public List<Conductores> Conductores
        {
            get
            {
                return db3.Conductores.ToList();
            }
        }
        public List<Model.RegistroArroz> LstRA(string filtro)
        {
            return db3.Database.SqlQuery<Model.RegistroArroz>(string.Format("SELECT * FROM Siro.VRA WHERE {0}", filtro)).ToList();
        }
        public List<VAsientos> LstAsientos(int año, int mes, int idEmpresa)
        {
            return db.VAsientos.Where(w=> w.Año == año && w.Mes == mes && w.IdEmpresa == idEmpresa).ToList();
        }
        public List<Productos> LstProducto(int idEmpresa)
        {
            return db.Productos.Where(w => w.IdEmpresa == idEmpresa).ToList();
        }
        public List<TiposMovimiento> TiposMovimientos
        {
            get
            {
                return db3.TiposMovimiento.ToList();
            }
        }
        public List<Marcas> Marcas(int idEmpresa)
        {
                return db2.Marcas.Where(w=> w.IdEmpresa==idEmpresa).ToList();
        }
        public List<Almacenes> AlmacenesP(int idEmpresa)
        {
            return db2.Almacenes.Where(w => w.IdEmpresa == idEmpresa).ToList();
        }
        public List<Categorias> Categorias
        {
            get
            {
                return db.Categorias.ToList();
            }
        }

        public string Cumpleaños
        {
            get
            {
                return db4.Colaboradores.Where(w => w.IdEstadoColaborador != 2 && w.FechaNacimiento.Value.Month==DateTime.Now.Month).Count().ToString();
            }
        }

        public List<Colaboradores> CumpleañosMes
        {
            get
            {
                return db4.Colaboradores.Where(w => w.IdEstadoColaborador != 2 && w.FechaNacimiento.Value.Month == DateTime.Now.Month).ToList();
            }
        }
    }
}
