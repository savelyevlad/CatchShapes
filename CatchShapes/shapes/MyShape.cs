using System;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CatchShapes.shapes
{
    public abstract class MyShape : Movable
    {
        protected Shape shape;
        protected double speed;
        protected int bottom;

        protected MainWindow mainWindow;

        protected static SolidColorBrush green = new SolidColorBrush
        {
            Color = Colors.Green
        };

        protected static SolidColorBrush red = new SolidColorBrush
        {
            Color = Colors.Red
        };

        public MyShape(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            bottom = (int) mainWindow.Height - 35;
        }

        public void move()
        {
            shape.Margin = new System.Windows.Thickness(shape.Margin.Left,
                                                        shape.Margin.Top + speed,
                                                        shape.Margin.Right,
                                                        shape.Margin.Bottom);
            if (shape.Margin.Top >= bottom)
            {
                delete();
                // mainWindow.changeScore(-1);
            }
        }

        public void delete()
        {
            mainWindow.deleteFromSet(this);
            mainWindow.MainGrid.Children.Remove(shape);
        }

        public abstract void MouseDown(object sender, MouseButtonEventArgs e);
        public abstract void MouseUp(object sender, MouseButtonEventArgs e);
    }
}
