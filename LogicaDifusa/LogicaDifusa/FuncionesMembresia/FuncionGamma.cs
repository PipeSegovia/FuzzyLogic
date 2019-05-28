using System;
namespace LogicaDifusa.FuncionesMembresia
{
    public class FuncionGamma
    {

        private double a;
        private double b;

        public FuncionGamma(double _a, double _b)
        {
            a = _a;
            b = _b;
        }

        public double determinarGradoPertenencia(double valorEntrada)
        {
            if(valorEntrada <= a)
            {
                return 0;
            }
            else if((valorEntrada > a) && (valorEntrada < b))
            {
                return ((valorEntrada -a ) / (b - a));
            }
            else
            {
                return 1;
            }
        }
    }
}
