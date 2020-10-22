using System;
using System.Collections.Generic;
using System.Text;

namespace VectorMan
{
    public class Vectors
    {
        private Random rRandom;

        public Vectors(Random rPoint)
        {
            this.rRandom = rPoint;

        }

        public int[][] Get2DimensionalVector()
        {

            int[][] arrayOfPoints = new int[100][];

            for (int i = 0; i < arrayOfPoints.Length; i++)
            {
                arrayOfPoints[i] = new int[] { rRandom.Next(1, 100), rRandom.Next(1, 100) };
            }
            return arrayOfPoints;


        }

        public int[][] Get3DimensionalVector()
        {

            int[][] arrayOfPoints = new int[1000][];

            for (int i = 0; i < arrayOfPoints.Length; i++)
            {
                arrayOfPoints[i] = new int[] { rRandom.Next(1, 1000), rRandom.Next(1, 1000), rRandom.Next(1, 1000) };
            }
            return arrayOfPoints;



        }
    }
}

