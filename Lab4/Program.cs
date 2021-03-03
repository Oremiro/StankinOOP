using System;
using Lab2;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new ArrayList<Coordinate>()
            {
                new Coordinate(1, 1),
                new Coordinate(1, 2),
                new Coordinate(1, 3),
            };
            var list2 = new ArrayList<Coordinate>()
            {
                new Coordinate(1, 1),
            };
            var list3 = new ArrayList<Coordinate>()
            {
                new Coordinate(4, 5),
            };
            var list4 = new ArrayList<Coordinate>()
            {
                new Coordinate(1, 1),
                new Coordinate(1, 2),

            };
            
            var list5 = new ArrayList<Coordinate>()
            {
                new Coordinate(1, 1),
                new Coordinate(1, 2),
                new Coordinate(4, 5),

            };
            Console.WriteLine(list1.ContainsList(list2));
            Console.WriteLine(list1.ContainsList(list3));
            Console.WriteLine(list1.ContainsList(list4));
            Console.WriteLine(list1.ContainsList(list5));

        }
    }
}