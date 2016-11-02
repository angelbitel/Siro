using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siro.Controller
{
    public class CuentasXPagar
    {
        slContabilidad db;
        slEntities dbE;
        public string MSG { get; set; }
        //slPlanilla dbP;
        public CuentasXPagar()
        {
            db = new slContabilidad();
            dbE = new slEntities();
            //dbP = new slPlanilla();
        }
        public bool PagarFactura(int idFactura, decimal monto)
        {
            using (var context = new slContabilidad())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var entidad = context.Factura.SingleOrDefault(o => o.IdFactura == idFactura);
                        if(entidad != null)
                        {
                            entidad.MontoPagado = monto;
                            context.Entry(entidad).State = EntityState.Modified;
                            context.SaveChanges();
                            dbContextTransaction.Commit();

                            MSG = "Datos Guardados Correctamente!!";
                            return true;
                        }else
                        {
                            MSG = "Factura no encontradas..";
                            return false;
                        }
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
        public bool Guardar(Siro.Factura entidad, bool esNotaCredito)
        {
            if (entidad.Fecha.Value.Year == 1)
            {
                MSG = "Seleccione Fecha Factura.....";
                return false;
            }
            if(entidad.IdProvedor==0)
            {
                MSG = "Seleccione Un Proveedor.....";
                return false;
            }
            if (entidad.NumeroFactura == null)
            {
                MSG = "Agrege Un Numero De Factura.....";
                return false;
            }
            if (entidad.ModoPago == null && esNotaCredito==false)
            {
                MSG = "Seleccione Un Termino de Pago.....";
                return false;
            }
            if (entidad.DetallesFactura.Count() == 0)
            {
                MSG = "Agregue Detalle De Factura.....";
                return false;
            }
            else
            {
                entidad.ITBM = entidad.DetallesFactura.Sum(s => s.ITBMS);
                entidad.Monto = entidad.DetallesFactura.Sum(s => s.Monto) * entidad.DetallesFactura.Sum(s => s.Cantidad);
            }
            using (var context = new slContabilidad())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (entidad.IdFactura == 0)
                            context.Factura.Add(entidad);
                        else
                            context.Entry(entidad).State = EntityState.Modified;

                        context.SaveChanges();
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
        public List<Siro.provedores> Proveedores()
        {
            var lst = new List<Siro.provedores>();
            db.provedores.ToList().ForEach(f =>
            {
                lst.Add(new Siro.provedores
                {
                    idProvedor = f.idProvedor,
                    Proveedor = f.Proveedor,
                    Email = f.Email,
                    Telefono = f.Telefono
                });
            });
            return lst;
        }
        public List<Siro.VPagosProveedor> CXCProveedores(int idProveedor)
        {
            var lst = new List<Siro.VPagosProveedor>();
            db.VPagosProveedor.Where(w=> w.MontoPagado != w.MontoAdeudado && w.IdProvedor==idProveedor && w.Tipo==1).OrderBy(o=> o.DiasTranscurridos).ToList().ForEach(f =>
            {
                lst.Add(new Siro.VPagosProveedor
                {
                    Dias = f.Dias,
                    DiasTranscurridos = f.DiasTranscurridos,
                    Fecha = f.Fecha,
                    FechaVencimiento = f.FechaVencimiento,
                    Glosa = f.Glosa,
                    IdFactura = f.IdFactura,
                    IdProvedor = f.IdProvedor,
                    MontoAdeudado = f.MontoAdeudado,
                    MontoPagado = f.MontoPagado
                });
            });
            return lst;
        }
        public List<Siro.VPagosProveedor> CXC()
        {
            var lst = new List<Siro.VPagosProveedor>();
            db.VPagosProveedor.Where(w => w.MontoPagado != w.MontoAdeudado && w.Tipo == 2).OrderBy(o => o.DiasTranscurridos).ToList().ForEach(f =>
            {
                lst.Add(new Siro.VPagosProveedor
                {
                    Dias = f.Dias,
                    DiasTranscurridos = f.DiasTranscurridos,
                    Fecha = f.Fecha,
                    FechaVencimiento = f.FechaVencimiento,
                    Glosa = f.Glosa,
                    IdFactura = f.IdFactura,
                    IdProvedor = f.IdProvedor ?? f.IdCliente,
                    MontoAdeudado = f.MontoAdeudado,
                    MontoPagado = f.MontoPagado,
                    Corriente = f.Corriente,
                    Morosidad60 = f.Morosidad60,
                    Morosidad90 = f.Morosidad90,
                    Morosidad120 = f.Morosidad120,
                    MorosidadMas120 = f.MorosidadMas120,
                    Cliente = f.Cliente,
                    IdCliente = f.IdCliente
                });
            });
            return lst;
        }
        public List<Bancos> LstBancos()
        {
            List<Bancos> lstBancos = new List<Bancos>();
            dbE.Bancos.ToList().ForEach(f =>
            {
                lstBancos.Add(new Bancos
                {
                    Banco = f.Banco,
                    IdBanco = f.IdBanco,
                    NumeroCuenta = f.NumeroCuenta
                });
            });
            return lstBancos;
        }
        public void Dispose()
        {
            db.Dispose();
            dbE.Dispose();
        }
    }
}
