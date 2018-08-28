using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehrdimensionaleArrays
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class oldProgramm
    { 
        //Deklaration des arrays
        private static bool[,] sitzPlatzPosition;
        private static int[] tempSeatPosition;

        private static int platzNummer;
        private static string output = "";
        private static bool isNotValid = true;
        private static string errMsgInt = "Ungueltige Eingabe. Bitte ganze Zahl eingeben!";
        private static string errMsgNegInt = "Negative Zahlen sind nicht zulaessig! Bitte erneut ";
        private static int seatOrderInt = 0;
        private static int rowOfSeats = 0;
        private static int freeSeatsinRow = 0;
        private static string seatSuggestion = "";
        private static int checkedInt=0;
            
        // Ausgabe der Platzbelegung
        private static void ShowSeatAssignment()
        {
            platzNummer = 1;
            for (int reihe = 0; reihe < sitzPlatzPosition.GetLength(0); reihe++)
            {
                for (int platz = 0; platz < sitzPlatzPosition.GetLength(1); platz++)
                {
                    if (sitzPlatzPosition[reihe, platz] == false)
                    {//.padleft4
                        output = string.Format(" {0,3} ", platzNummer++, "");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(output);
                    }
                    else
                    {
                        output = string.Format(" {0,3} ", platzNummer++, "");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(output);
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\t\t\tSitzplatzreservierung");
        
            Console.WriteLine();
            Console.Write("{0}) {1}", 1, "Zeige Platzbelegung\t\t");
            Console.Write("{0}) {1}", 2, "Sitzplatzreservierung\t\t");
            Console.WriteLine("{0}) {1}",0,"Abbruch");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void CheckInt()
        {
            string temp = "";
            checkedInt = 0;
            isNotValid = true;
            do
            {
                Console.Write("Zahl eingeben: ");
                temp = Console.ReadLine();
                try
                {
                    checkedInt = int.Parse(temp);
                    
                    if (checkedInt > 2)
                    {
                        Console.WriteLine("Die {0} ist keine gueltige Auswahl!",checkedInt);
                    }
                    
                    else if (checkedInt < 0)
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
        private static void IsValidSeat()
        {
            isNotValid = true;
            do
            {
                try
                {   //0 als exit char muss noch konfiguriert werden.
                    seatOrderInt = int.Parse(Console.ReadLine());
                   if (seatOrderInt < 1)
                    {
                        Console.WriteLine(errMsgNegInt);
                    }
                    
                    else if (seatOrderInt > sitzPlatzPosition.Length)
                    {
                        Console.WriteLine("Sie moechten mehr Sitze reservieren als vorhanden. Es gibt maximal {0} Sitzplaetze!",sitzPlatzPosition.Length);
                    }
                    else if(CountFreeSeatsInRow() < seatOrderInt)
                    {
                        Console.Write("Sie koennen maximal {0} Sitze reservieren,jedoch keine {1}",freeSeatsinRow, seatOrderInt);
                    }
                    else if (freeSeatsinRow < seatOrderInt)
                    {
                        Console.WriteLine("Es gibt in der Sitzplatzreihe {0} keine {1} freien Sitze",rowOfSeats,seatOrderInt);

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
        private static void Sitzplatzreservierung()
        {
            Console.Clear();
            Console.Write("In welcher Reihe möchten Sie die Sitze reservieren? :");
            IsvalidRow();

            Console.Write("Wie viele Pleatze moechten Sie reservieren? :");
            IsValidSeat();  
        }
        
        

        private static void IsvalidRow()
        {
            {
                do
                {
                    isNotValid = true;
                    try
                    {
                        rowOfSeats = int.Parse(Console.ReadLine()) - 1;
                        if (rowOfSeats < 0)
                        {
                            Console.WriteLine(errMsgNegInt);
                        }
                        else if (rowOfSeats > sitzPlatzPosition.GetLength(0))
                        {
                            Console.WriteLine("Die Sitzplatzreihe {0} existiert nicht! Bitte Waehlen Sie eine Reihe von 1 bis 10 aus.", rowOfSeats);
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
        }
        //public static void SeatSuggestion()
        //{
            
        //    for (int i = seatOrderInt; i != 0 ; i--)
        //    {
        //        if (sitzPlatzPosition[rowOfSeats, i].Equals(false) )
        //        {
        //            seatSuggestion +=i+" ";

                    
        //            sitzPlatzPosition[rowOfSeats, i] = true;
        //        }
        //        else
        //        {
        //            if (sitzPlatzPosition[rowOfSeats, i].Equals(true))
        //            {
        //                //erstmal nichts machen
        //            }
        //        }
        //    }
        //}
        public void CheckAndBookSeats()
        {
            string temp = "";
            tempSeatPosition = new int[seatOrderInt];
            bool enoughSeatsInRow = false;
            int countCoherentlySeats = 0;
            do
            {
                {//Genug sitze nebeneinander in reihe?
                    //Sitzreihe durchlaufen
                    for (int i = 0; i < 20; i++)
                    {
                        for (int p = 0; p < seatOrderInt; p++)
                        {
                            if (sitzPlatzPosition[rowOfSeats, i] == false)
                            { //wenn Sitz frei
                              
                                tempSeatPosition[seatOrderInt - countCoherentlySeats] = i;
                                countCoherentlySeats++;
                            }
                            //testen ob letzte reihe, dann nächste reihe = 0
                            if (sitzPlatzPosition[rowOfSeats, i] == true)
                                // dann ab nächstem Platz von vorne beginnen
                                countCoherentlySeats = 0;
                            
                            {//wenn letzte reihe und letzter Platz dann in der ersten reihe weitersuchen
                                if (rowOfSeats == 19 && i==19)
                                {
                                    rowOfSeats = 0;
                                    Console.WriteLine("In der Reihe {0} gibt es leider nicht genug nebeneinander liegende Sitze.", rowOfSeats);
                                    Console.WriteLine("Es wird nun versucht in Reihe {0} {1} freie Sitze zu finden.", rowOfSeats, seatOrderInt);
                                    CheckAndBookSeats();
                                }
                                Console.WriteLine("In Reihe {0} gibt es keine {1} nebeneinander liegende Sitze", rowOfSeats, seatOrderInt);

                                Console.WriteLine("Reihe {0} wird nun auf genung Nebeneinander liegenede Sitze überprüft...", rowOfSeats + 1);
                                //nächste reihe prüfen...
                            }
                        }
                        
                    }

                } while (true);

            } while (countCoherentlySeats != seatOrderInt);
  
        }

        public static int CountFreeSeatsInRow()
        {
            for (int i = 0; i < sitzPlatzPosition.GetLength(1); i++)
            {
                if (sitzPlatzPosition[rowOfSeats, i].Equals(false))
                {
                    freeSeatsinRow++;
                } 
            }
            return freeSeatsinRow;
        }

        private static void SwitchOption()
        {
            
                switch (checkedInt)
                {
                    //case 0:
                    //default:
                    //    Console.WriteLine("Programm wird beendet...");
                    //    Console.ReadKey();
                    //    break;
                    case 1:
                        ShowSeatAssignment();

                        break;
                    case 2:

                        Sitzplatzreservierung();
                        //SeatSuggestion();
                        Console.WriteLine("Folgende Plaetze sind fuer Sie vorgesehen: {0}", seatSuggestion);

                        Console.ReadKey();
                        break;
                }
            
        }
        static void OldMain(string[] args)
        //Sitzplaetze = 10 Reihen mit jeweils 20 Plaetzen
        {   //[Y,X] Achse
            //false = frei
            sitzPlatzPosition = new bool[10, 20];

            //Plätze besetzen
            sitzPlatzPosition[1,4] = true;
            sitzPlatzPosition[4,8] = true;
            sitzPlatzPosition[9,19] = true;

            
            
            do
            {
                Console.Clear();
                Menu();
                CheckInt();
                SwitchOption();
            } while (checkedInt != 0);
            
        }
        
    }
}
