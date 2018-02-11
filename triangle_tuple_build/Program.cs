using System;
using System.Collections.Generic;
using System.Linq;

namespace TriangleTupleBuild
{
   
    class Program
    {

        public static void Main(string[] args)
        {
            Console.Write("Enter a Key such as B4 ");
            AllTriangles.userKey = Convert.ToString(Console.ReadLine());
            AllTriangles.userCoords = new int[6];

            for (int i = 0; i < 6; i++)
            {
                Console.Write("Enter coordinates values ");
                AllTriangles.userCoords[i]= Convert.ToInt32(Console.ReadLine());
            } 
           
            AllTriangles grid = new AllTriangles();
            grid.AllTrianglesGet();

        }
    }


    public class AllTriangles
    {
        enum Rows { A, B, C, D, E, F };
        public static string userKey { get; set; } 
        public static int[] userCoords { get; set; }

        public object AllTrianglesGet()
        {

            int[] columns = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int x = 0;
            int y = 0;
            string[] rowLetters = Enum.GetNames(typeof(Rows));
            int columnNumber = 1;


            // Create four-item tuple.
            foreach (Rows row in Enum.GetValues(typeof(Rows)))
            {
                int rowNumber = (int)row;
                foreach (int column in columns)
                {
                    if (column == 0)
                    {
                        var startingTriangle = new Tuple<string, int[], int[], int[]>(
                            row + columnNumber.ToString(),
                             new int[] { x, y },
                             new int[] { x, y += 10 },
                             new int[] { x += 10, y }
                            );
                        M(startingTriangle);
                        columnNumber++;
                    }
                    else if (column % 2 != 0)
                    {
                        var oddTriangleColumn = new Tuple<string, int[], int[], int[]>(
                            row + columnNumber.ToString(),
                            new int[] { x -= 10, y -= 10 },
                            new int[] { x += 10, y },
                            new int[] { x, y += 10 }
                            );
                        M(oddTriangleColumn);
                        columnNumber++;
                    }
                    else if (column % 2 == 0)
                    {
                        var evenTriangleColumn = new Tuple<string, int[], int[], int[]>(
                             row + columnNumber.ToString(),
                            new int[] { x, y -= 10 },
                            new int[] { x, y += 10 },
                            new int[] { x += 10, y }
                        );
                        // Pass tuple as argument.
                        M(evenTriangleColumn);
                        columnNumber++;
                    }
                }
                x = 0;
                y = 0 + ((rowNumber += 1) * 10);
                columnNumber = 1;
            }
            return x;
        }

        private static object M(Tuple<string, int[], int[], int[]> tuple)
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


            //Added tuple items to Dictionary
            Dictionary<string, List<int>> TriangleDict = new Dictionary<string, List<int>>();

            TriangleDict.Add(tuple.Item1, new List<int> {
                  (int)Coords1[0],
                  (int)Coords1[1],
                  (int)Coords2[0],
                  (int)Coords2[1],
                  (int)Coords3[0],
                  (int)Coords3[1]
            });


            foreach (KeyValuePair<string, List<int>> pair in TriangleDict)
            {
                // set findByKey and findByCoords to boolean value 

                if (TriangleDict.ContainsKey(userKey) == true)
                    Console.WriteLine($"Triangle ID: {tuple.Item1} Coordinates: {Coords1[0]} {Coords1[1]}, {Coords2[0]} {Coords2[1]}, {Coords3[0]} {Coords3[1]}  ");

                if (tuple.Item2[0].Equals(userCoords[0]) && tuple.Item2[1].Equals(userCoords[1]) && tuple.Item3[0].Equals(userCoords[2]) && tuple.Item3[1].Equals(userCoords[3]) && tuple.Item4[0].Equals(userCoords[4]) && tuple.Item4[1].Equals(userCoords[5]))
                {
                    Console.WriteLine($"Triangle ID: {tuple.Item1} Coordinates: {Coords1[0]} {Coords1[1]}, {Coords2[0]} {Coords2[1]}, {Coords3[0]} {Coords3[1]}  ");

                }
            }
            return TriangleDict;


        }
    }
}





