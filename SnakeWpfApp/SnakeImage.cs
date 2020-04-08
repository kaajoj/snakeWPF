using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SnakeWpfApp
{
    public class SnakeImage
    {
        private string url1 = "https://cdn.pixabay.com/photo/2019/02/06/17/09/snake-3979601_960_720.jpg";
        private string url2 = "https://cdn.pixabay.com/photo/2010/12/14/16/46/snake-3237_960_720.jpg";
        private string url3 = "https://cdn.pixabay.com/photo/2014/08/15/21/40/snake-419043_960_720.jpg";
        private string url4 = "https://cdn.pixabay.com/photo/2015/10/30/15/04/green-tree-python-1014229_960_720.jpg";
        private string url5 = "https://cdn.pixabay.com/photo/2016/11/29/02/53/animal-1866944_960_720.jpg";
        private int randInt;
        private string randUrl = String.Empty;

        public BitmapImage randomImage()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add(0, url1);
            hashtable.Add(1, url2);
            hashtable.Add(2, url3);
            hashtable.Add(3, url4);
            hashtable.Add(4, url5);

            Random rand = new Random();
            randInt = rand.Next(5);
            randUrl = hashtable[randInt].ToString();
            BitmapImage bitmap = downloadImage(randUrl);
            return bitmap;
        }

        public BitmapImage downloadImage(string url)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.UriSource = new Uri(url);
            bitmap.EndInit();

            return bitmap;
        }

    }
}
