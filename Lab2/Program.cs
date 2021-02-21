using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordinate coordinate1 = new Coordinate(1, 2);
            Coordinate coordinate2 = new Coordinate(3, 4);
            Coordinate coordinate3 = new Coordinate(1, 2);
            
            Console.WriteLine($"{coordinate1} + {coordinate2} = {coordinate1 + coordinate2}");
            Console.WriteLine($"{coordinate1} - {coordinate2} = {coordinate1 - coordinate2}");
            Console.WriteLine($"{coordinate1} == {coordinate3}? => {coordinate1 == coordinate3}");
            Console.WriteLine($"{coordinate1} == {coordinate2}? => {coordinate1 == coordinate2}");

        }
    }
}