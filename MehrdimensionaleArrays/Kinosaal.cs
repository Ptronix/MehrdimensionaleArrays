using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehrdimensionaleArrays
{
    class Kinosaal
    {
        /// <summary>
        /// false = frei true= besetzt
        /// </summary>
        private bool[,] sitzplaetze = new bool[10,20];

        /// <summary>
        /// Gibt die Sitzplatzbelegung farbig aus
        /// </summary>
        public void SitzplaetzeAusgeben()
        {
            int platzNummer = 1;
            for (int reihe = 0; reihe < sitzplaetze.GetLength(0); reihe++)
            {
                for (int platz = 0; platz < sitzplaetze.GetLength(1); platz++)
                {
                    // is seat is free print green else red
                    if (sitzplaetze[reihe, platz] == false)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    //print the platznummer
                    Console.Write(string.Format(" {0,3} ", platzNummer++, ""));
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anzahlSitze">Menge der benoetigten Sitzplaetze</param>
        /// <param name="reihe">Gewuenschte Sitzplatzreihe, 1 basiert</param>
        public void SitzplatzBuchen(int reihe, int anzahlSitze )
        {
            int[] tempSeatPosition = new int[anzahlSitze];
            int countCoherentlySeats = 0;

            for (int platz = 0; platz < sitzplaetze.GetLength(1); platz++)
            {
                if (sitzplaetze[reihe - 1, platz] == true)
                    countCoherentlySeats = 0;
                else
                    tempSeatPosition[countCoherentlySeats++] = platz;

                // Abbruch wenn geforderte Sitze = freie Sitze
                if (countCoherentlySeats == anzahlSitze)
                {
                    foreach (int seat in tempSeatPosition)
                        sitzplaetze[reihe - 1, seat] = true;

                    break;
                }

            }
        }
        
        /// <summary>
        /// row 1 -10
        /// </summary>
        /// <param name="row">row 1 basiert</param>
        /// <returns></returns>
        public bool IsValidRow(int row)
        {
            if (row > sitzplaetze.GetLength(0) || row < 1)
                return false;
            else
                return true;
        }
        /// <summary>
        /// seat 1 - 20
        /// </summary>
        /// <param name="seat"></param>
        /// <returns></returns>
        public bool IsValidSeat(int seat)
        {
            if (seat > sitzplaetze.GetLength(1) || seat < 1)
                return false;
            else
                return true;
        }
    }
}
