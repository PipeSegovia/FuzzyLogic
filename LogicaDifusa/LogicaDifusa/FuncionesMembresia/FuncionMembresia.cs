using System;
using System.Collections.Generic;
namespace LogicaDifusa.FuncionesMembresia
{
    public class FuncionMembresia
    {

        private string nombre;
        private List<ConjuntoDifuso> conjuntosDifusos;
        private ConjuntoDifuso conjunto;

        public FuncionMembresia(string _nombre, List<ConjuntoDifuso> conjuntos)
        {
            nombre = _nombre;
            conjuntosDifusos = conjuntos;
        }

        public FuncionMembresia(string _nombre, ConjuntoDifuso _conjunto)
        {
            nombre = _nombre;
            conjunto = _conjunto;
        }


        public string Nombre
        {
            get { return nombre; }
        }

        public List<ConjuntoDifuso> ConjuntosDifusos
        {
            get { return conjuntosDifusos; }
        }

        public ConjuntoDifuso Conjunto
        {
            get { return conjunto; }
        }
    }
}
