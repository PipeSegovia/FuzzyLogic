using System;
namespace LogicaDifusa.FuncionesMembresia
{
    public class FuncionTrapezoidal
    {

        private double a;
        private double b;
        private double c;
        private double d;

        public FuncionTrapezoidal(double _a,double _b, double _c,double _d)
        {
            a = _a;
            b = _b;
            c = _c;
            d = _d;
        }

        public double determinarGradoPertenencia(double valorEntrada)
        {
            if((valorEntrada <= a) || (valorEntrada > d))
            {
                return 0;
            }
            else if((valorEntrada > a) && (valorEntrada <= b))
            {
                return ((valorEntrada - a) / (b - a));
            }
            else if((valorEntrada > c) && (valorEntrada <= d))
            {
                return ((d - valorEntrada) / (d - c));
            }
            else
            {
                return 1;
            }
        }
    }
}
