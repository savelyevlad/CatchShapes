using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CatchShapes.shapes.circle.circles
{
    class RedCircle : Circle
    {
        public RedCircle(Thickness thickness, MainWindow mainWindow, int speed) : base(thickness, mainWindow)
        {
            shape.Fill = red;
            this.speed = speed;
        }

        public override void MouseDown(object sender, MouseButtonEventArgs e)
        {
            delete();
            mainWindow.changeScore(ScoresForShapes.RedCircle, this);
        }

        public override void MouseUp(object sender, MouseButtonEventArgs e)
        {
            delete();
            mainWindow.changeScore(ScoresForShapes.RedCircle, this);
        }
    }
}
