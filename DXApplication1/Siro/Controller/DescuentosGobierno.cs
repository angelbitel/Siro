using System;
namespace Siro.Controller
{
    public class DescuentosGobierno
    {
        public double SeguroSocialPatrono(double salario)
        {
            return (salario * 9.75) / 100;
        }
        public double SeguroEducativoPatrono(double salario)
        {
            return (salario * 1.25) / 100;
        }
        public double RiesgoProfesional(double salario)
        {
            return (salario * 1.25) / 100;
        }
        public double SeguroSocial(double salario)
        {
            return  (salario*9.75)/100;
        }
        public double SeguroSocialDecimo(double salario)
        {
            return (salario * 7.25) / 100;
        }
        public double SeguroEducativo(double salario)
        {
            return (salario*1.25)/100;
        }
        public double Renta(double salario, int dependiente)
        {
            if (dependiente > 0)
                dependiente = 1;
            if (salario <= 800)
            {
                return 0;
            }
            var resultados = (((salario * 1) * 13) * Math.Pow(10, 2)) / Math.Pow(10, 2);
            var rentaNeta = resultados - (800 * dependiente);
            return Math.Round(renta2010(rentaNeta) / 13,2);
        }
        private double renta2010(double rentaNeta)
        {
            var valor = rentaNeta * 1;
            if (valor > 50000)
            {
                valor = ((valor - 50000) * 0.25) + 5850;
            }
            else
            {
                valor = (valor - 11000) * .15;
            }
            if (valor < 0)
                valor = 0;
            return valor;
        }
        public static bool decimo {
            get {
                if (DateTime.Now.Month % 4 == 0)
                {
                    if (DateTime.Now.Day <= 15)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
        }
        public static Model.FFiltro PeridoDecimo
        {
            get
            {
                var f=new Model.FFiltro();
                switch(DateTime.Now.Month)
                {
                    case 4:
                        f= new Model.FFiltro{ Desde= new DateTime(DateTime.Now.Year -1, 12, 15), Hasta= new DateTime(DateTime.Now.Year, 4, 15)};
                        break;
                    case 8:
                        f= new Model.FFiltro { Desde = new DateTime(DateTime.Now.Year, 4, 15), Hasta = new DateTime(DateTime.Now.Year, 8, 15) };
                        break;
                    case 12:
                        f= new Model.FFiltro { Desde = new DateTime(DateTime.Now.Year, 4, 15), Hasta = new DateTime(DateTime.Now.Year, 8, 15) };
                        break;
                }
                return f;
            }
        }
    }
}