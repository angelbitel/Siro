using Siro.Model;
using Siro.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Siro.Controller
{
    public class HasardFile
    {
        public HasardFile(Prmts prm)
        {
            Lineas = new List<string>();
            PatchFile = prm.PatchFile;
            PatchBat = prm.PatchBat;
        }
        public List<string> Lineas { get; set; }
        private string PatchFile { get; set; }
        private string PatchBat { get; set; }
        public void X()
        {
            Lineas.Clear();
            Lineas.Add(string.Format("{0}{1}X", separadar, nueve));
            WriteFile();
        }
        private void WriteFile()
        {
            using (StreamWriter sw = File.CreateText(PatchFile))
            {
                Lineas.ForEach(f =>
                {
                    sw.WriteLine(f);
                });
                sw.Close();
            }
            Ejecutar();
        }
        private void Ejecutar()
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //proc.StartInfo.FileName = PatchBat;
            proc.StartInfo.FileName = @"C:\Tools1000fpa\wspooler.exe";
            proc.StartInfo.Arguments = @"-p1 -z -f C:\Tools1000fpa\x.txt";
            proc.Start();
        }
        const char separadar = '\x39';
        const char nueve = (char)(28);
        const char gorr = '\x5e';
        //const char sep = (char)28;
        //const char sepNueve = (char)57;
        public void Z()
        {
            Lineas.Clear();
            Lineas.Add(string.Format("{0}{1}Z",separadar,nueve));
            WriteFile();
        }
        public void DocumentoFiscal(Transacciones transac, System.ComponentModel.BindingList<DetalleTransaccion> detalle, Clientes cl, bool esNotaCredito)
        {
            string tipoTransacc = "A";
            if (esNotaCredito)
                tipoTransacc = "D";
            Lineas.Clear();
            //Header
            Lineas.Add(string.Format("]{0}0{0}",nueve));

            Lineas.Add(string.Format("]{2}1{2}Transaccion: {0}   Fecha Ord.: {1}", transac.IdTransaccion, transac.FechaTransaccion.Value.ToString("dd-MMM-yyyy"), nueve));
            //Footer
            Lineas.Add(string.Format("^{0}0{0}", nueve));
            //Lineas.Add("^" + nueve + "0" + nueve);
            Lineas.Add(string.Format("^{1}1{1}Cajero: {0}", Settings.Default.UltimoUsuario, nueve));
            if (cl.CedulaRuc == null)
                cl.CedulaRuc = "0-000-0000";
            //Abrir Comprobante {0}=cliente, {1}=Identificacion, {2}=Tipo Transacion Factura o Nota de Credito
            Lineas.Add(string.Format("@{3}{0}{3}{1}{3}{3}{3}{3}{3}{2}", cl.NombreCompleto.Trim(), cl.CedulaRuc.Trim(), tipoTransacc, nueve));

            //Enviar Productos {0:#0.00} {0}=Detalle, {1}= Cantidad, {2}=Monto, {3}=Codigo Producto, {4}=impuesto
            detalle.ToList().ForEach(f =>
            {
                Lineas.Add(string.Format("B{5}{0}{5}{1}{5}{2}{5}{4}.{5}M{5}{3}", 
                    f.Descripcion,
                    Convert.ToDecimal(f.Cantidad).ToString("#0.00"),
                    Convert.ToDecimal(f.Monto).ToString("#0.00"),
                    f.IdServicio == 0? f.IdProducto:f.IdServicio,
                     Convert.ToInt32(f.itbm * 100),
                     nueve
                    ));
                if (f.Descuento > 0)
                {
                    Lineas.Add(string.Format("B∟Descuento De {0}{5}{1}{5}{2}{5}{4}.{5}m{5}{3}",
                        f.Descripcion,
                        Convert.ToDecimal(f.Cantidad).ToString("#0.00"),
                        Convert.ToDecimal(f.Monto).ToString("#0.00"),
                        f.IdServicio == 0 ? f.IdProducto : f.IdServicio,
                        Convert.ToInt32(f.itbm*100),
                        nueve
                        )); 
                }
            });
            var cntFpago = transac.FPagoUilizada.Where(w => w.IdFormaPago == 8).Count();
            if (cntFpago == 0 && esNotaCredito ==false)
            {
                string frmPago = "", forma = "";
                transac.FPagoUilizada.ToList().ForEach(g =>
                {
                    switch (g.IdFormaPago)
                    {
                        case 1:
                            frmPago = "1";
                            forma = "Efectivo";
                            break;
                        case 2:
                            frmPago = "3";
                            forma = "Visa";
                            break;
                        case 3:
                            frmPago = "3";
                            forma = "Master Card";
                            break;
                        case 4:
                            frmPago = "3";
                            forma = "Americam Express";
                            break;
                        case 5:
                            frmPago = "2";
                            forma = "Tarjeta Clave";
                            break;
                        case 6:
                            frmPago = "1";
                            forma = "Cheque";
                            break;
                        default:
                            frmPago = "1";
                            forma = "Otro";
                            break;
                    }
                    //Forma Pago {0}=Forma Pago , {1}=Monto, {2}=Id Forma Pago
                    Lineas.Add(string.Format("D{3}{0}{3}{1}{3}T{3}{2}",
                           forma,
                            Convert.ToDecimal(g.Monto).ToString("#0.00"),
                            frmPago,
                            nueve
                            ));
                });
            }
            //Cerrar Documento 
            Lineas.Add("E");
            Lineas.Add("{");
            WriteFile();
        }
    }
}
