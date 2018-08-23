using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehrdimensionaleArrays
{
    class Program
    {
        //Deklaration des arrays
        private static bool[,] sitzPlatzPosition;

        private static int platzNummer = 1;

        static void Main(string[] args)
            //Sitzplaetze = 10 Reihen mit jeweils 20 Plaetzen
        {   //[Y,X] Achse
            //StandardWert bool=false
            sitzPlatzPosition = new bool[10,20];

            //SitzPlatz Reihe 5 Platz 15 besetzen = true
            sitzPlatzPosition[5, 15] = true;

            // Ausgabe der Platzbelegung

            for (int reihe = 0; reihe < sitzPlatzPosition.GetLength(0); reihe++)
            {
                for (int platz = 0; platz < sitzPlatzPosition.GetLength(1); platz++)
                {
                    if (sitzPlatzPosition[reihe,platz] == false)
                    {
                        Console.Write(" " + platzNummer++ + " ");
                        Console.Write("O");
                    }
                    else
                    {
                        Console.Write(" "+platzNummer+++" ");
                        Console.Write("X");
                    }
                }
                Console.WriteLine();
            }
            Console.Read();

           

            //instanziieren
            


        }
    }
}
