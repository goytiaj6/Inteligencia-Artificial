using SpreadsheetLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Miniproyecto Inteligencia Artificial
/// Integrantes:
/// Goytia González Jorge Hadamard
/// Jimenez Ramirez Lizeth

namespace Algoritmo_K_NN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaramos una lista de animales previamente clasificados y a calsificar
            List<Animal> Class = new List<Animal>();
            List<Animal> NO_class = new List<Animal>();

            //Mediante la API SpreadsheetLight se obtienen los datos de los archivos CSV, que se convirtieron a xlsx
            //dado que siempre mostraba aviso de que los datos estaban dañados
            using (SLDocument sl = new SLDocument("C:/Users/jorge/Documents/Facultad/SEM2022-2/Intelegencia Artificial/" +
                "Miniproyecto/Algoritmo K-NN/animals.xlsx"))
            {
                //Nos posicionamos en el segundo renglon de la hoja de calculo
                int iRow = 2;
                //Mientras las celdas no estan vacias
                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    //Leemos las celdas y obtenemos los valores
                    string nombre = sl.GetCellValueAsString(iRow, 1);
                    double pelo = sl.GetCellValueAsDouble(iRow, 2);
                    double plumas = sl.GetCellValueAsDouble(iRow, 3);
                    double tomaLeche = sl.GetCellValueAsDouble(iRow, 4);
                    double esqueleto = sl.GetCellValueAsDouble(iRow, 5);
                    double acuatico = sl.GetCellValueAsDouble(iRow, 6);
                    double predador = sl.GetCellValueAsDouble(iRow, 7);
                    double dientes = sl.GetCellValueAsDouble(iRow, 8);
                    double columnaVertebral = sl.GetCellValueAsDouble(iRow, 9);
                    double respira = sl.GetCellValueAsDouble(iRow, 10);
                    double venenoso = sl.GetCellValueAsDouble(iRow, 11);
                    double piernas = sl.GetCellValueAsDouble(iRow, 12);
                    double cola = sl.GetCellValueAsDouble(iRow, 13);
                    double domestico = sl.GetCellValueAsDouble(iRow, 14);
                    double tamañoMedio = sl.GetCellValueAsDouble(iRow, 15);
                    double cLASS = sl.GetCellValueAsDouble(iRow, 16);
                    //Creamos el objeto animal con los atributos leidos de excel
                    Animal animal = new Animal(nombre, pelo, plumas, tomaLeche,
                        esqueleto, acuatico, predador, dientes, columnaVertebral,
                        respira, venenoso, piernas, cola, domestico, tamañoMedio, cLASS);
                    //Agregamos el nuevo animal a la lista
                    Class.Add(animal);
                    //Siguiente renglón
                    iRow++;
                }
                //Se hace el conteo de animales clasificados
                Class.Count();
            }
            //Abrimos la hoja de calculo con los animales sin clasificar
            using (SLDocument sl = new SLDocument("C:/Users/jorge/Documents/Facultad/SEM2022-2/Intelegencia Artificial/" +
                "Miniproyecto/Algoritmo K-NN/animals_clasificar.xlsx"))
            {
                //Nos posicionamos en el segundo renglon de la hoja de calculo
                int iRow = 2;
                //Mientras las celdas no estan vacias
                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    //Leemos las celdas y obtenemos los valores
                    string nombre = sl.GetCellValueAsString(iRow, 1);
                    double pelo = sl.GetCellValueAsDouble(iRow, 2);
                    double plumas = sl.GetCellValueAsDouble(iRow, 3);
                    double tomaLeche = sl.GetCellValueAsDouble(iRow, 4);
                    double esqueleto = sl.GetCellValueAsDouble(iRow, 5);
                    double acuatico = sl.GetCellValueAsDouble(iRow, 6);
                    double predador = sl.GetCellValueAsDouble(iRow, 7);
                    double dientes = sl.GetCellValueAsDouble(iRow, 8);
                    double columnaVertebral = sl.GetCellValueAsDouble(iRow, 9);
                    double respira = sl.GetCellValueAsDouble(iRow, 10);
                    double venenoso = sl.GetCellValueAsDouble(iRow, 11);
                    double piernas = sl.GetCellValueAsDouble(iRow, 12);
                    double cola = sl.GetCellValueAsDouble(iRow, 13);
                    double domestico = sl.GetCellValueAsDouble(iRow, 14);
                    double tamañoMedio = sl.GetCellValueAsDouble(iRow, 15);
                    double cLASS = sl.GetCellValueAsDouble(iRow, 16);
                    //Creamos el objeto animal con los atributos leidos de excel
                    Animal animal = new Animal(nombre, pelo, plumas, tomaLeche,
                        esqueleto, acuatico, predador, dientes, columnaVertebral,
                        respira, venenoso, piernas, cola, domestico, tamañoMedio, cLASS);
                    //Agregamos el nuevo animal a la lista
                    NO_class.Add(animal);
                    //Siguiente renglón
                    iRow++;
                }
            }
            //Convertimos las listas en arreglos para usarlas en los métodos
            Animal[] Class1 = Class.ToArray();
            Animal[] Class2 = NO_class.ToArray();
            //Se llama a los métodos
            Euclidiana(Class2, Class1);
            Manhattan(Class2, Class1);
            //Mostramos animales de muestra y base de datos
            Console.WriteLine("\n Existen {0} animales ya clasificados", Class.Count());
            Console.WriteLine("\n Se clasificaron {0} animales", NO_class.Count());
            Console.ReadLine();
        }

        //MÉTODOS
        /// <summary>
        /// Metodo para la distancia euclidiana y clasificacion
        /// </summary>
        /// <param name="animals"> Arreglo sin clases </param>
        /// <param name="animalsClss"> Arreglo con clases </param>
        public static void Euclidiana(Animal[] animals, Animal[] animalsClss)
        {
            Console.WriteLine("\n Empleando la distancia Euclidiana");
            //Listas y arreglos auxiliar para las clases y distancias
            //var Clases = new double[87];
            var ClssList = new List<double>(87);
            var DistClssList = new List<Tuple<double, double>>(87);
            //var Dist = new double[87];
            //var DistOrd = new double[87];
            //Se calcula la distancia euclidiana de todos los datos clasificados por cada elemento
            for (int i = 0; i < animals.Length; i++)
            {
                Console.WriteLine(" Comparando elemento {0}, {1}", i + 1, animals[i].nombre);
                //Console.WriteLine("Orden real   Clase   Ordenado");
                for (int k = 0; k < animalsClss.Length; k++)
                {
                    //Se calcula la distancia euclidiana
                    double output = Math.Sqrt(
                        Math.Pow(animals[i].acuatico - animalsClss[k].acuatico, 2)
                        + Math.Pow(animals[i].cola - animalsClss[k].cola, 2)
                        + Math.Pow(animals[i].columnaVertebral - animalsClss[k].columnaVertebral, 2)
                        + Math.Pow(animals[i].dientes - animalsClss[k].dientes, 2)
                        + Math.Pow(animals[i].domestico - animalsClss[k].domestico, 2)
                        + Math.Pow(animals[i].esqueleto - animalsClss[k].esqueleto, 2)
                        + Math.Pow(animals[i].pelo - animalsClss[k].pelo, 2)
                        + Math.Pow(animals[i].piernas - animalsClss[k].piernas, 2)
                        + Math.Pow(animals[i].plumas - animalsClss[k].plumas, 2)
                        + Math.Pow(animals[i].predador - animalsClss[k].predador, 2)
                        + Math.Pow(animals[i].respira - animalsClss[k].respira, 2)
                        + Math.Pow(animals[i].tamañoMedio - animalsClss[k].tamañoMedio, 2)
                        + Math.Pow(animals[i].tomaLeche - animalsClss[k].tomaLeche, 2)
                        + Math.Pow(animals[i].venenoso - animalsClss[k].venenoso, 2));
                    output = Math.Round((output * 1000) / 1000, 3);
                    //Se agregan datos a los arreglos de clases y distancias
                    //Clases[k] = animalsClss[k].CLASS;
                    ClssList.Add(animalsClss[k].CLASS);
                    //Dist[k] = output;
                    //DistOrd[k] = output;
                    var tupla = new Tuple<double, double>(output, animalsClss[k].CLASS);
                    DistClssList.Add(tupla);
                    //Console.WriteLine(" Distancia: " + Dist[k] + " Clase: " + Clases[k]);
                }
                //Realizamos el ordenamiento de la lista de tuplas, en base a la distancia
                List<Tuple<double, double>> Sorted = DistClssList.OrderBy(Tuple => Tuple.Item1).ThenBy(Tuple => Tuple.Item2).ToList();
                //Console.WriteLine("\n Elementos ordenados por distnacia");
                //foreach (Tuple<double, double> tupla in Sorted)
                    //Console.WriteLine(" Distancia: " + tupla.Item1 + "       Clase: " + tupla.Item2);

                //Agregamos la clase a la lista de clases
                for (int j = 0; j < ClssList.Count(); j ++)
                {
                    ClssList[j] = Sorted[j].Item2;
                }
                //Mostrando la clasificación en base a los vecinos cercanos
                for (int l = 2; l <= 10; l ++)
                {
                    Console.WriteLine("\n Comparamos con {0} vecinos cercanos", l);
                    var arreglo1 = new List<Tuple<double, double>>(l);
                    var arreglo2 = new double[l];
                    for (int m = 0; m < l; m++)
                    {
                        arreglo1.Insert(m, Sorted[m]);
                        arreglo2[m] = ClssList[m];
                        Console.WriteLine(" Distancia: " + arreglo1[m].Item1 + "   Clase: " + arreglo1[m].Item2);
                    }
                    //Agrupando coincidencias y contando los elementos por grupo
                    var clase = arreglo2.GroupBy(x => x);
                    var Maxrep = clase.OrderByDescending(x => x.Count()).First();
                    Console.WriteLine(" El elemento pertenece a la clase: {0}", Maxrep.Key, Maxrep.Count());
                }
                //Depuramos los arreglos y listas
                //Array.Clear(Clases, 0, 87);
                //Array.Clear(Dist, 0, 87);
                //Array.Clear(DistOrd, 0, 87);
                ClssList.Clear();
                DistClssList.Clear();
                //Se espera una tecla para continuar y limpiar pantalla
                Console.ReadLine();
                Console.Clear();
            }
        }

        //Metodo para la distancia manhattan y clasificacion
        /// <summary>
        /// Metodo para la distancia manhattan y clasificacion
        /// </summary>
        /// <param name="animals"> Arreglo sin clases </param>
        /// <param name="animalsClss"> Arreglo con clases </param>
        public static void Manhattan(Animal[] animals, Animal[] animalsClss)
        {
            Console.WriteLine("\n Empleando la distancia Manhattan");
            //Lista auxiliar para las clases y distancias
            //var Clases = new double[87];
            var ClssList = new List<double>(87);
            var DistClssList = new List<Tuple<double, double>>(87);
            //var Dist = new double[87];
            //var DistOrd = new double[87];
            //Se calcula la distancia euclidiana de todos los datos clasificados por cada elemento
            for (int i = 0; i < animals.Length; i++)
            {
                Console.WriteLine(" Comparando elemento {0}, {1}", i + 1, animals[i].nombre);
                //Console.WriteLine("Orden real   Clase   Ordenado");
                for (int k = 0; k < animalsClss.Length; k++)
                {
                    //Se calcula la distancia euclidiana
                    double output = Math.Abs(animals[i].acuatico - animalsClss[k].acuatico)
                        + Math.Abs(animals[i].cola - animalsClss[k].cola)
                        + Math.Abs(animals[i].columnaVertebral - animalsClss[k].columnaVertebral)
                        + Math.Abs(animals[i].dientes - animalsClss[k].dientes)
                        + Math.Abs(animals[i].domestico - animalsClss[k].domestico)
                        + Math.Abs(animals[i].esqueleto - animalsClss[k].esqueleto)
                        + Math.Abs(animals[i].pelo - animalsClss[k].pelo)
                        + Math.Abs(animals[i].piernas - animalsClss[k].piernas)
                        + Math.Abs(animals[i].plumas - animalsClss[k].plumas)
                        + Math.Abs(animals[i].predador - animalsClss[k].predador)
                        + Math.Abs(animals[i].respira - animalsClss[k].respira)
                        + Math.Abs(animals[i].tamañoMedio - animalsClss[k].tamañoMedio)
                        + Math.Abs(animals[i].tomaLeche - animalsClss[k].tomaLeche)
                        + Math.Abs(animals[i].venenoso - animalsClss[k].venenoso);
                    output = Math.Round((output * 1000) / 1000, 3);
                    //Se agregan datos a los arreglos de clases y distancias
                    //Clases[k] = animalsClss[k].CLASS;
                    ClssList.Add(animalsClss[k].CLASS);
                    //Dist[k] = output;
                    //DistOrd[k] = output;
                    var tupla = new Tuple<double, double>(output, animalsClss[k].CLASS);
                    DistClssList.Add(tupla);
                    //Console.WriteLine(" Distancia: " + Dist[k] + " Clase: " + Clases[k]);
                }
                //Realizamos el ordenamiento de la lista de tuplas, en base a la distancia
                List<Tuple<double, double>> Sorted = DistClssList.OrderBy(Tuple => Tuple.Item1).ThenBy(Tuple => Tuple.Item2).ToList();
                //Console.WriteLine("\n Elementos ordenados por distnacia");
                //foreach (Tuple<double, double> tupla in Sorted)
                //Console.WriteLine(" Distancia: " + tupla.Item1 + "       Clase: " + tupla.Item2);

                //Agregamos la clase a la lista de clases
                for (int j = 0; j < ClssList.Count(); j++)
                {
                    ClssList[j] = Sorted[j].Item2;
                }
                //Mostrando la clasificación
                for (int l = 2; l <= 10; l++)
                {
                    Console.WriteLine("\n Comparamos con {0} vecinos cercanos", l);
                    var arreglo1 = new List<Tuple<double, double>>(l);
                    var arreglo2 = new double[l];
                    for (int m = 0; m < l; m++)
                    {
                        arreglo1.Insert(m, Sorted[m]);
                        arreglo2[m] = ClssList[m];
                        Console.WriteLine(" Distancia: " + arreglo1[m].Item1 + "   Clase: " + arreglo1[m].Item2);
                    }
                    //Agrupando coincidencias y contando los elementos por grupo
                    var clase = arreglo2.GroupBy(x => x);
                    var Maxrep = clase.OrderByDescending(x => x.Count()).First();
                    Console.WriteLine(" El elemento pertenece a la clase: {0}", Maxrep.Key, Maxrep.Count());
                }
                //Depuramos los arreglos y listas
                //Array.Clear(Clases, 0, 87);
                //Array.Clear(Dist, 0, 87);
                //Array.Clear(DistOrd, 0, 87);
                ClssList.Clear();
                DistClssList.Clear();
                //Se espera una tecla para continuar y limpiar pantalla
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}