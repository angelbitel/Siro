using System;
namespace Siro.Model
{
    public class TiposCalculos
    {
        public string Tipo { get; set; }
        public decimal? Monto { get; set; }
        public int? Fecha { get; set; }
        public string Mes
        {
            get
            {
                switch (Fecha)
                {
                    case 1:
                        return "Enero";
                    case 2:
                        return "Febrero";
                    case 3:
                        return "Marzo";
                    case 4:
                        return "Abril";
                    case 5:
                        return "Mayo";
                    case 6:
                        return "Junio";
                    case 7:
                        return "Julio";
                    case 8:
                        return "Agosto";
                    case 9:
                        return "Septiembre";
                    case 10:
                        return "Octubre";
                    case 11:
                        return "Noviembre";
                    default:
                        return "Diciembre";
                }
            }
        }
        public decimal? Antiguedad {
            get
            {
                return ((Monto??0) * 1.92M) / 100;
            }
        }
        public decimal? Indepnizacion
        {
            get
            {
                return ((Monto??0) * 6.54M) / 100;
            }
        }
    }
}
