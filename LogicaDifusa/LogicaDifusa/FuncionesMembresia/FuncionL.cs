using System;
namespace LogicaDifusa.FuncionesMembresia
{
    public class FuncionL
    {
        private double a;
        private double b;

        public FuncionL()
        {

        }

        public FuncionL(double _a,double _b)
        {
            a = _a;
            b = _b;
        }

        public double determinarGradoPertenencia(double valorEntrada)
        {
            if(valorEntrada <= a)
            {
                return 1;
            }
            else if((valorEntrada > a) && (valorEntrada < b))
            {
                return ((b - valorEntrada) / (b - a));
            }
            else
            {
                return 0;
            }
        }
    }
}
