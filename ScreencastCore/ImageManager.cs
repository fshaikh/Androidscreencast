using com.android.ddmlib;
using java.awt.image;
using java.io;
using javax.imageio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaInterop
{
    public class ImageManager
    {
        public static BufferedImage toBufferedImage(RawImage rawImage)
        {
            int       W = rawImage.width;
            int       H = rawImage.height;
            BufferedImage   image = new BufferedImage(W, H, BufferedImage.TYPE_INT_RGB);
            int  bytesPerPixels = rawImage.bpp >> 3; //bpp = bits / pixels --> bytes / pixels

            for (int y = 0, pxIdx = 0; y < H; y++) {
                for (int x = 0; x < W; x++, pxIdx += bytesPerPixels) {
                    image.setRGB(x, y, rawImage.getARGB(pxIdx));
                }
            }

            return image;
        }

        public static System.Drawing.Bitmap GetScreenshot()
        {
            var image = GetScreenshotInternal();
            return image.getBitmap();
        }

        private static BufferedImage GetScreenshotInternal()
        {
            RawImage rawImage = null;
            try
            {
                rawImage = Application.DeviceManager.GetDevice().getScreenshot();
            }
            catch (com.android.ddmlib.TimeoutException ex)
            {
                System.Console.WriteLine("timeout while getting screenshot");
                return null;
            }
            BufferedImage bufferedImage = ImageManager.toBufferedImage(rawImage);
            
            return bufferedImage;
        }

        public static void SaveScreenshot()
        {
            string filePath = GetFilePath();
            File outputfile = new File(filePath);
            ImageIO.write(GetScreenshotInternal(), "jpg", outputfile);
        }

        private static string GetFilePath()
        {
            return @"C:\\Screenshots\" + Guid.NewGuid().ToString() + ".jpg";
        }
    }
}
