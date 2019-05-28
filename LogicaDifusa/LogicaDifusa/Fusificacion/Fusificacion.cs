using System;
using System.Collections.Generic;
using LogicaDifusa.FuncionesMembresia;

namespace LogicaDifusa.Fusificacion
{
    public class Fusificacion
    {
        List<FuncionMembresia> entradasDifusas;
        Dictionary<string, double> entradaNitida; 

        public Fusificacion(List<FuncionMembresia> _entradasDifusas)
        {

            entradasDifusas = _entradasDifusas;
            entradaNitida = new Dictionary<string, double>();

        }

        public void agregarEntrada(string _nombre, double valorEntrada)
        {
            entradaNitida.Add(_nombre,valorEntrada);
        }

        public void fusificar()
        {
            foreach(KeyValuePair<string,double> item in entradaNitida)
            {
                for(int i = 0; i < entradasDifusas.Count;i++)
                {
                    if(item.Key == entradasDifusas[i].Nombre)
                    {
                        for(int j = 0; j < entradasDifusas[i].ConjuntosDifusos.Count;j++)
                        {
                            entradasDifusas[i].ConjuntosDifusos[j].determinarGradoPertenencia(item.Value);
                        }
                    }
                }
            }
        }


        public List<FuncionMembresia> EntradasFusificadas
        {
            get { return entradasDifusas; }
        }

    }
}
