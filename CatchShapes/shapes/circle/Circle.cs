using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CatchShapes.shapes.circle
{
    abstract class Circle : MyShape
    {
        public Circle(Thickness thickness, MainWindow mainWindow) : base(mainWindow)
        {
            shape = new Ellipse
            {
                Height = 35,
                Width = 35,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = thickness
            };
            mainWindow.MainGrid.Children.Add(shape);

            shape.MouseDown += MouseDown;
            shape.MouseUp += MouseUp;
        }
    }
}
