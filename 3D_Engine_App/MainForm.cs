using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3D_Engine_App
{
    public partial class MainForm : Form
    {
        public const int X = 0;
        public const int Y = 0;
        public const int Width = 500;
        public const int Height = 500;

        Bitmap Btm;
        Graphics G;
        GraphicEngine GraphicEngine;



        public MainForm()
        {
            InitializeComponent();
            const int verticalBorderSize = 39;
            const int horizontalBorderSize = 16; 
            this.Size = new Size(500 + horizontalBorderSize, 500 + verticalBorderSize);

            Btm = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            G = Graphics.FromImage(Btm);
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.BackgroundImage = Btm;
            this.DoubleBuffered = true;

            MainTimer.Interval = 10;
        }



        private void MainForm_Shown(object sender, EventArgs e)
        {
            GraphicEngine = new GraphicEngine(G);
            MainTimer.Start();
        }



        int tickNumber = 0;
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            tickNumber++;
            var cube = Mesh.GetCube();

            var angle = Math.PI / 100 * tickNumber;
            cube.RotateX(angle / 7);
            cube.RotateY(angle);
            cube.RotateZ(angle / 19);

            GraphicEngine.Render(cube);
            this.Refresh();
        }
    }
}
