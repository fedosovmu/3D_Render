using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _3D_Engine_App
{
    class GraphicEngine
    {
        const int ScreenCenterX = (MainForm.Height - MainForm.X) / 2;
        const int ScreenCenterY = (MainForm.Width - MainForm.Y) / 2;

        Graphics G;
        Color BackgroundColor;
        Color White;
        SolidBrush BackgroundBursh;
        SolidBrush WhiteBrush;
        Pen WhitePen;



        public GraphicEngine(Graphics g)
        {
            G = g;
            BackgroundColor = Color.FromArgb(10, 10, 10);
            White = Color.FromArgb(250, 250, 250);
            BackgroundBursh = new SolidBrush(BackgroundColor);
            WhiteBrush = new SolidBrush(White);
            WhitePen = new Pen(WhiteBrush);
        }



        public void Render(Mesh mesh)
        {
            CleanScreen();
            DrawMesh(mesh);
        }



        private void CleanScreen()
        {
            G.FillRectangle(BackgroundBursh, MainForm.X, MainForm.Y, MainForm.Width, MainForm.Height);
        }




        private Point2D ProjectPoint (Point3D point)
        {
            const int distanceToScreen = 400;
            const int cameraPositionZ = -200;
            double distanceZ = point.Z - cameraPositionZ;

            int x = (int)(point.X * distanceToScreen / distanceZ);
            int y = (int)(point.Y * distanceToScreen / distanceZ);
            x += ScreenCenterX;
            y += ScreenCenterY;
            return new Point2D(x, y);
        }



        private void DrawPoint(Point2D point)
        {
            var x = point.X;
            var y = point.Y;
            const int pointSize = 10;
            G.FillEllipse(WhiteBrush, new Rectangle(x - pointSize / 2, y - pointSize / 2, pointSize, pointSize));
        }



        private void DrawMesh(Mesh mesh)
        {
            mesh = mesh.Copy();

            var projection = new Point2D[mesh.Points.Length];

            for (int i = 0; i < mesh.Points.Length; i++)
            {
                var point3D = mesh.Points[i];
                projection[i] = ProjectPoint(point3D);
            }

            for (int i = 0; i < projection.Length; i++)
            {
                DrawPoint(projection[i]);
            }

            // Connect lines
            var linesCount = mesh.Lines.GetLength(0);
            for (int i = 0; i < linesCount; i++)
            {
                var p1 = projection[mesh.Lines[i, 0]];
                var p2 = projection[mesh.Lines[i, 1]];
                G.DrawLine(WhitePen, p1.X, p1.Y, p2.X, p2.Y);
            }
        }
    }
}
