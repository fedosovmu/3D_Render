using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_Engine_App
{
    class Mesh
    {
        public Point3D[] Points;
        public int[,] Lines;



        public Mesh(Point3D[] points, int[,] lines = null)
        {
            Points = points;
            Lines = lines;
        }



        public Mesh Copy()
        {
            var points = Points = (Point3D[])Points.Clone();
            var lines = (int[,])Lines.Clone();

            return new Mesh(points, lines);
        }



        public void RotateX (double angle)
        {
            for (int i = 0; i < Points.Length; i++)
            {
                var y = Points[i].Y;
                var z = Points[i].Z;
                var newY = y * Math.Cos(angle) - z * Math.Sin(angle);
                var newZ = y * Math.Sin(angle) + z * Math.Cos(angle);
                Points[i].Y = newY;
                Points[i].Z = newZ;
            }
        }



        public void RotateY(double angle)
        {
            for (int i = 0; i < Points.Length; i++)
            {
                var x = Points[i].X;
                var z = Points[i].Z;
                var newX = x * Math.Cos(angle) + z * Math.Sin(angle);
                var newZ = -1 * x * Math.Sin(angle) + z * Math.Cos(angle);
                Points[i].X = newX;
                Points[i].Z = newZ;
            }
        }



        public void RotateZ(double angle)
        {
            for (int i = 0; i < Points.Length; i++)
            {
                var x = Points[i].X;
                var y = Points[i].Y;
                var newX = x * Math.Cos(angle) - y * Math.Sin(angle);
                var newY = x * Math.Sin(angle) + y * Math.Cos(angle);
                Points[i].X = newX;
                Points[i].Y = newY;
            }
        }



        public static Mesh GetCube()
        {
            var points = new Point3D[]
            {
                 new Point3D (0.5, 0.5, -0.5),
                 new Point3D (0.5, -0.5, -0.5),
                 new Point3D (-0.5, -0.5, -0.5),
                 new Point3D (-0.5, 0.5, -0.5),

                 new Point3D (0.5, 0.5, 0.5),
                 new Point3D (0.5, -0.5, 0.5),
                 new Point3D (-0.5, -0.5, 0.5),
                 new Point3D (-0.5, 0.5, 0.5)
            };

            var lines = new int[,]
            {
                {0, 1}, {1, 2}, {2, 3}, {3, 0},
                {4, 5}, {5, 6}, {6, 7}, {7, 4},
                {0, 4}, {1, 5}, {2, 6}, {3, 7},
            };

            const int size = 100;
            for (var i = 0; i < points.Length; i++)
            {
                points[i].X = points[i].X * size;
                points[i].Y = points[i].Y * size;
                points[i].Z = points[i].Z * size;
            }

            return new Mesh(points, lines);
        }
    }
}
