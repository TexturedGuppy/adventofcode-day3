using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCodeDay3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiating a "Program" Object so I can call my functions at the bottom
            Program P = new Program();

            double distanceFromOrigin;
            double distanceBetweenTwoPoints;

            int x1, x2, y1, y2;

            //Lists that will contain the input coords in the form of strings
            List<string> wire1Raw = new List<string>();
            List<string> wire2Raw = new List<string>();

            List<Tuple<int, int>> wireCoords = new List<Tuple<int,int>>();
            //var wireCoords = new List<Tuple<int,int>>();



            //file the wire inputs come from
            string file = "input.txt";

            int counter = 0;
            //using (var reader = new StreamReader(file))
            //{
                   
            //    var line = reader.ReadLine();
            //    var values = line.Split(',');
            //    if (counter == 0)
            //    {
            //        for (int i = 0; i < values.Length; i++)
            //        {
            //            wire1.Add(values[i]);
            //        }
            //    }
            //    if (counter == 1)
            //    {
            //        for (int i = 0; i < values.Length; i++)
            //        {
            //            wire2.Add(values[i]);
            //        }
            //    }
            //    Console.WriteLine(counter);
            //    counter++;
            //}

            //Reads in the two lines to separate lists for parsing later
            foreach (string line in File.ReadLines(file))
            {
                string[] values = line.Split(',');
                if (counter == 0)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        wire1Raw.Add(values[i]);
                    }
                }
                if (counter == 1)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        wire2Raw.Add(values[i]);
                    }
                }
                counter++;
            }

            //foreach (string coords in wire1)
            //{
            //    Console.WriteLine("Wire 1: " + coords);
            //}

            //foreach (string coordss in wire2)
            //{
            //    Console.WriteLine("Wire 2: " + coordss);
            //}
            ////Console.WriteLine(P.ManhattanDistanceFromOrigin(500, 500));
            wireCoords.Add(new Tuple<int, int>(5, 2));
            wireCoords.Add(new Tuple<int, int>(4, 1));
            wireCoords.Add(new Tuple<int, int>(3, 0));

            foreach (Tuple<int,int> i in wireCoords)
            {
                Console.WriteLine(i);
            }


        }

        //Assuming Origin of (0,0)
        //Gets distance between origin and another point in "As the bird flies distance"
        public double DistanceFromOrigin(int xCoord, int yCoord)
        {
            double distance;

            distance = Math.Sqrt(Math.Pow(xCoord, 2) + Math.Pow(yCoord,2));

            return distance;
        }

        //Assuming Origin of (0,0)
        //Gets distance between origin and another point in Manhattan distance
        public int ManhattanDistanceFromOrigin(int xCoord, int yCoord)
        {
            int distance;

            distance = Math.Abs((0 - xCoord) + (0 - yCoord));

            return distance;
        }
    }
}
