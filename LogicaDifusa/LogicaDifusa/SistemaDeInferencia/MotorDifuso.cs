using System;
using System.IO;
using System.Collections.Generic;
using LogicaDifusa.FuncionesMembresia;
using System.Linq;
namespace LogicaDifusa.SistemaDeInferencia
{
    public class MotorDifuso
    {

        private List<FuncionMembresia> entradasDifusas;
        private List<List<string>> reglasTransformadas = new List<List<string>>(); 
        private List<FuncionMembresia> entradasEvaluadas = new List<FuncionMembresia>();
        private FuncionMembresia salidaDifusa;
        string direccionBC;

        public MotorDifuso(List<FuncionMembresia> _entradasDifusas,FuncionMembresia _salidaDifusa, string _direccionBC)
        {
            entradasDifusas = _entradasDifusas;
            salidaDifusa = _salidaDifusa;
            direccionBC = _direccionBC;
        }

        public void inferir()
        {
            StreamReader archivoBC = new StreamReader(direccionBC);
            string linea;

            //Transformo la regla solo con operadores AND
            while((linea = archivoBC.ReadLine()) !=  null)
            {
                string[] tokenLinea = linea.Split();
                reglasTransformadas.Add(transformarRegla(tokenLinea));
            }
            //Evaluo las reglas
            for(int i = 0; i < reglasTransformadas.Count;i++)
            {
                 entradasEvaluadas.Add(evaluarRegla(reglasTransformadas[i]));
            }

        }

        //Transformo la regla solo en AND
        private List<string> transformarRegla(string[] regla)
        {
            FuncionMembresia listRegla;

            List<string> reglaAux = regla.ToList();
            for(int i = 0; i < reglaAux.Count;i++)
            {
                if(reglaAux[i] == "(")
                {
                    while(reglaAux[i] != ")")
                    {
                        if(reglaAux[i] == "OR")
                        {
                            listRegla = evaluarReglaOR(reglaAux[i-3], reglaAux[i-1], reglaAux[i + 1], reglaAux[i+3]);
                            i -= 4;
                            reglaAux.RemoveRange((i),8);

                            reglaAux.Insert(i, listRegla.Nombre);
                            reglaAux.Insert(i+1,"es");
                            reglaAux.Insert((i+2),listRegla.Conjunto.Nombre);

                        }
                        i++;
                    }
                    reglaAux.RemoveAt(i);
                    i = 0;
                }
            }

            return reglaAux;
        }

        //Evalua las variables linguisticas y valores linguisticos para calcular el MAX
        private FuncionMembresia evaluarReglaOR(string varLing1, string valLing1, string varLing2, string valLing2)
        {
            //busco los valores de los parametros en la variable "entradasDifusas"
            FuncionMembresia funcMem1 = null;
            FuncionMembresia funcMem2 = null;
            ConjuntoDifuso conjunto1;
            ConjuntoDifuso conjunto2;
            //Asigno las variables a comparar
            for (int i = 0; i < entradasDifusas.Count;i++)
            {
                if (entradasDifusas[i].Nombre == varLing1)
                {
                    for (int j = 0; j < entradasDifusas[i].ConjuntosDifusos.Count; j++)
                    {
                        if (entradasDifusas[i].ConjuntosDifusos[j].Nombre == valLing1)
                        {
                            conjunto1 = entradasDifusas[i].ConjuntosDifusos[j];
                            funcMem1 = new FuncionMembresia(entradasDifusas[i].Nombre, conjunto1);

                        }
                        else if (entradasDifusas[i].ConjuntosDifusos[j].Nombre == valLing2)
                        {
                            conjunto2 = entradasDifusas[i].ConjuntosDifusos[j];
                            funcMem2 = new FuncionMembresia(entradasDifusas[i].Nombre, conjunto2);
                        }
                    }
                }
            }

            //Evaluo a partir del metodoMax de mandani 
            if((funcMem1 != null) && (funcMem2 != null))
            {
                if (funcMem1.Conjunto.GradoPertenencia > funcMem2.Conjunto.GradoPertenencia)
                {
                    return funcMem1;
                }
                else
                {
                    return funcMem2;
                }
            }
            else
            {
                return null;
            }
        }

        //Evalua las reglas
        private FuncionMembresia evaluarRegla(List<string> reglaString)
        {
            FuncionMembresia salida = null;

            for(int j = 0; j < reglaString.Count;j++)
            {
                if(reglaString[j] == "AND")
                {
                    salida = buscarMin(reglaString[j - 3], reglaString[j - 1], reglaString[j + 1], reglaString[j + 3]);

                    j -= 3;
                    reglaString.RemoveRange((j), 7);

                    reglaString.Insert(j, salida.Nombre);
                    reglaString.Insert(j + 1, "es");
                    reglaString.Insert((j + 2), salida.Conjunto.Nombre);

                    j = 0;

                }
                else if(reglaString[j] == "THEN")
                {
                    FuncionMembresia salidaConsecuente = new FuncionMembresia(salida.Nombre,salida.Conjunto);

                    return salidaConsecuente;
                }
            }

            return salida;
        }

        //Calcula la regla min
        private FuncionMembresia buscarMin(string varLing1, string valLing1, string varLing2, string valLing2)
        {
            FuncionMembresia funcMem1 = null;
            FuncionMembresia funcMem2 = null;
            ConjuntoDifuso conjunto1;
            ConjuntoDifuso conjunto2;
            //Asigno las variables a comparar
            for (int i = 0; i < entradasDifusas.Count; i++)
            {
                if (entradasDifusas[i].Nombre == varLing1)
                {
                    for (int j = 0; j < entradasDifusas[i].ConjuntosDifusos.Count; j++)
                    {
                        if (entradasDifusas[i].ConjuntosDifusos[j].Nombre == valLing1)
                        {
                            conjunto1 = entradasDifusas[i].ConjuntosDifusos[j];
                            funcMem1 = new FuncionMembresia(entradasDifusas[i].Nombre, conjunto1);

                        }
                    }
                }
                else if(entradasDifusas[i].Nombre == varLing2)
                {
                    for (int j = 0; j < entradasDifusas[i].ConjuntosDifusos.Count; j++)
                    {
                        if (entradasDifusas[i].ConjuntosDifusos[j].Nombre == valLing2)
                        {
                            conjunto2 = entradasDifusas[i].ConjuntosDifusos[j];
                            funcMem2 = new FuncionMembresia(entradasDifusas[i].Nombre, conjunto2);

                        }
                    }
                }
            }
            //Evaluo a partir del metodoMax de mandani 
            if ((funcMem1 != null) && (funcMem2 != null))
            {
                if (funcMem1.Conjunto.GradoPertenencia < funcMem2.Conjunto.GradoPertenencia)
                {
                    return funcMem1;
                }
                else
                {
                    return funcMem2;
                }
            }
            else
            {
                return null;
            }



        }

    }
}
