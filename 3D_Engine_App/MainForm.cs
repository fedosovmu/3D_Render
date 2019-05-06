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
        }



        private void MainForm_Shown(object sender, EventArgs e)
        {
            var graphicEngine = new GraphicEngine(G);

            var cube = Mesh.GetCube();
            graphicEngine.Render(cube);


            this.Refresh();
        }
    }
}
