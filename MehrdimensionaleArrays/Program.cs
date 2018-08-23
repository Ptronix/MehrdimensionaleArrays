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
        private static string output = "";

        // Ausgabe der Platzbelegung
        private void ShowSeatAssignment()
        {
            for (int reihe = 0; reihe < sitzPlatzPosition.GetLength(0); reihe++)
            {
                for (int platz = 0; platz < sitzPlatzPosition.GetLength(1); platz++)
                {
                    if (sitzPlatzPosition[reihe, platz] == false)
                    {
                        output = String.Format(" {0,3} {1}", platzNummer++, "Free   ");

                        Console.Write(output);
                    }
                    else
                    {
                        output = String.Format(" {0,3} {1}", platzNummer++, "Not Free");
                        Console.Write(output);
                    }
                }
                Console.WriteLine();
            }
            Console.Read();
        }

        static void Main(string[] args)
            //Sitzplaetze = 10 Reihen mit jeweils 20 Plaetzen
        {   //[Y,X] Achse
            //StandardWert bool=false
            sitzPlatzPosition = new bool[10,20];

            //SitzPlatz Reihe 5 Platz 15 besetzen = true
            //sitzPlatzPosition[5, 15] = true;

           
            
            
           
            


        }
    }
}
