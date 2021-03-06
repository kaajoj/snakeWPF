﻿using System;
using System.Windows.Media;
using Color = System.Windows.Media.Color;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace SnakeWpfApp
{
    public class Food
    {
        private readonly int _foodSize;
        public Rectangle rectanglePoint;
        public int xFood;
        public int yFood;

        public Food()
        {
            _foodSize = 20;
            rectanglePoint = placeFood();
        }

        public Rectangle placeFood()
        {
            Random rand = new Random();
            xFood = rand.Next(28)*20;
            yFood = rand.Next(19)*20;

            Rectangle food = new Rectangle();
            food.Width = _foodSize;
            food.Height = _foodSize;
            food.Fill = new SolidColorBrush(Color.FromRgb(228, 112, 58));
            return food;
        }
    }
}
