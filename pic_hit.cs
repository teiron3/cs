using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Linq;

class test
{
        static void Main()
        {
            Bitmap src = new Bitmap( Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Bitmap bmp = new Bitmap( @"C:\"); 

            Graphics g = Graphics.FromImage(src);
            g.CopyFromScreen( new Point( 0, 0), new Point( 0, 0), src.Size);
            g.Dispose();

            BitmapData srcData = src.LockBits(new Rectangle( 0, 0, src.Width, src.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData bmpData = bmp.LockBits(new Rectangle( 0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] srcPix, bmpPix, srcLine, bmpLine;
            srcPix = new byte[ src.Width * src.Height * 4];
            bmpPix = new byte[ bmp.Width * bmp.Height * 4];

            srcLine = new byte[ bmp.Width * 4];
            bmpLine = new byte[ bmp.Width * 4];

            Marshal.Copy( srcData.Scan0, srcPix, 0, srcPix.Length);
            Marshal.Copy( bmpData.Scan0, bmpPix, 0, bmpPix.Length);

            Point agreePoint = Point.Empty;
            bool agree = true;

            for( int y = 0; y < src.Height - bmp.Height; y++)
            {
                for( int x = 0; x < src.Width - bmp.Width; x++)
                {
                    agree = true;
                    for( int yy = 0; yy < bmp.Height; yy++)
                    {
                        System.Array.Copy( srcPix, ( x + ( yy + y) * src.Width) * 4, srcLine, 0, ( srcLine.Length));
                        System.Array.Copy( bmpPix, yy * src.Width * 4, bmpLine, 0, ( bmpLine.Length));

                        if( srcLine.SequenceEqual( bmpLine) == false) agree = false;
                        if( agree == false) break;
                    }
                    if( agree)
                    {
                        System.Console.Write( x + " " + y);
                        break;
                    }
                }
                if(agree) break;
            }
            src.UnlockBits(srcData);
            bmp.UnlockBits(bmpData);
            return;
        }
}