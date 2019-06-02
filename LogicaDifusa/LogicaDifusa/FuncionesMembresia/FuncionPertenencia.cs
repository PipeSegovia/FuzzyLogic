using System;
namespace LogicaDifusa.FuncionesMembresia
{
    public class FuncionPertenencia
    {
        private double gradoPertenencia;
        private double a;
        private double b;
        private double c;
        private double d;
        private double valorMinX;
        private double valorMaxX;
        private double distancia;
        private string nombre;

        public FuncionPertenencia(string _nombre, double _a, double _b)
        {
            nombre = _nombre;
            a = _a;
            b = _b;
            valorMinX = 0.0;
            valorMaxX = 0.0;
            distancia = 0.0;
        }

        public FuncionPertenencia(string _nombre, double _a, double _b, double _c, double _d)
        {
            nombre = _nombre;
            a = _a;
            b = _b;
            d = _d;
            c = _c;
            valorMinX = 0.0;
            valorMaxX = 0.0;
            distancia = 0.0;
        }


        public void determinarGradoPertenencia(double valorEntrada)
        {
            if(nombre == "Funcion L")
            {
                ejecutarFuncionL(valorEntrada);
            }
            else if(nombre == "Funcion Gamma")
            {
                ejecutarFuncionGamma(valorEntrada);
            }
            else if(nombre == "Funcion Trapezoidal")
            {
                ejecutarFuncionTrapezoidal(valorEntrada);
            }
        }

        private void ejecutarFuncionL(double valorEntrada)
        {
            if (valorEntrada <= a)
            {
                gradoPertenencia = 1;
            }
            else if ((valorEntrada > a) && (valorEntrada < b))
            {
                gradoPertenencia = ((b - valorEntrada) / (b - a));
            }
            else
            {
                gradoPertenencia = 0;
            }
        }

        private void ejecutarFuncionGamma(double valorEntrada)
        {
            if (valorEntrada <= a)
            {
                gradoPertenencia = 0;
            }
            else if ((valorEntrada > a) && (valorEntrada < b))
            {
                gradoPertenencia = ((valorEntrada - a) / (b - a));
            }
            else
            {
                gradoPertenencia = 1;
            }
        }

        private void ejecutarFuncionTrapezoidal(double valorEntrada)
        {
            if ((valorEntrada <= a) || (valorEntrada > d))
            {
                gradoPertenencia = 0;
            }
            else if ((valorEntrada > a) && (valorEntrada <= b))
            {
                gradoPertenencia = ((valorEntrada - a) / (b - a));
            }
            else if ((valorEntrada > c) && (valorEntrada <= d))
            {
                gradoPertenencia = ((d - valorEntrada) / (d - c));
            }
            else
            {
                gradoPertenencia = 1;
            }
        }

        public double ValorMinimoX
        {
            get { return valorMinX; }
            set { valorMinX = value; }
        }

        public double ValorMaximoX
        {
            get { return valorMaxX; }
            set { valorMaxX = value; }
        }

        public double Distancia
        {
            get { return distancia; }
            set { distancia = value; }
        }

        public double GradoPertenencia
        {
            get { return gradoPertenencia; }
        }

    }
}
