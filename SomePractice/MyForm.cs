using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomePractice
{   
    class MyForm : Form
    {


        const int screenWidth = 1500;
        const int screenHeight = 800;
        LevelGenerator generator;
        Map map;
        public MyForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(screenWidth, screenHeight);
            generator = new LevelGenerator();
            map = generator.map;
        }
        public static void Main()
        {
            Application.Run(new MyForm());
        }
        public void DrawMap(Graphics g)
        {
            for (int i = 0; i < map.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < map.Grid.GetLength(1); j++)
                {
                    switch (map.Grid[i,j])
                    {
                        case GridObject.emptySpace:
                            g.FillRectangle(Brushes.Green, i * 10, j * 10, 10, 10);
                            break;
                        case GridObject.floor:
                            g.FillRectangle(Brushes.Red, i * 10, j * 10, 10, 10);
                            break;
                        case GridObject.wall:
                            g.FillRectangle(Brushes.Black, i * 10, j * 10, 10, 10);
                            break;
                        default:
                            break;
                    }
                    
                }
            }

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawMap(e.Graphics);
        }
    }
}
