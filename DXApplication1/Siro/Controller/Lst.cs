using Siro.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Siro.Controller
{
    public class Lst
    {
        slEntities db;
        slContabilidad db2;
        slSiroCon db3;
        slPlanilla db4;
        public Lst()
        {
            db = new slEntities();
            db2 = new slContabilidad();
            db3 = new slSiroCon();
            db4 = new slPlanilla();
        }
        public void Dispose()
        {
            db.Dispose();
            db2.Dispose();
            db3.Dispose();
        }
        public List<Recibidos> Recibido => db3.Recibidos.ToList();
        internal List<OrigenesTransacciones> Origenes
        {
            get
            {
                var lst = new List<OrigenesTransacciones>();
                lst.AddRange(new OrigenesTransacciones[]{
                    new OrigenesTransacciones{ IdOrigen = 1, OrigenTransaccion = "VENTAS" },
                    new OrigenesTransacciones{ IdOrigen = 2, OrigenTransaccion = "COMPRAS" },
                    new OrigenesTransacciones{ IdOrigen = 3, OrigenTransaccion = "PAGOS CXC" },
                    new OrigenesTransacciones{ IdOrigen = 4, OrigenTransaccion = "CHEQUES" },
                    new OrigenesTransacciones{ IdOrigen = 5, OrigenTransaccion = "DEPOSITOS" },
                    new OrigenesTransacciones{ IdOrigen = 6, OrigenTransaccion = "AJUSTES BANCARIOS" }});
                return lst;
            }
        }
        public List<Almacenes> Almacenes => db2.Almacenes.ToList();
        public List<Almacenaje> AlmacenesProduccion
        {
            get
            {
                var lst = new List<Almacenaje>();
                //db3.Almacenaje.Join(db3.RA, a => a.IdAlmacen, b => b.IdAlmacen, (a, b) => new { a, b }).Where(w => w.b.IdPeridoSilo == null).Select(s => new { s.a }).ToList().ForEach(f =>
                db3.Almacenaje.ToList().ForEach(f =>
                {
                    lst.Add(new Almacenaje { IdAlmacen = f.IdAlmacen, Almacen = f.Almacen });
                });
                return lst;
            }
        }
        public List<provedores> Proveedores {
            get
            {
                var lstP = new List<provedores>();
                db2.MaestroCuentas.Where(w => w.CuentaContable.Contains("21112")).ToList().ForEach(f=> lstP.Add(new provedores { idProvedor = f.IdMaestroCuenta, Proveedor = f.Text }));
                    return lstP;
            }
        }
        
        public List<TiposArroz> Productos => db3.TiposArroz.ToList();
        public List<TipoFlete> TiposFlete
        {
            get
            {
                var l = new List<TipoFlete>();
                l.Add(new TipoFlete { IdTipoFlete = 1, TiposFlete = "Flete Paga Molino" });
                l.Add(new TipoFlete { IdTipoFlete = 2, TiposFlete = "Flete Paga Productor" });
                l.Add(new TipoFlete { IdTipoFlete = 3, TiposFlete = "Flete paga el molino y retiene dinero al productor" });
                return l;
            }
        }
        public List<Conductores> Conductores => db3.Conductores.ToList();
        public List<Siro.RA> LstRA(string filtro) => db3.Database.SqlQuery<Siro.RA>(string.Format("SELECT * FROM Siro.RA WHERE {0}", filtro)).ToList();
        public List<VAsientos> LstAsientos(int año, int mes, int idEmpresa) => db.VAsientos.Where(w => w.Año == año && w.Mes == mes && w.IdEmpresa == idEmpresa).ToList();
        public List<Model.VerAsientos> LstAsientosResumen(int ultimoAsiento)
        {
            var lstR = db.VAsientos.Select(s => new { s.Detalle, s.IdAsiento, s.Comentario, s.Credito, s.CuentaContable, s.Debito, s.Fecha, s.IdCuentaContable, s.Mayor, s.Año, s.Mes, s.IdEmpresa, s.Cuenta, s.IdOrigen }).Where(w => w.IdAsiento == ultimoAsiento).ToList();
            var lstAs = new List<VerAsientos>();
            lstR.ForEach(f =>
            {
                var cuenta = string.Format("[{0}] {1}", f.CuentaContable, f.Cuenta);
                if (f.Debito == 0)
                    cuenta = "             " + cuenta;
                lstAs.Add(new VerAsientos
                {
                    Comentario = string.Format("# ASIENTO:[{0}] {1}", f.IdAsiento, f.Comentario.ToUpper()),
                    IdAsiento = f.IdAsiento,
                    Credito = Math.Abs(f.Credito ?? 0m),
                    CuentaContable = cuenta,
                    Debito = Math.Abs(f.Debito ?? 0m),
                    Fecha = f.Fecha,
                    IdCuentaContable = f.IdCuentaContable,
                    Mayor = f.Mayor,
                    Detalle = f.Detalle,
                    IdOrigen =  f.IdOrigen
                });
            });
            return lstAs;
        }
        public int UltimOAsiento(int idEmpresa) {
            var ultimoAsiento = db.VAsientos.Where(w => w.IdEmpresa == idEmpresa).Select(s=> new { s.IdAsiento }).OrderByDescending(o=> o.IdAsiento).Take(1).ToList();
            return ultimoAsiento.Count == 0 ? 0 : ultimoAsiento.Max(m=>m.IdAsiento);
        }
        public List<VerAsientos> LstAsientosResumen(int año, int mes, int idEmpresa)
        {
            var lstR = db.VAsientos.Select(s => new {s.Detalle, s.IdAsiento, s.Comentario, s.Credito, s.CuentaContable, s.Debito, s.Fecha, s.IdCuentaContable, s.Mayor, s.Año, s.Mes, s.IdEmpresa, s.Cuenta, s.IdOrigen }).Where(w => w.Año == año && w.Mes == mes && w.IdEmpresa == idEmpresa).ToList();
            var lstAs = new List<VerAsientos>();
            lstR.ForEach(f =>
            {
                var cuenta = string.Format("[{0}] {1}", f.CuentaContable, f.Cuenta);
                if (f.Debito == 0)
                    cuenta = "             " + cuenta;
                lstAs.Add(new VerAsientos
                {
                    Comentario = string.Format("# ASIENTO:[{0}] {1}", f.IdAsiento, (f.Comentario??"").ToUpper()),
                    IdAsiento = f.IdAsiento,
                    Credito = Math.Abs(f.Credito ?? 0m),
                    CuentaContable = cuenta,
                    Debito = Math.Abs(f.Debito ?? 0m),
                    Fecha = f.Fecha,
                    IdCuentaContable = f.IdCuentaContable,
                    Mayor = f.Mayor,
                    Detalle = f.Detalle,
                    IdOrigen = f.IdOrigen
                });
            });
            return lstAs;
        }
        public List<VerAsientos> LstAsientosResumen(int idMaestroCuenta, int idEmpresa)
        {
            var lstBuscarAsiento = new List<int>();
            db.VAsientos.Where(w => w.IdEmpresa == idEmpresa && w.IdCuentaContable == idMaestroCuenta).Select(s => new { s.IdAsiento }).ToList().ForEach(f=> lstBuscarAsiento.Add(f.IdAsiento));
            
            var lstR = db.VAsientos.Select(s => new { s.Detalle, s.IdAsiento, s.Comentario, s.Credito, s.CuentaContable, s.Debito, s.Fecha, s.IdCuentaContable, s.Mayor, s.Año, s.Mes, s.IdEmpresa, s.Cuenta, s.IdOrigen }).Where(w => lstBuscarAsiento.Contains(w.IdAsiento)).ToList();
            var lstAs = new List<VerAsientos>();
            lstR.OrderBy(o=> o.Fecha).ToList().ForEach(f =>
            {
                var cuenta = string.Format("[{0}] {1}", f.CuentaContable, f.Cuenta);
                if (f.Debito == 0)
                    cuenta = "             " + cuenta;
                lstAs.Add(new VerAsientos
                {
                    Comentario = string.Format("# ASIENTO:[{0}] {1}", f.IdAsiento, (f.Comentario ?? "").ToUpper()),
                    IdAsiento = f.IdAsiento,
                    Credito = Math.Abs(f.Credito ?? 0m),
                    CuentaContable = cuenta,
                    Debito = Math.Abs(f.Debito ?? 0m),
                    Fecha = f.Fecha,
                    IdCuentaContable = f.IdCuentaContable,
                    Mayor = f.Mayor,
                    Detalle = f.Detalle,
                    IdOrigen = f.IdOrigen
                });
            });
            return lstAs;
        }
        public List<Productos> LstProducto(int idEmpresa) => db.Productos.Where(w => w.IdEmpresa == idEmpresa).ToList();
        public List<TiposMovimiento> TiposMovimientos => db3.TiposMovimiento.ToList();
        public List<Marcas> Marcas(int idEmpresa) => db2.Marcas.Where(w => w.IdEmpresa == idEmpresa).ToList();
        public List<Almacenes> AlmacenesP(int idEmpresa) => db2.Almacenes.Where(w => w.IdEmpresa == idEmpresa).ToList();
        public List<Categorias> Categorias => db.Categorias.ToList();
        public string Cumpleaños => db4.Colaboradores.Where(w => w.IdEstadoColaborador != 2 && w.FechaNacimiento.Value.Month == DateTime.Now.Month).Count().ToString();
        public List<Colaboradores> CumpleañosMes => db4.Colaboradores.Where(w => w.IdEstadoColaborador != 2 && w.FechaNacimiento.Value.Month == DateTime.Now.Month).ToList();
        public List<Vendedores> Vendedores => db3.Vendedores.ToList();
        public List<Clientes> Clientes => db.Clientes.ToList();
        public List<Model.MaestroContable> Cuentas()
        {
            var lst = new List<MaestroContable>();
            db2.MaestroCuentas.Select(s => new { s.IdMaestroCuenta, s.Text, s.CuentaContable }).OrderBy(o=> o.CuentaContable).ToList().ForEach(f=> lst.Add(new MaestroContable { IdMaestroCuenta = f.IdMaestroCuenta, CuentaContable = f.CuentaContable, Text = f.Text}));
            return lst;
        }
    } 
}
