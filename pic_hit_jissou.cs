using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Linq;

class pic_hit
{
        public bool pic_con(int xx, int yy, int add_x, int add_y, Bitmap bmp)
        {
            Bitmap src = new Bitmap( add_x, add_y);
            
            Graphics g = Graphics.FromImage(src);
            g.CopyFromScreen( new Point( xx, yy), new Point( 0, 0), src.Size);
            g.Dispose();

            BitmapData srcData = src.LockBits(new Rectangle( 0, 0, src.Width, src.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData bmpData = bmp.LockBits(new Rectangle( 0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] srcPix, bmpPix;
            srcPix = new byte[ src.Width * src.Height * 4];
            bmpPix = new byte[ bmp.Width * bmp.Height * 4];

            Marshal.Copy( srcData.Scan0, srcPix, 0, srcPix.Length);
            Marshal.Copy( bmpData.Scan0, bmpPix, 0, bmpPix.Length);

            bool agree = false;

            if( srcPix.SequenceEqual( bmpPix) == true) agree = true;
            src.UnlockBits(srcData);
            bmp.UnlockBits(bmpData);
            return agree;
        }
}

class pic_make
{
    public void pic_create(int x, int y, int width, int height)
    {
        Bitmap bmp = new Bitmap( width, height);
        Graphics g = Graphics.FromImage(bmp);
        g.CopyFromScreen( new Point( x, y), new Point( 0, 0), bmp.Size);

        g.Dispose();
        bmp.Save(@"C:\Users\teiro\Desktop\test_pic.bmp");
        
    }
}