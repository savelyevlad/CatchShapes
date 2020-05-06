using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CatchShapes.shapes.square.squares
{
    class RedSquare : Square
    {
        public RedSquare(Thickness thickness, MainWindow mainWindow, int speed) : base(thickness, mainWindow)
        {
            this.speed = speed;
            shape.Fill = red;
        }

        public override void MouseDown(object sender, MouseButtonEventArgs e)
        {
            delete();
            mainWindow.changeScore(ScoresForShapes.RedSquare, this);
        }

        public override void MouseUp(object sender, MouseButtonEventArgs e)
        {
            delete();
            mainWindow.changeScore(ScoresForShapes.RedSquare, this);
        }
    }
}
