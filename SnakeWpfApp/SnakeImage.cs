using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Media;

namespace SnakeWpfApp
{
    public class SnakeImage
    {
        private string url1 = "https://cdn.pixabay.com/photo/2019/02/06/17/09/snake-3979601_960_720.jpg";
        private string url2 = "https://cdn.pixabay.com/photo/2010/12/14/16/46/snake-3237_960_720.jpg";
        private string url3 = "https://pixabay.com/photos/snake-python-ball-python-419043/";
        private string url4 = "https://pixabay.com/photos/snake-python-ball-python-419043/";
        private string url5 = "https://pixabay.com/photos/snake-python-ball-python-419043/";

        public void randomImage()
        {
            downloadImage(url1);
            
        }
        public void downloadImage(string fromUrl)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(url1, "image.jpg");
            }
        }



    }
}
