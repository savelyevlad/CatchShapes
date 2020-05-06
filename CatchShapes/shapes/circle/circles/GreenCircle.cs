using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CatchShapes.shapes.circle.circles
{
    class GreenCircle : Circle
    {
        public GreenCircle(Thickness thickness, MainWindow mainWindow, int speed) : base(thickness, mainWindow)
        {
            this.speed = speed;
            shape.Fill = green;
        }

        public override void MouseDown(object sender, MouseButtonEventArgs e)
        {
            delete();
            mainWindow.changeScore(ScoresForShapes.GreenCircle, this);
        }

        public override void MouseUp(object sender, MouseButtonEventArgs e)
        {
            delete();
            mainWindow.changeScore(ScoresForShapes.GreenCircle, this);
        }
    }
}
