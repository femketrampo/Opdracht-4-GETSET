using System;
using System.Collections;
using System.Collections.Generic;

namespace Opdracht_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Bankrekening bankrekening = new Bankrekening();
            List<string> verrichtingen = new List<string>();
            int keuze;
            string antwoord;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("1) Geld storten");
                Console.WriteLine("2) Geld afhalen");
                Console.WriteLine("3) Balans weergeven");
                Console.WriteLine("4) Nieuw limiet instellen");
                Console.WriteLine("5) Verrichtingen bekijken");
                Console.WriteLine("6) Exit");
                Console.Write("Keuze: ");
                keuze = Convert.ToInt32(Console.ReadLine());

                if (keuze <= 6)
                {
                    switch (keuze)
                    {
                        case 1:
                            {
                                do
                                {
                                    bankrekening.Balans = bankrekening.Balans + Storten(bankrekening, verrichtingen);

                                    Console.Clear();
                                    Console.WriteLine("De balans bedraagd nu {0} euro.", bankrekening.Balans);

                                    Console.Write("Wilt u nog eens geld storten?(J/N) ");
                                    antwoord = Console.ReadLine();
                                } while (antwoord.ToUpper() == "J");
                            }
                            break;
                        case 2:
                            {
                                do
                                {
                                    bankrekening.Balans = bankrekening.Balans - Afhalen(bankrekening, verrichtingen);

                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Blue;

                                    Console.WriteLine("De balans bedraagd nu {0} euro.", bankrekening.Balans);

                                    Console.ForegroundColor = ConsoleColor.Blue;

                                    Console.Write("Wilt u nog eens geld afhalen?(J/N) ");
                                    antwoord = Console.ReadLine();
                                } while (antwoord.ToUpper() == "J");
                            }
                            break;
                        case 3:
                            {
                                Balans(bankrekening);
                            }
                            break;
                        case 4:
                            {
                                Limiet(bankrekening);

                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;

                                Console.WriteLine("Het limiet staat nu op {0} euro.", bankrekening.Limiet);

                                Console.ReadLine();
                            }
                            break;
                        case 5:
                            {
                                Verrichtingen(verrichtingen);
                            }
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Dit is geen geldige keuze!");
                    Console.ReadLine();
                }
            } while (keuze != 6);
        }

        private static double Storten(Bankrekening bankrekening, List<string> verrichtingen)
        {
            Console.Clear();

            double storten;

            Console.Write("Hoeveel euro wilt u storten? ");
            storten = Convert.ToDouble(Console.ReadLine());

            bankrekening.Verrichtingen = "+" + storten;
            verrichtingen.Add(bankrekening.Verrichtingen);

            return storten;
        }
        private static double Afhalen(Bankrekening bankrekening, List<string> verrichtingen)
        {
            Console.Clear();

            double afhalen;

            Console.Write("Hoeveel euro wilt u afhalen? ");
            afhalen = Convert.ToDouble(Console.ReadLine());

            if (bankrekening.Balans - afhalen >= bankrekening.Limiet)
            {
                bankrekening.Verrichtingen = "-" + afhalen;
                verrichtingen.Add(bankrekening.Verrichtingen);
                return afhalen;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Transactie gewijgerd!");
                Console.ReadLine();
                return 0;
            }
        }
        private static void Balans(Bankrekening bankrekening)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("De balans bedraagd {0} euro.", bankrekening.Balans);

            Console.ReadLine();
        }
        private static void Limiet(Bankrekening bankrekening)
        {
            Console.Clear();

            double Limiet;

            Console.WriteLine("Het limiet staat momenteel op: {0}.", bankrekening.Limiet);
            Console.Write("Hoeveel moet het nieuwe limiet zijn? ");
            Limiet = Convert.ToDouble(Console.ReadLine());

            Limiet = Limiet - (Limiet * 2);

            if (Limiet < bankrekening.Balans)
            {
                bankrekening.Limiet = Limiet;
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Het limiet is groter dan de balans!");
                Console.ReadLine();
            }
        }
        private static void Verrichtingen(List<string> verrichtingen)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("---------------");
            Console.WriteLine("|Verrichtingen|");
            Console.WriteLine("---------------\n");

            foreach (string verrichting in verrichtingen)
            {
                if (verrichting.Contains("+") == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }

                Console.WriteLine(verrichting);
            }
            Console.ReadLine();
        }
    }
}
