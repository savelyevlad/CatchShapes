using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CatchShapes.shapes.square.squares
{
    class GreenSquare : Square
    {
        public GreenSquare(Thickness thickness, MainWindow mainWindow, int speed) : base(thickness, mainWindow)
        {
            shape.Fill = green;
            this.speed = speed;
        }

        public override void MouseDown(object sender, MouseButtonEventArgs e)
        {
            delete();
            mainWindow.changeScore(ScoresForShapes.GreenSquare, this);
        }

        public override void MouseUp(object sender, MouseButtonEventArgs e)
        {
            delete();
            mainWindow.changeScore(ScoresForShapes.GreenSquare, this);
        }
    }
}
