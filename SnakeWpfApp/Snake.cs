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
        public int xCordSnakeHead;
        public int yCordSnakeHead;
        // public int xElementCord;
        // public int yElementCord;
        public Coordinate elementCord { get; set; }
        // public Rectangle head;
        public Direction direction;
        public List<SnakeElement> snakeElements = new List<SnakeElement>();

        public enum Direction { Left, Right, Up, Down }

        public Snake()
        {
            direction = Direction.Right;
            headSize = 20;
            snakeLength = 3;
            xCordSnakeHead = 160;
            yCordSnakeHead = 180;
            elementCord = new Coordinate(xCordSnakeHead, yCordSnakeHead);
 
            drawSnake();
        }

        public void drawSnake()
        {
            for (int i = 0; i < snakeLength; i++)
            {
                Rectangle element = new Rectangle();
                element.Width = headSize;
                element.Height = headSize;
                if (i == 0)
                {
                    element.Fill = new SolidColorBrush(Color.FromRgb(240, 25, 25));
                }
                else
                {
                    element.Fill = new SolidColorBrush(Color.FromRgb(58, 228, 81));
                }

                SnakeElement snakeElement = new SnakeElement(xCordSnakeHead - (i * headSize), yCordSnakeHead, element);
                snakeElements.Add(snakeElement);
            }
        }

        public void eat()
        {
            snakeLength++;
        }
        public void move()
        {
            for (int i = 0; i < snakeLength; i++)
            {
                snakeElements[i].xCordSnakeElement += 20;
                // drawSnake();
            }
        }

        public void turn()
        {

        }
    }
}
