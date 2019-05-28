using System;
using System.Collections.Generic;
namespace LogicaDifusa.FuncionesMembresia
{
    public class FuncionMembresia
    {

        private string nombre;
        private List<ConjuntoDifuso> conjuntosDifusos;

        public FuncionMembresia(string _nombre,List<ConjuntoDifuso> conjuntos)
        {
            nombre = _nombre;
            conjuntosDifusos = conjuntos;
        }

        public string Nombre
        {
            get { return nombre; }
        }

        public List<ConjuntoDifuso> ConjuntosDifusos
        {
            get { return conjuntosDifusos; }
        }
    }
}
