using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Color = System.Windows.Media.Color;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace SnakeWpfApp
{
    public class Food
    {
        private int pointSize;
        public int xFood;
        public int yFood;
        public Rectangle rectanglePoint;
        public Coordinate coordinate { get; set; }

        public Food()
        {
            pointSize = 20;
            rectanglePoint = placeFood();
        }

        public Rectangle placeFood()
        {
            Random rand = new Random();
            xFood = rand.Next(28)*20;
            yFood = rand.Next(19)*20;
            // coordinate = new Coordinate(xPoint, yPoint);

            Rectangle food = new Rectangle();
            food.Width = pointSize;
            food.Height = pointSize;
            food.Fill = new SolidColorBrush(Color.FromRgb(228, 112, 58));

            return food;
        }
    }
}
