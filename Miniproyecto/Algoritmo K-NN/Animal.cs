using System;
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
    internal class Animal
    {
        public string nombre { get; set; }
        public double pelo { get; set; }
        public double plumas { get; set; }
        public double tomaLeche { get; set; }
        public double esqueleto { get; set; }
        public double acuatico { get; set; }
        public double predador { get; set; }
        public double dientes { get; set; }
        public double columnaVertebral { get; set; }
        public double respira { get; set; }
        public double venenoso { get; set; }
        public double piernas { get; set; }
        public double cola { get; set; }
        public double domestico { get; set; }
        public double tamañoMedio { get; set; }
        public double CLASS { get; set; }

        //Constructor
        public Animal(string nombre, double pelo, double plumas, double tomaLeche, double esqueleto, double acuatico, double predador,
            double dientes, double columnaVertebral, double respira, double venenoso, double piernas, double cola, double domestico,
            double tamañoMedio, double cLASS)
        {
            this.nombre = nombre;
            this.pelo = pelo;
            this.plumas = plumas;
            this.tomaLeche = tomaLeche;
            this.esqueleto = esqueleto;
            this.acuatico = acuatico;
            this.predador = predador;
            this.dientes = dientes;
            this.columnaVertebral = columnaVertebral;
            this.respira = respira;
            this.venenoso = venenoso;
            this.piernas = piernas;
            this.cola = cola;
            this.domestico = domestico;
            this.tamañoMedio = tamañoMedio;
            CLASS = cLASS;
        }
    }
}
