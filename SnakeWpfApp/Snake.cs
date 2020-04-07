using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeWpfApp
{
    public class Snake
    {
        public int snakeLength;
        public readonly int headSize;
        public int xSnakeHead;
        public int ySnakeHead;
        public Rectangle head;
        public Direction direction;
        public List<Rectangle> snakeElements = new List<Rectangle>();

        public enum Direction { Left, Right, Up, Down }

        public Snake()
        {
            direction = Direction.Right;
            headSize = 20;
            snakeLength = 3;
            xSnakeHead = 260;
            ySnakeHead = 180;
            head = placeHead();
            drawSnake();
        }

        public Rectangle placeHead()
        {
            Rectangle rect = new Rectangle();
            rect.Width = headSize;
            rect.Height = headSize;
            rect.Fill = new SolidColorBrush(Color.FromRgb(228, 112, 58));
            snakeElements.Add(rect);
            return rect;
        }

        public void drawSnake()
        {
            for (int i = 1; i < snakeLength; i++)
            {
                Rectangle element = new Rectangle();
                element.Width = headSize;
                element.Height = headSize;
                element.Fill = new SolidColorBrush(Color.FromRgb(58, 228, 81));
                snakeElements.Add(element);
            }
        }

        public void eat()
        {
            snakeLength++;
        }
        public void move()
        {

        }

        public void turn()
        {

        }
    }
}
