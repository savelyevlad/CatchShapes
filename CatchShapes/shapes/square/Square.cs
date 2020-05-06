using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace CatchShapes.shapes.square
{
    abstract class Square : MyShape
    {
        public Square(Thickness thickness, MainWindow mainWindow) : base(mainWindow)
        {
            shape = new Rectangle
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
