using System.Drawing;

namespace Carrosse.Figures
{
    public class Rotation
    {
        public static Bitmap Image(Bitmap imageSource, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap imageDestination = new Bitmap(imageSource.Width, imageSource.Height);
            //make a graphics object from the empty bitmap
            using(Graphics g = Graphics.FromImage(imageDestination)) 
            {
                //move rotation point to center of image
                g.TranslateTransform((float)imageSource.Width / 2, (float)imageSource.Height / 2);
                //rotate
                g.RotateTransform(angle);
                //move image back
                g.TranslateTransform(-(float)imageSource.Width / 2, -(float)imageSource.Height / 2);
                //draw passed in image onto graphics object
                g.DrawImage(imageSource, new Point(0, 0)); 
            }
            
            return imageDestination;
        }
    }
}