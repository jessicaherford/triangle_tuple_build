using System;
using System.Collections.Generic;

namespace TriangleTupleBuild
{

    class Program
    {
        enum Rows { A, B, C };

        static void Main()
        {
            // Create four-item tuple.
            int[] columns = new int[] { 0, 1, 3, 4, 5, 6};
            int x = 0;
            int y = 0;
            string[] rowLetters = Enum.GetNames(typeof(Rows));
            int columnNumber = 1;

            foreach (Rows row in Enum.GetValues(typeof(Rows)))
            {
                int rowNumber = (int)row;
                foreach (int column in columns)
                {
                    if (column == 0)
                    {
                        //columns[column +1] += column;
                        var startingTriangle = new Tuple<string, int[], int[], int[]>(
                            row + columnNumber.ToString(),
                            //row + column.ToString(),
                             new int[] { x, y },
                             new int[] { x, y += 10 },
                             new int[] { x += 10, y });
                        M(startingTriangle);
                        columnNumber++;
                    }
                    else if (column % 2 != 0)
                    {
                        var oddTriangle = new Tuple<string, int[], int[], int[]>(
                            row + columnNumber.ToString(),
                            new int[] { x -= 10, y -= 10 },
                            new int[] { x += 10, y },
                            new int[] { x, y += 10 }
                            );
                        M(oddTriangle);
                        columnNumber++;
                    }
                    else
                    {
                        var evenTriangle = new Tuple<string, int[], int[], int[]>(
                             row + columnNumber.ToString(),
                            new int[] { x, y -= 10 },
                            new int[] { x, y += 10 },
                            new int[] { x += 10, y });
                        // Pass tuple as argument.
                        M(evenTriangle);
                        columnNumber++;
                    }
                }
                x = 0;
                y = 0 + ((rowNumber+=1) * 10);
                columnNumber = 0;
            }
        }

        public static void M(Tuple<string, int[], int[], int[]> tuple)
        {
            List<int> Coords1 = new List<int>();
            List<int> Coords2 = new List<int>();
            List<int> Coords3 = new List<int>();

            foreach (int value in tuple.Item2)
            {
                Coords1.Add(value);
            }

            foreach (int value in tuple.Item3)
            {
                Coords2.Add(value);
            }

            foreach (int value in tuple.Item4)
            {
                Coords3.Add(value);
            }

            //View Tuple
            Console.WriteLine($"Triangle ID: {tuple.Item1} Coordinates: {Coords1[0]} {Coords1[1]}, {Coords2[0]} {Coords2[1]}, {Coords3[0]} {Coords3[1]}  ");

        }

        //Need to search through tuple by ID to return coordinates
        public static void FindTriangleCoordinatesByID(string ID)
        {
            
        }

        //Need to search through tuple by coordinates to find ID
        public static void FindTriangleIDByCoordinates(List<int> Coords1, List<int> Coords2, List<int> Coords3)
        {

        }
    }
}


