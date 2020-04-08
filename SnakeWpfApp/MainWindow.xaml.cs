using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        public bool directionChanged = false;
        public int timeInterval;
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
            timeInterval = 200;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(timeInterval);
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
                SnakeElement newSnakeElement = snake.eat();
                score++;
                scoreLabel.Content = score;

                Canvas.SetLeft(newSnakeElement.element, newSnakeElement.xCordSnakeElement);
                Canvas.SetTop(newSnakeElement.element, newSnakeElement.yCordSnakeElement);
                gameBoard.Children.Add(newSnakeElement.element);

                gameBoard.Children.Remove(food.rectanglePoint);
                showFood();

                snakeImage = new SnakeImage();
                imageField.Source = snakeImage.randomImage();

                if (timeInterval > 50)
                {
                    timeInterval -= 15;
                }
                dispatcherTimer.Interval = TimeSpan.FromMilliseconds(timeInterval);
            }

            directionChanged = false;
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
            if (!directionChanged)
            {
                switch (e.Key)
                {
                    case Key.Up:
                        if (snake.direction != Snake.Direction.Down)
                        {
                            snake.direction = Snake.Direction.Up;
                            directionChanged = true;
                        }

                        break;
                    case Key.Down:
                        if (snake.direction != Snake.Direction.Up)
                        {
                            snake.direction = Snake.Direction.Down;
                            directionChanged = true;
                        }

                        break;
                    case Key.Left:
                        if (snake.direction != Snake.Direction.Right)
                        {
                            snake.direction = Snake.Direction.Left;
                            directionChanged = true;
                        }

                        break;
                    case Key.Right:
                        if (snake.direction != Snake.Direction.Left)
                        {
                            snake.direction = Snake.Direction.Right;
                            directionChanged = true;
                        }

                        break;
                }
            }
        }

    }
}
