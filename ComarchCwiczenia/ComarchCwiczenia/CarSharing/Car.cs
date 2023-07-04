using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarchCwiczenia.CarSharing
{
    public interface IAuto
    {
        void SetBorrowState(bool isBorrowed);
    }

    public class Rower : IAuto
    {
        public void SetBorrowState(bool isBorrowed)
        {
        }
    }

    public abstract class Vehicle : IAuto
    {
        public string Color { get; set; }

        public void SayHello()
        {
            Console.WriteLine("Hello world!");
        }

        public abstract void SetBorrowState(bool isBorrowed);

        public abstract void SetColor(string color);
    }

    internal class Car : Vehicle //nie można dziedziczyć po sealed
    {
        private int acctualGasState;
        private bool isBorrowed;

        public int DoorCount;
        public int SitCount;


        private string model;
        public string Model
        {
            get 
            {
                Debug.WriteLine("Odczytano Model: " + model);
                return model; 
            }
            set 
            {
                Debug.WriteLine("Zapisanie Model: " + value);
                model = value; 
            }
        }

        public string Maker { get; private set; }

        public Car() {}

        public Car(string maker, string model)
        {
            Maker = maker;
            Model = model;
        }



        public override void SetBorrowState(bool isBorrowed)
        {
            this.isBorrowed = isBorrowed;
        }

        internal void SetMaker(string? maker)
        {
            Maker = maker;
        }

        public override void SetColor(string color)
        {
            Color = color;
            Console.WriteLine("Ustawiono kolor w klasie Car.");
        }
    }

    class Truck : Car
    {
        public int Capacity { get; set; }

        public override void SetBorrowState(bool isBorrowed) //uważać na operator new
        {
            base.SetBorrowState(isBorrowed);
            Console.WriteLine("Wypożyczono ciężarówkę.");
        }
    }

}
