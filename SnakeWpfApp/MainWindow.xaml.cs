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
        private Snake snake;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            startGame();
            startButton.IsEnabled = false;
            newGameButton.IsEnabled = true;
        }

        private void startGame()
        {
            snake = new Snake();
            Canvas.SetLeft(snake.head, snake.xSnakeHead);
            Canvas.SetTop(snake.head, snake.ySnakeHead);
            gameBoard.Children.Add(snake.head);
            for (int i = 1; i < snake.snakeLength; i++)
            {
                Canvas.SetLeft(snake.snakeElements[i], snake.xSnakeHead - (i * snake.headSize));
                Canvas.SetTop(snake.snakeElements[i], snake.ySnakeHead);
                gameBoard.Children.Add(snake.snakeElements[i]);
            }
        }

        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            gameBoard.Children.RemoveRange(0,snake.snakeLength);
            startButton.IsEnabled = true;
            newGameButton.IsEnabled = false;
        }
    }
}
