using System;
using System.Collections.Generic;
using System.Text;
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
            xCordSnakeElement = 0;
            yCordSnakeElement = 0;
            element = new Rectangle();
        }
        public SnakeElement(int x, int y, Rectangle rect)
        {
            xCordSnakeElement = x;
            yCordSnakeElement = y;
            element = rect;
            // elementCord = new Coordinate(xCordSnakeHead, yCordSnakeHead);
        }
    }
}
