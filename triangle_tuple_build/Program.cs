using System;
using triangle_tuple_build;

namespace TriangleTupleBuild
{
   
    class Program
    {

        public static void Main(string[] args)
        {
            AllTriangles grid = new AllTriangles();

            Console.Write("Enter a Key (A-F) + (1-12) such as A1 or B4 ");
            AllTriangles.userKey = Convert.ToString(Console.ReadLine());
            AllTriangles.userCoords = new int[6];

            for (int i = 0; i < 6; i++)
            {
                Console.Write("Enter coordinates values one at a time and hit enter each time ");
                AllTriangles.userCoords[i]= Convert.ToInt32(Console.ReadLine());
            } 
           
            grid.AllTrianglesGet();

        }
    }

}





