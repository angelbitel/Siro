using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace Siro.Controller
{
    public class Colaborador
    { /// <summary>
        /// Variable que es asignada al nuevo registro
        /// </summary>
        public int? NuevoId { get; set; }
        public int? Procesados { get; set; }
        public string MSG { get; set; }
        /// <summary>
        /// Metodo Utilizado para agragar un nuevo asiento contable
        /// </summary>
        /// <returns></returns>
        public bool Guardar(Colaboradores entidad)
        {
            using (var context = new slPlanilla())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if(entidad.IdColaborador == 0)
                            context.Colaboradores.Add(entidad);
                        else
                            context.Entry(entidad).State = EntityState.Modified;

                        context.SaveChanges();
                        dbContextTransaction.Commit();

                        NuevoId = entidad.IdColaborador;
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
        /// <summary>
        /// Metodo Utilizado para agragar un nuevo deduccion y si es una sola se agrega directamente
        /// </summary>
        /// <returns></returns>
        public bool Guardar(Deducciones entidad)
        {
            entidad.FechaIngreso = Principal.Bariables.PeridoContable;

            using (var context = new slPlanilla())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (entidad.IdDeduccion == 0)
                            context.Deducciones.Add(entidad);
                        else
                            context.Entry(entidad).State = EntityState.Modified;

                        if (entidad.TipoDeduccion == "Descuento Unico" || entidad.TipoDeduccion == "Social" || entidad.TipoDeduccion == "Educativo" || entidad.TipoDeduccion == "Renta" || entidad.TipoDeduccion == "Salario Bruto")
                        {
                            var nDeduc = new IngresosDeducciones
                            {
                                FechaProceso = Principal.Bariables.PeridoContable,
                                Monto = entidad.Monto
                            };
                            var lstDeduc = new List<IngresosDeducciones>();
                            lstDeduc.Add(nDeduc);
                            entidad.IngresosDeducciones = lstDeduc;
                            entidad.MontoPagado = entidad.Monto;
                        }
                        else
                        {
                            if (entidad.Monto == 0)
                            {
                                MSG = "Monto De Deducción incompleto";
                                return false;
                            }
                            else if (entidad.ArregloRecurrente == 0)
                            {
                                MSG = "Monto del arrglo de pago incompleto";
                                return false;
                            }
                        }
                        context.SaveChanges();

                        NuevoId = entidad.IdDeduccion;
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
        public bool Guardar(HorasTrabajadas entidad)
        {
            entidad.FechaProceso = Principal.Bariables.PeridoContable;
            entidad.Mes = Principal.Bariables.PeridoContable.Month;
            entidad.Año = Principal.Bariables.PeridoContable.Year;

            using (var context = new slPlanilla())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {

                        if (entidad.Mes == 0 || entidad.Año == 0)
                        {
                            MSG = "Seleccione Mes!...";
                            return false;
                        }
                        else if(entidad.IdFactor == 0)
                        {
                            MSG = "Seleccione Tipo Hora!..";
                            return false;
                        }
                        if (entidad.IdHoraTrabjada == 0)
                            context.HorasTrabajadas.Add(entidad);
                        else
                            context.Entry(entidad).State = EntityState.Modified;
                        context.SaveChanges();

                        NuevoId = entidad.IdFactor;
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

        public bool Guardar(HistorialHoras inf)
        {
            using (var context = new slPlanilla())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (inf.IdHorario== 0)
                            context.HistorialHoras.Add(inf);
                        else
                            context.Entry(inf).State = EntityState.Modified;

                        context.SaveChanges();
                        dbContextTransaction.Commit();

                        NuevoId = inf.IdHorario;
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
        internal List<HistorialHoras> LstHistorialHoras(int idCOlabarodar)
        {
            var lst = new List<HistorialHoras>();
                lst = db.HistorialHoras.Where(w => w.IdColaborador == idCOlabarodar).OrderByDescending(o => o.Mes).ToList();
            return lst;
        }
        public List<Model.Deduccion> DeduccionesColaboradores(int idColaborador)
        {
            var lst = new List<Model.Deduccion>();
            var result = db.Deducciones.Where(w => w.IdColaborador == idColaborador).Select(s => new { s.IdDeduccion, s.FechaIngreso, s.Acredores.Acredor, s.ArregloRecurrente, s.Deduccion, s.Monto, s.MontoPagado, s.TipoDeduccion }).OrderByDescending(o => o.FechaIngreso).ToList();
            result.ForEach(f =>
            {
                lst.Add(new Model.Deduccion
                {
                    IdDeduccion = f.IdDeduccion,
                    Acredor = f.Acredor,
                    ArregloRecurrente = f.ArregloRecurrente,
                    Deducciones = f.Deduccion,
                    Monto = f.Monto,
                    MontoPagado = f.MontoPagado,
                    TipoDeduccion = f.TipoDeduccion,
                    FechaIngreso = f.FechaIngreso
                });
            });
            return lst;
        }
        public List<PlanillaColaborador> Planilla(int idColaborador)
        {
            var lst = new List<PlanillaColaborador>();
            db.PlanillaColaborador.Where(w => w.IdColaborador == idColaborador).OrderByDescending(o => new { o.Año, o.Mes, o.Quincena }).ToList().ForEach(f => lst.Add(f));
            return lst;
        }
        public bool EliminarHora(int idHora)
        {
            using (var context = new slPlanilla())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var rmove = context.HorasTrabajadas.SingleOrDefault(s => s.IdHoraTrabjada == idHora);
                        context.HorasTrabajadas.Remove(rmove);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MSG = ex.Message;
                        dbContextTransaction.Rollback();
                        return false;
                    }
                }
            }
        }
        public List<Model.MovimientoColaborador> MovimentoColaboradores(Colaboradores colaborador)
        {
            var lst = new List<Model.MovimientoColaborador>();
            var f = colaborador;
            var resul = db.HorasTrabajadas.Where(w => w.IdColaborador == f.IdColaborador).Select(s => new
            {
                s.IdHoraTrabjada,
                s.IdColaborador,
                s.HoraTrabajada,
                s.Factores.IdTipoFactor,
                s.Factores.Factor,
                s.Factores.DescripcionFactor,
                TipoFactor = s.Factores.TiposFactor.Factor,
                s.IdFactor,
                s.Factores.RestaSaldo,
                s.FechaProceso
            }).OrderByDescending(od=>od.FechaProceso).ToList();
            resul.ToList().ForEach(g =>
            {
                decimal total = 0;
                switch (g.IdTipoFactor)
                {
                    case 1:
                        total = (g.Factor ?? 0) * (g.HoraTrabajada ?? 0) * (f.RataPorHora ?? 0);
                        break;
                    case 2:
                        total = (g.Factor ?? 0) * (g.HoraTrabajada ?? 0) * (f.RataPorHora ?? 0);
                        break;
                    case 3:
                        total = (g.Factor ?? 0) * (g.HoraTrabajada ?? 0);
                        break;
                }

                lst.Add(new Model.MovimientoColaborador { 
                    IdHoraTrabjada= g.IdHoraTrabjada,
                    Fecha = g.FechaProceso ?? DateTime.Now, 
                    MontoXHoras = total, 
                    Cantidad = g.HoraTrabajada, 
                    TipoHora = g.DescripcionFactor });
            });
            return lst;
        }
        internal bool ProcesarDeduccionesAcredores()
        {
            bool ejecucion = false;
            using (var context = new slPlanilla())
            {
                context.Colaboradores.Where(w => w.IdEstadoColaborador == 1).ToList().ForEach(f => {
                    f.Deducciones.ToList().ForEach(g =>
                    {
                        decimal mntPago = g.MontoPagado ?? 0;
                        if (mntPago < g.Monto && "Recurrente Quincenal".IndexOf(g.TipoDeduccion)!= -1 )
                        {
                            IQueryable<IngresosDeducciones> verificaDec = context.IngresosDeducciones;
                            if (DateTime.Now.Day <= 15)
                            {
                                verificaDec = verificaDec.Where(w => w.FechaProceso.Value.Day >= 1 && w.FechaProceso.Value.Day <= 15 && w.IdDeduccion == g.IdDeduccion);
                            }
                            else
                            {
                                int m = DateTime.Now.Month;
                                verificaDec = verificaDec.Where(w => w.FechaProceso.Value.Day >= 16 && w.FechaProceso.Value.Month == m && w.IdDeduccion == g.IdDeduccion);
                            }
                            var result = new IngresosDeducciones {
                                  FechaProceso = Principal.Bariables.PeridoContable,
                                   IdDeduccion = g.IdDeduccion,
                                    Monto = g.ArregloRecurrente
                            };

                            if (verificaDec.Count() == 0)
                            {
                                using (var dbContextTransaction = context.Database.BeginTransaction())
                                {
                                    try
                                    {
                                        context.IngresosDeducciones.Add(result);
                                        context.Deducciones.Single(s => s.IdDeduccion == g.IdDeduccion).MontoPagado = mntPago + g.ArregloRecurrente;
                                        context.SaveChanges();
                                        dbContextTransaction.Commit();
                                        MSG = "Datos Guardados Correctamente!!";
                                        ejecucion = true;
                                        Procesados++;
                                    }
                                    catch (Exception ex)
                                    {
                                        ejecucion = false;
                                        MSG = ex.Message;
                                        dbContextTransaction.Rollback();
                                    }
                                }
                            }
                        }
                    });
                });
            }
            return ejecucion;
        }
        internal bool CalculosHoras()
        {
            using (var context = new slPlanilla())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.MaestroPlanilla(Principal.Bariables.IdUsuario, Principal.Bariables.IdEmpresa.Id, Principal.Bariables.PeridoContable);
                        dbContextTransaction.Commit();
                        MSG = "Datos Procesados Correctamente!!";
                        return true;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        MSG = ex.Message;
                        return false;
                    }
                }
            }
        }
        internal bool GenerarAsientos()
        {
            using (var context = new slPlanilla())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.MaestroPlanillaCuentas(Principal.Bariables.IdUsuario, Principal.Bariables.IdEmpresa.Id, Principal.Bariables.PeridoContable);
                        dbContextTransaction.Commit();
                        MSG = "Datos Procesados Correctamente!!";
                        return true;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        MSG = ex.Message;
                        return false;
                    }
                }
            }
        }
        private bool AgregarOtrasDeduccion(RegistroOtrosDeducciones row)
        {
            bool ejecucion = false;
            using (var context = new slPlanilla())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (row.IdOtraDeduccion == 0)
                            context.RegistroOtrosDeducciones.Add(row);
                        else
                            context.Entry(row).State = EntityState.Modified;
                        
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        MSG = "Datos Guardados Correctamente!!";
                        ejecucion = true;
                        Procesados++;
                    }
                    catch (Exception ex)
                    {
                        ejecucion = false;
                        MSG = ex.Message;
                        dbContextTransaction.Rollback();
                    }
                }
            }
            return ejecucion;
        }
        public bool CalcularDecimo()
        {
            using (var db = new slPlanilla())
            {
                var d = DescuentosGobierno.PeridoDecimo;
                db.Colaboradores.Where(w => w.IdEstadoColaborador != 2).ToList().ForEach(f => {
                    var result =db.Deducciones.Where(w => w.IdColaborador == f.IdColaborador && w.TipoDeduccion == "Salario Bruto" && DbFunctions.TruncateTime(w.FechaIngreso) >= d.Desde && DbFunctions.TruncateTime(w.FechaIngreso) <= d.Hasta).Select(s => new { s.IdColaborador, s.Monto }).ToList();
                    var rest2 = result.GroupBy(g => new { g.IdColaborador }).Select(s => new { Monto = s.Sum(su => su.Monto) }).ToList();
                    rest2.ForEach(g =>
                    {

                        decimal decimoNeto = (g.Monto ?? 0) / 12;
                        var descGob = new DescuentosGobierno();
                        double renta = 0;
                        if (f.SalarioQuincenal * 2 >= 800 && f.ExentoRenta == false)
                        {
                            var bRenta = db.RegistroOtrosDeducciones.FirstOrDefault(s => s.TipoDeduccion == "Renta" && s.IdColaborador == f.IdColaborador && s.FechaIngreso.Value.Year == DateTime.Now.Year && s.FechaIngreso.Value.Month == DateTime.Now.Month);
                            renta = descGob.Renta(Convert.ToDouble(decimoNeto), f.Dependientes ?? 0) / 2;
                            var deduccionRenta = new RegistroOtrosDeducciones
                            {
                                TipoDeduccion = "Renta",
                                IdColaborador = f.IdColaborador,
                                FechaIngreso = DateTime.Now,
                                Monto = Convert.ToDecimal(renta),
                                Deduccion = "Renta"
                            };
                            if (bRenta != null)
                                if (bRenta.IdOtraDeduccion != 0)
                                    deduccionRenta.IdOtraDeduccion = bRenta.IdOtraDeduccion;
                            AgregarOtrasDeduccion(deduccionRenta);
                        }
                        double seguro = descGob.SeguroSocialDecimo(Convert.ToDouble(decimoNeto));
                        var deduccionSeguro = new RegistroOtrosDeducciones
                        {
                            TipoDeduccion = "Seguro",
                            IdColaborador = f.IdColaborador,
                            FechaIngreso = DateTime.Now,
                            Monto = Convert.ToDecimal(seguro),
                            Deduccion = "Seguro"
                        };
                        var bSeguro = db.RegistroOtrosDeducciones.FirstOrDefault(s => s.TipoDeduccion == "Seguro" && s.IdColaborador == f.IdColaborador && s.FechaIngreso.Value.Year == DateTime.Now.Year && s.FechaIngreso.Value.Month == DateTime.Now.Month);
                        if (bSeguro != null)
                            if (bSeguro.IdOtraDeduccion != 0)
                                deduccionSeguro.IdOtraDeduccion = bSeguro.IdOtraDeduccion;
                        AgregarOtrasDeduccion(deduccionSeguro);

                        decimoNeto = decimoNeto - Convert.ToDecimal(renta + seguro);
                        var deduccionDecimo = new RegistroOtrosDeducciones
                        {
                            Deduccion = string.Format("Decimo De {0}", DateTime.Now.ToShortDateString()),
                            FechaIngreso = DateTime.Now,
                            IdColaborador = f.IdColaborador,
                            Monto = decimoNeto,
                            TipoDeduccion = "Decimo"
                        };
                        var bDecimo = db.RegistroOtrosDeducciones.FirstOrDefault(s => s.TipoDeduccion == "Decimo" && s.IdColaborador == f.IdColaborador && s.FechaIngreso.Value.Year == DateTime.Now.Year && s.FechaIngreso.Value.Month == DateTime.Now.Month);
                        if (bDecimo != null)
                            if (bDecimo.IdOtraDeduccion != 0)
                                deduccionDecimo.IdOtraDeduccion = bDecimo.IdOtraDeduccion;
                        AgregarOtrasDeduccion(deduccionDecimo);
                        Procesados++;
                    });
                    MSG = "Decimo Calculado!!!........";
                });
            }
            return true;
        }
        public decimal CalcularDecimo(Colaboradores colaborador)
        {
            using (var db = new slPlanilla())
            {
                var f = colaborador;
                var fDecimo = db.RegistroOtrosDeducciones.Where(w => w.IdColaborador == f.IdColaborador).Max(m => m.FechaIngreso);
                var result = db.Deducciones.Where(w => w.IdColaborador == f.IdColaborador && w.TipoDeduccion == "Salario Bruto" && w.FechaIngreso> fDecimo).Select(s => new { s.IdColaborador, s.Monto }).ToList();
                decimal decimo = 0;
                result.ForEach(g => decimo+= (g.Monto??0)/12);
                return decimo;
            }
        }
        public decimal CalcularVacaciones(Colaboradores colaborador)
        {
            using (var db = new slPlanilla())
            {
                var f = colaborador;
                var fDecimo = db.RegistroVacaciones.Where(w => w.IdColaborador == f.IdColaborador).Max(m => m.FechaIngreso)?? DateTime.Now.AddMonths(-12);
                var result = db.Deducciones.Where(w => w.IdColaborador == f.IdColaborador && w.TipoDeduccion == "Salario Bruto" && w.FechaIngreso > fDecimo).Select(s => new { s.IdColaborador, s.Monto }).ToList();
                return (result.Sum(s=> s.Monto)??0)/11;
            }
        }
        public List<Colaboradores> ListaColaboradores(bool fVacaciones, int? idEmpresa)
        {
            IQueryable<Colaboradores> colaborador = db.Colaboradores;
            var lst = new List<Colaboradores>();
            if (fVacaciones)
                colaborador = colaborador.Where(w => w.IdEstadoColaborador != 2 && w.IdEmpresa == idEmpresa && w.FechaIngreso.Value.Month == DateTime.Now.Month);
            else
                colaborador = colaborador.Where(w => w.IdEmpresa == idEmpresa);

            colaborador.OrderBy(o => o.Colaborador).ToList().ForEach(f =>
            {
                lst.Add(new Colaboradores
                {
                    Bonificaciones = f.Bonificaciones,
                    Colaborador = f.Colaborador,
                    CTORepresentacion = f.CTORepresentacion,
                    Direccion = f.Direccion,
                    EstadoCivil = f.EstadoCivil,
                    FechaIngreso = f.FechaIngreso,
                    HoraEntrada = f.HoraEntrada,
                    HoraSalida = f.HoraSalida,
                    IdColaborador = f.IdColaborador,
                    IdContratoColaborador = f.IdContratoColaborador,
                    IdDepartamento = f.IdDepartamento,
                    IdEntidadFinanciera = f.IdEntidadFinanciera,
                    IdEmpresa = f.IdEmpresa,
                    IdentificacionPersonal = f.IdentificacionPersonal,
                    IdEstadoColaborador = f.IdEstadoColaborador,
                    IdPosicion = f.IdPosicion,
                    IdRenta = f.IdRenta,
                    Img = f.Img,
                    RataPorHora = f.RataPorHora,
                    SalarioQuincenal = f.SalarioQuincenal,
                    Sangre = f.Sangre,
                    SeguroSocial = f.SeguroSocial,
                    Sexo = f.Sexo,
                    Dependientes = f.Dependientes,
                    FechaNacimiento = f.FechaNacimiento,
                    Reloj = f.Reloj,
                    HoraEntradaDomingo = f.HoraEntradaDomingo,
                    HoraEntradaSabado = f.HoraEntradaSabado,
                    HoraSalidaDomingo = f.HoraSalidaDomingo,
                    HoraSalidaSabado = f.HoraSalidaSabado
                });
            });
            return lst;
        }

        public List<Colaboradores> ListaColaboradores(int? idEmpresa)
        {
            IQueryable<Colaboradores> colaborador = db.Colaboradores;
            var lst = new List<Colaboradores>();
            colaborador = colaborador.Where(w => w.IdEmpresa == idEmpresa);

            colaborador.OrderBy(o => o.Colaborador).ToList().ForEach(f =>
            {
                lst.Add(new Colaboradores
                {
                    Bonificaciones = f.Bonificaciones,
                    Colaborador = f.Colaborador,
                    CTORepresentacion = f.CTORepresentacion,
                    Direccion = f.Direccion,
                    EstadoCivil = f.EstadoCivil,
                    FechaIngreso = f.FechaIngreso,
                    HoraEntrada = f.HoraEntrada,
                    HoraSalida = f.HoraSalida,
                    IdColaborador = f.IdColaborador,
                    IdContratoColaborador = f.IdContratoColaborador,
                    IdDepartamento = f.IdDepartamento,
                    IdEntidadFinanciera = f.IdEntidadFinanciera,
                    IdEmpresa = f.IdEmpresa,
                    IdentificacionPersonal = f.IdentificacionPersonal,
                    IdEstadoColaborador = f.IdEstadoColaborador,
                    IdPosicion = f.IdPosicion,
                    IdRenta = f.IdRenta,
                    Img = f.Img,
                    RataPorHora = f.RataPorHora,
                    SalarioQuincenal = f.SalarioQuincenal,
                    Sangre = f.Sangre,
                    SeguroSocial = f.SeguroSocial,
                    Sexo = f.Sexo,
                    Dependientes = f.Dependientes,
                    Reloj = f.Reloj
                });
            });
            return lst;
        }
        internal List<Model.TiposCalculos> CalculosVacaciones(int? IdColaborador, bool agregaDescuentos)
        {
            var lst = new List<Model.TiposCalculos>();
            var vacaciones = db.PlanillaColaborador.Where(w => DbFunctions.AddMonths(w.FechaProceso, -12) <= DateTime.Now && w.IdColaborador == IdColaborador).Select(s => new { TotalHoras = s.TotalHoras??0, s.SalarioBruto }).Sum(s => s.SalarioBruto);
           
            lst.Add(new Model.TiposCalculos
            {
                Monto = vacaciones/11,
                Tipo = "Vacaciones"
            });

            db.Deducciones.Where(w => w.TipoDeduccion == "Salario Bruto" && w.IdColaborador == IdColaborador).GroupBy(g => new { g.TipoDeduccion, Fecha = g.FechaIngreso.Value.Month }).Select(s => new { s.Key.Fecha, s.Key.TipoDeduccion, Monto = s.Sum(su => su.Monto) }).ToList().ForEach(f =>
            {
                lst.Add(new Model.TiposCalculos
                {
                    Monto = f.Monto,
                    Tipo = f.TipoDeduccion,
                    Fecha = f.Fecha
                });
            });
            if (agregaDescuentos)
            {
                string[] tpDe = { "Recurrente Quincenal", "Recurrente CXC" };
                db.Deducciones.Where(w => tpDe.Contains(w.TipoDeduccion) && w.IdColaborador == IdColaborador).GroupBy(g => new { g.TipoDeduccion, Fecha = g.FechaIngreso.Value.Month }).Select(s => new { s.Key.Fecha, s.Key.TipoDeduccion, Monto = s.Sum(su => su.ArregloRecurrente) }).ToList().ForEach(f =>
                {
                    lst.Add(new Model.TiposCalculos
                    {
                        Monto = -f.Monto,
                        Tipo = f.TipoDeduccion,
                        Fecha = f.Fecha
                    });
                });
            }
            return lst;
        }
        internal List<Model.Liquidacion> CalculosLiquidacion(int? IdColaborador)
        {
            var lst = new List<Model.Liquidacion>();
            db.PlanillaColaborador.Where(w => w.IdColaborador == IdColaborador).GroupBy(g => new { g.IdColaborador }).Select(s => new { s.Key.IdColaborador, Indemnizacion = s.Sum(su => su.indemnizacion), Antiguedad= s.Sum(su=> su.Antiguedad) }).ToList().ForEach(f =>
            {
                lst.Add(new Model.Liquidacion
                {
                    Antigudad = f.Antiguedad??0,
                    Indemnizacion = f.Indemnizacion??0
                });
            });
            int mes=0,q=0;
            db.PlanillaColaborador.Where(w=> w.IdColaborador==IdColaborador).GroupBy(g=> new { g.IdColaborador }).Select(s=> new{ s.Key.IdColaborador, mxM=s.Max(m=> m.Mes)}).ToList().ForEach(f=> mes=f.mxM);
            db.PlanillaColaborador.Where(w=> w.IdColaborador==IdColaborador && w.Mes==mes).GroupBy(g=> new { g.IdColaborador }).Select(s=> new{ s.Key.IdColaborador, mxQ=s.Max(m=> m.Quincena)}).ToList().ForEach(f=> q=f.mxQ);
            DateTime vacaDt = DateTime.Now.AddMonths(-11), decimoDt = DateTime.Now.AddMonths(-4);
            lst[0].UltimoSalarioNeto = db.PlanillaColaborador.SingleOrDefault(s => s.Mes == mes && s.Quincena == q && s.IdColaborador==IdColaborador).SalarioNeto ?? 0;
            lst[0].VacacionesProporcionales = db.PlanillaColaborador.Where(s => s.FechaProceso >= vacaDt && s.IdColaborador == IdColaborador).Sum(s=> s.Vacacciones) ?? 0;
            lst[0].DecimoProporcinal = db.PlanillaColaborador.Where(s => s.FechaProceso >= decimoDt && s.IdColaborador == IdColaborador).Sum(s => s.Decimo) ?? 0;
            lst[0].SeguroDecimoProporcinal = (db.PlanillaColaborador.Where(s => s.FechaProceso >= decimoDt && s.IdColaborador == IdColaborador).Sum(s=> s.Decimo) ?? 0 * (9.75M)) / 100;
            lst[0].Educativo = db.PlanillaColaborador.Where(s => s.Mes == mes && s.Quincena == q && s.IdColaborador == IdColaborador).Sum(s => s.SeguroEducativo) ?? 0;
            lst[0].Social = db.PlanillaColaborador.Where(s => s.Mes == mes && s.Quincena == q && s.IdColaborador == IdColaborador).Sum(s => s.SeguroSocial) ?? 0;
            return lst;
        }
        internal bool Guardar(Model.Vacacion vac)
        {
            bool ejecucion = false;
            using (var context = new slPlanilla())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var row = new RegistroVacaciones
                        {
                            Brutas = vac.Brutas,
                            Descuentos = vac.Descuentos,
                            Desde = vac.Desde,
                            Hasta = vac.Hasta,
                            FechaIngreso = DateTime.Now,
                            IdColaborador = vac.IdColaborador,
                            Educativo = vac.Educativo,
                            ISR = vac.ISR,
                            Monto = vac.Monto,
                            Neto = vac.Neto,
                            Social = vac.Social,
                            TipoDeduccion = "Vacaciones"
                        };
                        context.RegistroVacaciones.Add(row);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        MSG = "Datos Guardados Correctamente!!";
                        ejecucion = true;
                        Procesados++;
                    }
                    catch (Exception ex)
                    {
                        ejecucion = false;
                        MSG = ex.Message;
                        dbContextTransaction.Rollback();
                    }
                }
            }
            return ejecucion;
        }
        internal bool Guardar(RegistroLiquidaciones liquidacion)
        {
            bool ejecucion = false;
            using (var context = new slPlanilla())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.RegistroLiquidaciones.Add(liquidacion);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        MSG = "Datos Guardados Correctamente!!";
                        ejecucion = true;
                        Procesados++;
                    }
                    catch (Exception ex)
                    {
                        ejecucion = false;
                        MSG = ex.Message;
                        dbContextTransaction.Rollback();
                    }
                }
            }
            return ejecucion;
        }
        internal bool Eliminar(int idDeduccion)
        {
            using (var context = new slPlanilla())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.IngresosDeducciones.RemoveRange(context.IngresosDeducciones.Where(w => w.IdDeduccion == idDeduccion));
                        var rmove = context.Deducciones.SingleOrDefault(s => s.IdDeduccion == idDeduccion);
                        context.Deducciones.Remove(rmove);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MSG = ex.Message;
                        dbContextTransaction.Rollback();
                        return false;
                    }
                }
            }
        }
        slPlanilla db;
        public Colaborador() {
            db = new slPlanilla();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
