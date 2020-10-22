using System;

namespace VectorMan
{

    
    class Program
    {
        static Random R = new Random(778);
        struct Point
        {
            public int x;
            public int y;
            public int z;
        }

        

        static Point[] CreatePoints(int providedNum = 100)
        {
            int n = providedNum;
            if (n < 999)
            {
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("That was not an integer.  Now using default value of 100");
                    n = providedNum;
                }
            }
            Point[] points = new Point[n];
            if (n >= 2 && n < 1000)
            {
                for (int i = 0; i < n; i++)
                {

                    points[i] = new Point
                    {
                        x = R.Next(1, 100),
                        y = R.Next(1, 100),
                        z = 0
                    };
                }
            }

            if (n == 1000)
            {
                for (int i = 0; i < n; i++)
                {
                    points[i] = new Point
                    {
                        x = R.Next(1, 1000),
                        y = R.Next(1, 1000),
                        z = R.Next(1, 1000)
                    };
                }
            }



            return points;
        }

        static double GetDistance(Point A, Point B)
        {
            int width = Math.Abs(A.x) - Math.Abs(B.x);
            int height = Math.Abs(A.y) - Math.Abs(B.y);
            int depth = Math.Abs(A.z) - Math.Abs(B.z);

            if (A.z == 0)
            {
                return Math.Sqrt(width * width + height * height);
            }
            else if (A.z != 0)
            {
                return Math.Sqrt(width * width + height * height + depth * depth);
            }
            else
            {
                return Math.Sqrt(width * width + height * height);
            }

        }

        static double FindClosest(Point[] points)
        {

            double distance = 0;

            double smallestDistance = 0;

            double previousDistance = 45;

            // First Point
            int x1 = 0, y1 = 0, z1 = 0;
            // Second Point 
            int x2 = 0, y2 = 0, z2 = 0;
            // Closest Element in array
            int firstPoint = 0, secondPoint = 0;

            for (int c = 0; c < points.Length; c++)
            {

                for (int b = 0; b < points.Length; b++)
                {
                    if (c != b)
                    {

                        distance = GetDistance(points[c], points[b]);

                    }


                    if (distance < previousDistance && distance != 0)
                    {
                        smallestDistance = distance;
                        previousDistance = distance;

                        // Capturing X and Y values for Console.Write



                        // First Point 
                        x1 = points[c].x;
                        y1 = points[c].y;
                        z1 = points[c].z;
                        // Second Point
                        x2 = points[b].x;
                        y2 = points[b].y;
                        z2 = points[b].z;

                        // Closest Element in array
                        firstPoint = c;
                        secondPoint = b;
                    }


                }
            }
            Console.WriteLine($"The closest points are \nArray Element: |{firstPoint}| X:{x1}, Y:{y1}, Z:{z1} \n\nAND \n\nArray Element: |{secondPoint}| X:{x2}, Y:{y2}, Z:{z2}");

            return smallestDistance;
        }


        private static double GetDis2Point()
        {
            Point[] arrayOfPoints = CreatePoints(2);

            return GetDistance(arrayOfPoints[0], arrayOfPoints[1]);
        }

        private static void PrintPoints(Point[] providedPoints)
        {
            Point[] pointsToPrint = providedPoints;
            Console.WriteLine($"You have successfully created a container with {pointsToPrint.Length} random two-dimensional points.");
            for (int i=0; i < pointsToPrint.Length; i++)
            {
                Console.WriteLine($"Array Element: |{i}| X: {pointsToPrint[i].x}, Y: {pointsToPrint[i].y}, Z: {pointsToPrint[i].z}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------First Part-------------------------------------------");
            //CreatePoints(120);
            Console.WriteLine($"How many elements would you like inside your new container? \nPlease note, the default is 100, so if you do not enter a valid number the container will contain 100 elements.  \nPlease enter a valid positive number: ");           
            Point[] newPointsContainer = CreatePoints();
            PrintPoints(newPointsContainer);
            Console.WriteLine("\n\n");
            Console.WriteLine("-----------------------Second Part------------------------------------------");
            Console.WriteLine($"The closest Euclidean distance between ({newPointsContainer.Length}) random Two-Dimensional Points: |{FindClosest(newPointsContainer)}|");
            Console.WriteLine("\n\n");
            Console.WriteLine("-----------------------Third And Fourth Part--------------------------------");
            Console.WriteLine("Now we will find the closest distance between (1000) random Three-Dimensional Points.");
            Console.WriteLine($"With a Distance of: |{FindClosest(CreatePoints(1000))}|");
            Console.WriteLine("----------------------------------------------------------------------------");
        }


    }
}
