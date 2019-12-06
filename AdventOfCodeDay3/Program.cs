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

            int wire1StepCounter = 0;
            int wire2StepCounter = 0;

            //Lists that will contain the input coords in the form of strings
            List<string> wire1Raw = new List<string>();
            List<string> wire2Raw = new List<string>();

            List<Tuple<int, int>> wire1Coords = new List<Tuple<int,int>>();
            List<Tuple<int, int>> wire2Coords = new List<Tuple<int,int>>();
            List<Tuple<int, int, int>> wire1CoordsWithSteps = new List<Tuple<int, int, int>>();
            List<Tuple<int, int, int>> wire2CoordsWithSteps = new List<Tuple<int, int, int>>();
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

            int currentXCoord = 0; 
            int currentYCoord = 0;
            foreach (string s in wire1Raw)
            {
                string stringToConvert = s.Substring(1, s.Length - 1);
                int direction = Convert.ToInt32(stringToConvert);

                if (s[0] == 'R')
                {
                    for (int i = currentXCoord; i <= currentXCoord + direction; i++)
                    {
                        wire1Coords.Add(new Tuple<int, int>(i, currentYCoord));
                        wire1CoordsWithSteps.Add(new Tuple<int, int, int>(i, currentYCoord, wire1StepCounter));
                        wire1StepCounter++;
                    }
                    currentXCoord += direction;
                }

                if (s[0] == 'L')
                {
                    for (int i = currentXCoord; i >= (currentXCoord - direction); i--)
                    {
                        wire1Coords.Add(new Tuple<int, int>(i, currentYCoord));
                        wire1CoordsWithSteps.Add(new Tuple<int, int, int>(i, currentYCoord, wire1StepCounter));
                        wire1StepCounter++;
                    }
                    currentXCoord -= direction;
                }

                if (s[0] == 'U')
                {
                    for (int i = currentYCoord; i <= currentYCoord + direction; i++)
                    {
                        wire1Coords.Add(new Tuple<int, int>(currentXCoord, i));
                        wire1CoordsWithSteps.Add(new Tuple<int, int, int>(currentXCoord, i, wire1StepCounter));
                        wire1StepCounter++;
                    }
                    currentYCoord += direction;
                }

                if (s[0] == 'D')
                {
                    for (int i = currentYCoord; i >= (currentYCoord - direction); i--)
                    {
                        wire1Coords.Add(new Tuple<int, int>(currentXCoord, i));
                        wire1CoordsWithSteps.Add(new Tuple<int, int, int>(currentXCoord, i, wire1StepCounter));
                        wire1StepCounter++;
                    }
                    currentYCoord -= direction;

                }
            }
            //reset coordinates to 0 for wire 2
            currentXCoord = 0;
            currentYCoord = 0;
            foreach (string s in wire2Raw)
            {
                string stringToConvert = s.Substring(1, s.Length - 1);
                int direction = Convert.ToInt32(stringToConvert);
                if (s[0] == 'R')
                {
                    for (int i = currentXCoord; i <= currentXCoord + direction; i++)
                    {
                        wire2Coords.Add(new Tuple<int, int>(i, currentYCoord));
                        wire2CoordsWithSteps.Add(new Tuple<int, int, int>(i, currentYCoord, wire2StepCounter));
                        wire2StepCounter++;
                    }
                    currentXCoord += direction;
                }
                if (s[0] == 'L')
                {
                    for (int i = currentXCoord; i >= (currentXCoord - direction); i--)
                    {
                        wire2Coords.Add(new Tuple<int, int>(i, currentYCoord));
                        wire2CoordsWithSteps.Add(new Tuple<int, int, int>(i, currentYCoord, wire2StepCounter));
                        wire2StepCounter++;
                    }
                    currentXCoord -= direction;
                }
                if (s[0] == 'U')
                {
                    for (int i = currentYCoord; i <= currentYCoord + direction; i++)
                    {
                        wire2Coords.Add(new Tuple<int, int>(currentXCoord, i));
                        wire2CoordsWithSteps.Add(new Tuple<int, int, int>(currentXCoord, i, wire2StepCounter));
                        wire2StepCounter++;
                    }
                    currentYCoord += direction;
                }
                if (s[0] == 'D')
                {
                    for (int i = currentYCoord; i >= (currentYCoord - direction); i--)
                    {
                        wire2Coords.Add(new Tuple<int, int>(currentXCoord, i));
                        wire2CoordsWithSteps.Add(new Tuple<int, int, int>(currentXCoord, i, wire2StepCounter));
                        wire2StepCounter++;
                    }
                    currentYCoord -= direction;
                }
            }

            IEnumerable<Tuple<int,int>> duplicates = wire1Coords.Intersect(wire2Coords);
            //var tupleConversion = (Tuple<int,int>)duplicates;
            //var tupleConversion = duplicates.ToList();
            int manhattanCounter = 0;
            Tuple<int, int> coordsForShortest = new Tuple<int, int>(0,0);
            int tempManhattan = 0;

            foreach (var i in duplicates)
            {
                int x = i.Item1;
                int y = i.Item2;
                coordsForShortest = new Tuple<int, int>(x,y);
                tempManhattan = P.ManhattanDistanceFromOrigin(x, y);
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
                    coordsForShortest = i;

                }
            }

            Console.WriteLine("Shortest Manhattan distance is: " + coordsForShortest);
            Console.WriteLine("Shortest Manhattan distance is: " + manhattanDistanceFromOrigin);


            //Beginning of Solution for Part 2
            //Real solution for Part two was added above with the Triple Tuple and adding in a Step Counter on the third section
            int stepsAtIntersection = 0;
            int tempStepsAtIntersection = 0;
            foreach (var i in duplicates)
            {
                var wire1Intersection = wire1CoordsWithSteps.Where(t => t.Item1.Equals(i.Item1) && t.Item2.Equals(i.Item2)).ToList();  
                var wire2Intersection = wire2CoordsWithSteps.Where(t => t.Item1.Equals(i.Item1) && t.Item2.Equals(i.Item2)).ToList();
                tempStepsAtIntersection = wire1Intersection[0].Item3 + wire2Intersection[0].Item3;
                if (tempStepsAtIntersection == 2)
                {
                    continue;
                }
                if (stepsAtIntersection == 0)
                {
                    stepsAtIntersection = tempStepsAtIntersection;
                }
                else if (tempStepsAtIntersection < stepsAtIntersection)
                {
                    stepsAtIntersection = tempStepsAtIntersection;
                }
                Console.WriteLine("TempStepsNumber at end of each loop iter: " + tempStepsAtIntersection);

            }
            Console.WriteLine("Shortest steps to intersection: " + stepsAtIntersection);
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

            distance = Math.Abs(0 - xCoord) + Math.Abs(0 - yCoord);

            return distance;
        }
    }
}
