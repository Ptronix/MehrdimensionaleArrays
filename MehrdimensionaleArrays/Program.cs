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
       // private static int selection = 0;
        private static bool isNotValid = true;
        private static string errMsgInt = "Ungueltige Eingabe. Bitte ganze Zahl eingeben!";
        private static string errMsgNegInt = "Negative Zahlen sind nicht zulaessig! Bitte erneut ";
        private static int checkedInt=0;

        // Ausgabe der Platzbelegung
        private static void ShowSeatAssignment()
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

        private static void Menu()
        {
            Console.WriteLine("\t\tSitzplatzreservierung");

            Console.WriteLine("\nMenu");
            Console.WriteLine("Bitte Zahl eingeben");
            Console.WriteLine("{0}) {1}", 1, "Zeige Platzbelegung");
            Console.WriteLine("{0}) {1}", 2, "Sitzplatzreservierung");

        }
        private static void CheckInt()
        {
            do
            {
                try
                {
                    //isNotValid = (checkedInt < 1) ? false : Console.WriteLine(); ;
                    checkedInt = int.Parse(Console.ReadLine());
                    if (checkedInt < 1)
                    {
                        Console.WriteLine(errMsgNegInt);
                    }
                    else
                    {
                        isNotValid = false;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(errMsgInt);
                }
            }
            while (isNotValid);
        }

        static void Main(string[] args)
        //Sitzplaetze = 10 Reihen mit jeweils 20 Plaetzen
        {   //[Y,X] Achse
            //false = frei

            sitzPlatzPosition = new bool[10, 20];
            Menu();
            CheckInt();

            switch (checkedInt)
            {
                case 1:
                    ShowSeatAssignment();
                    Console.ReadLine();
                    break;
                case 2:

                    break;

                default:
                    break;
            }
            //  ShowSeatAssignment();







        }
    }
}
