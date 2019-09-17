using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace CutVideoToGif.Helper
{
    public static class GifHelper
    {
        public static void d()
        {
            Image image = new Bitmap("Apple.gif");

            // Draw the image unaltered with its upper-left corner at (0, 0).
            e.Graphics.DrawImage(image, 0, 0);

            // Make the destination rectangle 30 percent wider and
            // 30 percent taller than the original image.
            // Put the upper-left corner of the destination
            // rectangle at (150, 20).
            int width = image.Width;
            int height = image.Height;
            RectangleF destinationRect = new RectangleF(
                150,
                20,
                1.3f * width,
                1.3f * height);

            // Draw a portion of the image. Scale that portion of the image
            // so that it fills the destination rectangle.
            RectangleF sourceRect = new RectangleF(0, 0, .75f * width, .75f * height);
            e.Graphics.DrawImage(
                image,
                destinationRect,
                sourceRect,
                GraphicsUnit.Pixel);
        }
    }
}
