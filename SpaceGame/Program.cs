using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Vector
    {
        public double X, Y;
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(object obj)
        {
            Vector v = obj as Vector;
            if (v == null) return false; // Или можно создать исключение throw new InvalidCastException()
        return (obj as Vector).X == X && (obj as Vector).Y == Y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(1, 1);
            Vector v2 = new Vector(1, 1);
            Console.WriteLine(v1.Equals(v2));
        }
    }
}