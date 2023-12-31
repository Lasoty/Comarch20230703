﻿/*
 Author: Leszek Lewandowski
 Revision: 0.1
 */

using ComarchCwiczenia.CarSharing;

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
                ShowMenu();

                Console.Write("Podaj pozycję menu: ");

                if (int.TryParse(Console.ReadLine(), out int wybor) == true)
                {
                    int x, y;
                    Calculator calc = new Calculator();

                    switch (wybor)
                    {
                        case 1:
                            GetXY(out x, out y);
                            Console.WriteLine($"Wynik dodawania {x} oraz {y} to {Calculator.Add(x, y)}");
                            break;
                        case 2:
                            GetXY(out x, out y);
                            Console.WriteLine($"Wynik odejmowania {x} oraz {y} to {calc.Subtract(x, y)}");
                            break;
                        case 3:
                            GetXY(out x, out y);
                            Console.WriteLine($"Wynik mnożenia {x} oraz {y} to {calc.Multiply(x, y)}");
                            break;
                        case 4:
                            GetXY(out x, out y);
                            try
                            {
                                Console.WriteLine($"Wynik dzielenia {x} oraz {y} to {calc.Divide(x, y)}");
                            }
                            catch (DivideByZeroException ex)
                            {
                                ShowError("Pamiętaj cholero! Nie dziel przez 0!");
                            }
                            catch (Exception ex)
                            {
                                ShowError("Wystąpił nieprzewidziany wyjątek!");
                            }
                            break;
                        case 5:
                            GetXY(out x, out y);
                            Console.WriteLine($"Wynik reszty z dzielenia {x} oraz {y} to {calc.Modulo(x, y)}");
                            break;
                        case 6:
                            GetXY(out x, out y);
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
                        case 7:
                            bool result = calc.IsToday(DayOfWeek.Friday, DateTime.Now);
                            if (result)
                            {
                                Console.WriteLine("TAK! Dziś jest piątek!");
                            }
                            else
                            {
                                Console.WriteLine("Niestety, dziś jeszcze nie odpoczniesz!");
                            }
                            break;
                        case 8:
                            ZabawaAutem();
                            break;
                        default:
                            ShowError("Nieprawidłowy wybór.");
                            break;
                    }
                }
                else
                {
                    ShowError("Podana wartość nie jest liczbą!");
                }

                Console.Write("Czy chcesz wykonać kolejną operację? [T | n]");
                takNie = Console.ReadKey().Key;
            } while (takNie != ConsoleKey.N);
        }

        private static void ZabawaAutem()
        {
            Car car = new Car();
            Car car2 = car; // = new Car()

            Truck truck = new Truck();

            Vehicle vehicle = new Car();

            //if (car != null)
            //{
            //    Console.Write("Podaj markę auta car1: ");
            //    car?.SetMaker(Console.ReadLine());

            //    Console.Write("Podaj markę auta car2: ");
            //    car2?.SetMaker(Console.ReadLine());
            //}

            //if (car == car2)
            //{
            //    Console.WriteLine("car i car2 to ten sam obiekt");
            //}
            //else
            //{
            //    Console.WriteLine("car i car2 to różne obiekty");
            //}

            Rower rower = new Rower();

            ShareCar(car);
            ShareCar(truck);
            ShareCar(rower);
        }

        private static void ShareCar(IAuto auto)
        {
            auto.SetBorrowState(true);
        }

        private static void ShowError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        private static void GetXY(out int x, out int y)
        {
            Console.Write("Podaj x: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Podaj y: ");
            y = int.Parse(Console.ReadLine());
        }

        private static void ShowMenu()
        {
            Console.WriteLine("KALKULATOR 1.0");

            Console.WriteLine(" 1. Dodawanie");
            Console.WriteLine(" 2. Odejmowanie");
            Console.WriteLine(" 3. Mnożenie");
            Console.WriteLine(" 4. Dzielenie");
            Console.WriteLine(" 5. Modulo");
            Console.WriteLine(" 6. Tablice");
            Console.WriteLine(" 7. Czy dziś jest piątek?");
            Console.WriteLine(" 8. Zabawa autem");
        }
    }
}