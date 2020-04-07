using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnakeWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Snake snake;
        public Food food;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            startGame();
            startButton.IsEnabled = false;
            newGameButton.IsEnabled = true;

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0,0,500);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object? sender, EventArgs e)
        {
            // MessageBox.Show("test");
            snake.move();
            for (int i = 0; i < snake.snakeLength; i++)
            {
                Canvas.SetLeft(snake.snakeElements[i].element, snake.snakeElements[i].xCordSnakeElement);
                Canvas.SetTop(snake.snakeElements[i].element, snake.snakeElements[i].yCordSnakeElement);
            }

        }

        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            // gameBoard.Children.RemoveRange(0, snake.snakeLength);
            gameBoard.Children.Clear();
            startButton.IsEnabled = true;
            newGameButton.IsEnabled = false;
        }

        private void startGame()
        {
            snake = new Snake();

            for (int i = 0; i < snake.snakeLength; i++)
            {
                Canvas.SetLeft(snake.snakeElements[i].element, snake.snakeElements[i].xCordSnakeElement);
                Canvas.SetTop(snake.snakeElements[i].element, snake.snakeElements[i].yCordSnakeElement);
                gameBoard.Children.Add(snake.snakeElements[i].element);
            }
            showFood();
        }

        private void showFood()
        {
            food = new Food();
            bool collision = true;

            while (collision)
            {
                for (int i = 0; i < snake.snakeLength; i++)
                {
                    if (food.xFood.ToString() == snake.snakeElements[i].xCordSnakeElement.ToString() && food.yFood.ToString() == snake.snakeElements[i].yCordSnakeElement.ToString())
                    {
                        food = new Food();
                    }
                    else
                    {
                        collision = false;
                    }
                }
            }

            if (!collision)
            {
                Canvas.SetLeft(food.rectanglePoint, food.xFood);
                Canvas.SetTop(food.rectanglePoint, food.yFood);
                gameBoard.Children.Add(food.rectanglePoint);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    if (snake.direction != Snake.Direction.Down)
                    {
                        snake.direction = Snake.Direction.Up;
                    }
                    break;
                case Key.Down:
                    if (snake.direction != Snake.Direction.Up)
                    {
                        snake.direction = Snake.Direction.Down;
                    }
                    break;
                case Key.Left:
                    if (snake.direction != Snake.Direction.Right)
                    {
                        snake.direction = Snake.Direction.Left;
                    }
                    break;
                case Key.Right:
                    if (snake.direction != Snake.Direction.Left)
                    {
                        snake.direction = Snake.Direction.Right;
                    }
                    break;
            }
        }

    }
}
