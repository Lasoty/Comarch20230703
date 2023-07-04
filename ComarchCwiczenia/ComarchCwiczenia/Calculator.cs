using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarchCwiczenia
{
    internal class Calculator
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public int Subtract(int x, int y)
        {
            return x - y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public float Divide(int x, int y)
        {
            if (y == 0)
                throw new DivideByZeroException("Próba dzielenia przez 0");
            return (float)x / y;
        }

        public int Modulo(int x, int y)
        {
            return x % y;
        }
    }
}
