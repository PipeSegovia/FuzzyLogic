using System;
using System.Collections.Generic;
using LogicaDifusa.FuncionesMembresia;
using LogicaDifusa.Fusificacion;

namespace LogicaDifusa
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("-------------LOGICA DIFUSA-------");

            //Se definen los conjuntos difusos de entrada

            List<ConjuntoDifuso> conjuntosTipoSonido = new List<ConjuntoDifuso>
            {
                new ConjuntoDifuso("Otro", new FuncionPertenencia("Funcion L",0.3, 0.4)),
                new ConjuntoDifuso("Humano", new FuncionPertenencia("Funcion Trapezoidal",0.3, 0.4, 0.6, 0.8)),
                new ConjuntoDifuso("Bebe", new FuncionPertenencia("Funcion Gamma",0.6, 0.8))
            };

            List<ConjuntoDifuso> conjuntosIntensidad = new List<ConjuntoDifuso>
            {
                new ConjuntoDifuso("Debil", new FuncionPertenencia("Funcion L",0.3,0.6)),
                new ConjuntoDifuso("Fuerte",new FuncionPertenencia("Funcion Gamma",0.4,0.6))
            };


            List<ConjuntoDifuso> conjuntosDuracion = new List<ConjuntoDifuso>()
            {
                new ConjuntoDifuso("Puntual", new FuncionPertenencia("Funcion L",0.1,0.2)),
                new ConjuntoDifuso("Normal", new FuncionPertenencia("Funcion Trapezoidal",0.1,0.2,0.5,0.7)),
                new ConjuntoDifuso("Continuo", new FuncionPertenencia("Funcion Gamma",0.5, 0.7))
            };



            List<FuncionMembresia> entradasDifusas = new List<FuncionMembresia>()
            {
                new FuncionMembresia("TipoSonido", conjuntosTipoSonido),
                new FuncionMembresia("Intensidad", conjuntosIntensidad),
                new FuncionMembresia("Duracion", conjuntosDuracion)
            };



            //Se definen los conjuntos difusos de salida

            List<ConjuntoDifuso> conjuntosModo = new List<ConjuntoDifuso>()
            {
                new ConjuntoDifuso("Espera",new FuncionPertenencia("Funcion L",0.3,0.7)),
                new ConjuntoDifuso("Normal", new FuncionPertenencia("Funcion Gamma",0.3,0.7))
            };

            FuncionMembresia modo = new FuncionMembresia("Modo", conjuntosModo);


            //Proceso de fusificacion

            Fusificacion.Fusificacion fusificador = new Fusificacion.Fusificacion(entradasDifusas);

            fusificador.agregarEntrada("TipoSonido", 0.75);
            fusificador.agregarEntrada("Intensidad", 0.57);
            fusificador.agregarEntrada("Duracion", 0.54);

            fusificador.fusificar();

            List<FuncionMembresia> entradasFusificadas = fusificador.EntradasFusificadas;

            Console.ReadLine();
        }
    }
}
