using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Siro.Controller
{
    public class Producto
    {
        Siro.slEntities db;
        public Producto()
        {
            db = new slEntities();
        }
        public List<Model.Producto> Productos(int? idEmpresa)
        {
            var lstDatos = new List<Model.Producto>();
            db.Productos.Where(w => w.IdEmpresa == idEmpresa).ToList().ForEach(f =>
            {
                lstDatos.Add(new Model.Producto
                {
                    IdCategoria = f.IdCategoria,
                    IdEmpresa = f.IdEmpresa,
                    IdProducto = f.IdProducto,
                    Cantidad = f.Cantidad,
                    CodigoBarras = f.CodigoBarras,
                    PrecioCompra = f.PrecioCompra,
                    PrecioVenta = f.PrecioVenta,
                    Productos1 = f.Productos1,
                    PuntoReorden = f.PuntoReorden,
                    ITBM = f.Categorias.ITBMS,
                    IdPrecioProducto =f.IdProducto,
                    IS = f.Categorias.IngresoSubsidio
                });
            });
            return lstDatos;
        }
        public List<Precios> ListaPrecios()
        {
            var lstDatos = new List<Precios>();
            db.Precios.ToList().ForEach(f =>
            {
                lstDatos.Add(new Precios{
                     IdPrecio = f.IdPrecio,
                     Precio = f.Precio
                });
            });
            return lstDatos;
        }
        public List<PrecioProducto> ListaPreciosProductos(int idProducto)
        {
            var lstDatos = new List<PrecioProducto>();
            db.PrecioProducto.Where(w=> w.IdProducto == idProducto).ToList().ForEach(f =>
            {
                lstDatos.Add(new PrecioProducto
                {
                    IdPrecio = f.IdPrecio,
                    IdPrecioProducto = f.IdPrecioProducto,
                    IdProducto = f.IdProducto,
                    IdServicio = f.IdServicio,
                    Precio = f.Precio
                });
            });
            return lstDatos;
        }
        public List<PrecioProducto> ListaPreciosServicios(int idServicio)
        {
            var lstDatos = new List<PrecioProducto>();
            db.PrecioProducto.Where(w => w.IdProducto == idServicio).ToList().ForEach(f =>
            {
                lstDatos.Add(new PrecioProducto
                {
                    IdPrecio = f.IdPrecio,
                    IdPrecioProducto = f.IdPrecioProducto,
                    IdProducto = f.IdProducto,
                    IdServicio = f.IdServicio,
                    Precio = f.Precio
                });
            });
            return lstDatos;
        }
        public List<Model.Servicio> Servicios(int? idEmpresa)
        {
            var lstDatos = new List<Model.Servicio>();
                db.Servicios.Where(w=> w.IdEmpresa == idEmpresa).ToList().ForEach(f =>
                {
                    lstDatos.Add(new Model.Servicio
                    {
                        IdCategoria = f.IdCategoria,
                        IdEmpresa = f.IdEmpresa,
                        IdServicio = f.IdServicio,
                        Precio = f.Precio,
                        Servicios1 = f.Servicios1,
                        ITBMS = f.Categorias.ITBMS,
                        IS = f.Categorias.IngresoSubsidio
                    });
                });
            return lstDatos;
        }
        public bool Guardar(PrecioProducto entidad)
        {
            using (var context = new slEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (entidad.IdPrecioProducto == 0)
                            context.PrecioProducto.Add(entidad);
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
        public string MSG { get; set; }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}