using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeWpfApp
{
    public class Point
    {
        private int x;
        private int y;

        public Point()
        {
            Random rand = new Random();
            x = rand.Next(50);
            y = rand.Next(50);
        }

        public void placePoint()
        {
            Random rand = new Random();
        }
    }
}
