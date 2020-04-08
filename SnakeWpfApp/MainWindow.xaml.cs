using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
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
using System.Windows.Threading;

namespace SnakeWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Snake snake;
        public Food food;
        public SnakeImage snakeImage;
        public int score;
        DispatcherTimer dispatcherTimer; 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            startGame();
            startButton.IsEnabled = false;
            newGameButton.IsEnabled = true;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0,0,200);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            snake.move();
            for (int i = 0; i < snake.snakeLength; i++)
            {
                Canvas.SetLeft(snake.snakeElements[i].element, snake.snakeElements[i].xCordSnakeElement);
                Canvas.SetTop(snake.snakeElements[i].element, snake.snakeElements[i].yCordSnakeElement);
            }

            if (snake.snakeElements[0].xCordSnakeElement >= gameBoard.Width ||
                snake.snakeElements[0].xCordSnakeElement < 0 ||
                snake.snakeElements[0].yCordSnakeElement >= gameBoard.Height ||
                snake.snakeElements[0].yCordSnakeElement < 0)
            {
                gameOver();
            }


            for (int i = 1; i < snake.snakeLength; i++)
            {
                if (snake.snakeElements[0].xCordSnakeElement == snake.snakeElements[i].xCordSnakeElement &&
                    snake.snakeElements[0].yCordSnakeElement == snake.snakeElements[i].yCordSnakeElement)
                {
                    gameOver();
                }
            }

            if (snake.snakeElements[0].xCordSnakeElement == food.xFood
                && snake.snakeElements[0].yCordSnakeElement == food.yFood)
            {
                // imageField.Source;
                // snakeImage.randomImage();
                SnakeElement newSnakeElement = snake.eat();
                score++;
                scoreLabel.Content = score;

                Canvas.SetLeft(newSnakeElement.element, newSnakeElement.xCordSnakeElement);
                Canvas.SetTop(newSnakeElement.element, newSnakeElement.yCordSnakeElement);
                gameBoard.Children.Add(newSnakeElement.element);

                gameBoard.Children.Remove(food.rectanglePoint);
                showFood();
            }
        }

        private void gameOver()
        {
            dispatcherTimer.Stop();
            gameBoard.Children.Remove(food.rectanglePoint);
            gameOverLabel.Visibility = Visibility.Visible;
            gameOverLabel.Visibility = Visibility.Visible;
            gameOverScoreLabel.Visibility = Visibility.Visible;
            gameOverScore.Content = score;
            gameOverScore.Visibility = Visibility.Visible;
        }

        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < snake.snakeLength; i++)
            {
                gameBoard.Children.Remove(snake.snakeElements[i].element);
            }
            gameBoard.Children.Remove(food.rectanglePoint);
            gameOverLabel.Visibility = Visibility.Hidden;
            gameOverScoreLabel.Visibility = Visibility.Hidden;
            gameOverScore.Visibility = Visibility.Hidden;

            startButton.IsEnabled = true;
            newGameButton.IsEnabled = false;
            score = 0;
            scoreLabel.Content = 0;
            dispatcherTimer.Stop();
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
                    if (food.xFood.ToString() == snake.snakeElements[i].xCordSnakeElement.ToString() 
                        && food.yFood.ToString() == snake.snakeElements[i].yCordSnakeElement.ToString())
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
