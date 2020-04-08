using System;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SnakeWpfApp
{
    public class SnakeImage
    {
        private int _randInt;
        private string _randUrl = String.Empty;
        private string url1 = "https://cdn.pixabay.com/photo/2019/02/06/17/09/snake-3979601_960_720.jpg";
        private string url2 = "https://cdn.pixabay.com/photo/2013/12/10/18/22/green-tree-python-226553_960_720.jpg";
        private string url3 = "https://cdn.pixabay.com/photo/2014/10/25/00/17/snake-501986_960_720.jpg";
        private string url4 = "https://cdn.pixabay.com/photo/2015/10/30/15/04/green-tree-python-1014229_960_720.jpg";
        private string url5 = "https://cdn.pixabay.com/photo/2016/11/29/02/53/animal-1866944_960_720.jpg";
        
        public BitmapImage randomImage()
        {
            Hashtable hashtable = new Hashtable
            {
                {0, url1},
                {1, url2},
                {2, url3},
                {3, url4},
                {4, url5}
            };

            Random rand = new Random();
            _randInt = rand.Next(5);
            _randUrl = hashtable[_randInt].ToString();
            BitmapImage bitmap = downloadImage(_randUrl);
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
