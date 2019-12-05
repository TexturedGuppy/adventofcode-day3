using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeDay3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiating a "Program" Object so I can call my functions at the bottom
            Program P = new Program();
            int manhattanDistanceFromOrigin = 0;

            //Lists that will contain the input coords in the form of strings
            List<string> wire1Raw = new List<string>();
            List<string> wire2Raw = new List<string>();

            List<Tuple<int, int>> wire1Coords = new List<Tuple<int,int>>();
            List<Tuple<int, int>> wire2Coords = new List<Tuple<int,int>>();
            //var wireCoords = new List<Tuple<int,int>>();



            //file the wire inputs come from
            string file = "input.txt";

            //Variable used as a way to read in each line of the file and then put each line in a separate list
            int counter = 0;


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

            //Just some personal testing of how tuples work
            //wireCoords.Add(new Tuple<int, int>(5, 2));
            //wireCoords.Add(new Tuple<int, int>(4, 1));
            //wireCoords.Add(new Tuple<int, int>(3, 0));
            //foreach (Tuple<int,int> i in wireCoords)
            //{
            //    Console.WriteLine(i);
            //}

            int currentXCoord = 0, currentYCoord = 0;
            foreach (string s in wire1Raw)
            {
                string stringToConvert = s.Substring(1, s.Length - 1);
                int direction = Convert.ToInt32(stringToConvert);
                if (s[0] == 'R')
                {
                    for (int i = currentXCoord; i <= direction; i++)
                    {
                        wire1Coords.Add(new Tuple<int, int>(i, currentYCoord));

                    }
                    currentXCoord += direction;
                }
                if (s[0] == 'L')
                {
                    for (int i = currentXCoord; i >= direction * -1; i--)
                    {
                        wire1Coords.Add(new Tuple<int, int>(i, currentYCoord));

                    }
                    currentXCoord -= direction;
                }
                if (s[0] == 'U')
                {
                    for (int i = currentXCoord; i <= direction; i++)
                    {
                        wire1Coords.Add(new Tuple<int, int>(currentXCoord, i));

                    }
                    currentYCoord += direction;
                }
                if (s[0] == 'D')
                {
                    for (int i = currentXCoord; i >= direction * -1; i--)
                    {
                        wire1Coords.Add(new Tuple<int, int>(currentXCoord, i));

                    }
                    currentYCoord -= direction;
                }
            }
            currentXCoord = 0;
            currentYCoord = 0;
            foreach (string s in wire2Raw)
            {
                string stringToConvert = s.Substring(1, s.Length - 1);
                int direction = Convert.ToInt32(stringToConvert);
                if (s[0] == 'R')
                {
                    for (int i = currentXCoord; i <= direction; i++)
                    {
                        wire2Coords.Add(new Tuple<int, int>(i, currentYCoord));

                    }
                    currentXCoord += direction;
                }
                if (s[0] == 'L')
                {
                    for (int i = currentXCoord; i >= direction*-1; i--)
                    {
                        wire2Coords.Add(new Tuple<int, int>(i, currentYCoord));

                    }
                    currentXCoord -= direction;
                }
                if (s[0] == 'U')
                {
                    for (int i = currentXCoord; i <= direction; i++)
                    {
                        wire2Coords.Add(new Tuple<int, int>(currentXCoord, i));

                    }
                    currentYCoord += direction;
                }
                if (s[0] == 'D')
                {
                    for (int i = currentXCoord; i >= direction * -1; i--)
                    {
                        wire2Coords.Add(new Tuple<int, int>(currentXCoord, i));

                    }
                    currentYCoord -= direction;
                }
            }

            IEnumerable<Tuple<int,int>> duplicates = wire1Coords.Intersect(wire2Coords);
            //var tupleConversion = (Tuple<int,int>)duplicates;
            //var tupleConversion = duplicates.ToList();
            int manhattanCounter = 0;

                int tempManhattan = 0;
            foreach (var i in duplicates)
            {
                int x = i.Item1;
                int y = i.Item2;

                tempManhattan = P.ManhattanDistanceFromOrigin(x, y);
                Console.WriteLine("before continue");
                Console.WriteLine("ManhattanCounter Variable: " + manhattanCounter);
                manhattanCounter++;
                if (manhattanCounter == 1)
                {
                    continue;
                }

                if (manhattanCounter == 2)
                {
                    manhattanDistanceFromOrigin = tempManhattan;
                }

                else if (tempManhattan < manhattanDistanceFromOrigin)
                {
                    manhattanDistanceFromOrigin = tempManhattan;
                }
               
                Console.WriteLine("2nd ManhattanCounter Variable: " + manhattanCounter);
                Console.WriteLine(i);
            }

            Console.WriteLine("Shortest Manhattan distance is: " + manhattanDistanceFromOrigin);
            foreach (var i in duplicates)
            {
                Console.WriteLine(i);
            }

            //foreach (Tuple<int, int> i in wire1Coords)
            //{
            //    Console.WriteLine(i);
            //}
            //foreach (var i in wire1Coords)
            //{
            //    Console.WriteLine(i);

            //}
            //foreach (var i in wire2Coords)
            //{
            //    Console.WriteLine(i);

            //}
            //reset coords
            currentXCoord = 0; 
            currentYCoord = 0;

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
