using System;
namespace LogicaDifusa.FuncionesMembresia
{
    public class ConjuntoDifuso
    {
        private string nombre;
        private double altura;
        private FuncionPertenencia funcionPertenencia;
        private double gradoPertenencia;


        public ConjuntoDifuso(string _nombre, FuncionPertenencia _funcionPertenencia)
        {
            nombre = _nombre;
            funcionPertenencia = _funcionPertenencia;
            altura = 1;
            gradoPertenencia = 0.0;
        }

        public void agregarLimitesConjunto(double limiteInferior, double limiteSuperior, double distancia)
        {
            funcionPertenencia.ValorMinimoX = limiteInferior;
            funcionPertenencia.ValorMaximoX = limiteSuperior;
            funcionPertenencia.Distancia = distancia;
        }

        public void determinarGradoPertenencia(double valorEntrada)
        {
            funcionPertenencia.determinarGradoPertenencia(valorEntrada);
            gradoPertenencia = funcionPertenencia.GradoPertenencia;
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public double Altura
        {
            get { return altura; }
            set { altura = value; }
        }

        public FuncionPertenencia FuncionPertenencia
        {
            get { return funcionPertenencia; }
        }

        public double GradoPertenencia
        {
            get { return gradoPertenencia; }
            set { gradoPertenencia = value; }
        }
    }
}
