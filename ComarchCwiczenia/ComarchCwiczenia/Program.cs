/*
 Author: Leszek Lewandowski
 Revision: 0.1
 */
using System;
using System.ComponentModel;

namespace ComarchCwiczenia
{
    /// <summary>
    /// Główna klasa aplikacji
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey takNie;
            do
            {
                Console.Clear();

                Console.WriteLine("KALKULATOR 1.0");

                Console.WriteLine(" 1. Dodawanie");
                Console.WriteLine(" 2. Odejmowanie");
                Console.WriteLine(" 3. Mnożenie");
                Console.WriteLine(" 4. Dzielenie");
                Console.WriteLine(" 5. Modulo");
                Console.WriteLine(" 6. Tablice");

                Console.Write("Podaj pozycję menu: ");

                if (int.TryParse(Console.ReadLine(), out int wybor) == true)
                {
                    Console.Write("Podaj x: ");
                    int x = int.Parse(Console.ReadLine());
                    Console.Write("Podaj y: ");
                    int y = int.Parse(Console.ReadLine());

                    switch (wybor)
                    {
                        case 1:
                            Console.WriteLine($"Wynik dodawania {x} oraz {y} to {x + y}");
                            break;
                        case 2:
                            Console.WriteLine($"Wynik odejmowania {x} oraz {y} to {x - y}");
                            break;
                        case 3:
                            Console.WriteLine($"Wynik mnożenia {x} oraz {y} to {x * y}");
                            break;
                        case 4:
                            Console.WriteLine($"Wynik dzielenia {x} oraz {y} to {x / y}");
                            break;
                        case 5:
                            Console.WriteLine($"Wynik reszty z dzielenia {x} oraz {y} to {x % y}");
                            break;
                        case 6:
                            int[,] tab = new int[x, y];
                            for (int yi = 0; yi < y; yi++)
                            {
                                for (int xi = 0; xi < x; xi++)
                                {
                                    int w = new Random().Next(0, 255);
                                    tab[xi, yi] = w;

                                    Console.Write($"{w}\t");
                                }
                                Console.WriteLine();
                            }

                            break;
                        default:
                            Console.WriteLine("Nieprawidłowy wybór.");
                            break;
                    }
                }

                Console.Write("Czy chcesz wykonać kolejną operację? [T | n]");
                takNie = Console.ReadKey().Key;
            } while (takNie != ConsoleKey.N);
        }
    }
}