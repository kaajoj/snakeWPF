using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeWpfApp
{
    public class SnakeElement
    {
        public int xCordSnakeElement;
        public int yCordSnakeElement;
        public Rectangle element;

        public SnakeElement()
        {
            xCordSnakeElement = 20;
            yCordSnakeElement = 20;
            element = new Rectangle(); 
            element.Width = 20;
            element.Height = 20;
            element.Fill = new SolidColorBrush(Color.FromRgb(58, 228, 81));
        }
        public SnakeElement(int x, int y, Rectangle rect)
        {
            xCordSnakeElement = x;
            yCordSnakeElement = y;
            element = rect;
        }
    }
}
