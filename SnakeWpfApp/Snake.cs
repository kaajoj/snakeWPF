using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        public Direction direction;
        public List<SnakeElement> snakeElements = new List<SnakeElement>();

        public enum Direction { Left, Right, Up, Down }

        public Snake()
        {
            direction = Direction.Right;
            headSize = 20;
            snakeLength = 5;
            xCordSnakeHead = 160;
            yCordSnakeHead = 180;
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
            SnakeElement snakeElement = new SnakeElement();
            snakeElements.Add(snakeElement);
        }

        public void move()
        {
            SnakeElement tempElement = new SnakeElement();
            for (int i = 0; i < snakeLength; i++)
            {
                if (i==0)
                {
                    tempElement.xCordSnakeElement = snakeElements[i].xCordSnakeElement;
                    tempElement.yCordSnakeElement = snakeElements[i].yCordSnakeElement;

                    switch (direction)
                    {
                        case Direction.Up:
                            snakeElements[i].yCordSnakeElement -= 20;
                            break;
                        case Direction.Down:
                            snakeElements[i].yCordSnakeElement += 20;
                            break;
                        case Direction.Left:
                            snakeElements[i].xCordSnakeElement -= 20;
                            break;
                        case Direction.Right:
                            snakeElements[i].xCordSnakeElement += 20;
                            break;
                    } 
                } else 
                {
                    SnakeElement newSnakeElement = new SnakeElement();
                    newSnakeElement.xCordSnakeElement = snakeElements[i].xCordSnakeElement;
                    newSnakeElement.yCordSnakeElement = snakeElements[i].yCordSnakeElement;

                    snakeElements[i].xCordSnakeElement = tempElement.xCordSnakeElement;
                    snakeElements[i].yCordSnakeElement = tempElement.yCordSnakeElement;

                    tempElement.xCordSnakeElement = newSnakeElement.xCordSnakeElement;
                    tempElement.yCordSnakeElement = newSnakeElement.yCordSnakeElement;
                }
            }
        }

    }
}
