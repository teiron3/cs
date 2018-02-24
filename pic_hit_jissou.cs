using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Linq;

class pic_hit
{
        public bool pic_con(pic_data_class obj)
        {
            Bitmap src = new Bitmap( obj.pic_add_x, obj.pic_add_y);
            
            Graphics g = Graphics.FromImage(src);
            g.CopyFromScreen( new Point( obj.pic_x , obj.pic_y), new Point( 0, 0), src.Size);
            g.Dispose();

            BitmapData srcData = src.LockBits(new Rectangle( 0, 0, src.Width, src.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData bmpData = obj.pic_data.LockBits(new Rectangle( 0, 0, obj.pic_data.Width, obj.pic_data.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] srcPix, bmpPix;
            srcPix = new byte[ src.Width * src.Height * 4];
            bmpPix = new byte[ obj.pic_data.Width * obj.pic_data.Height * 4];

            Marshal.Copy( srcData.Scan0, srcPix, 0, srcPix.Length);
            Marshal.Copy( bmpData.Scan0, bmpPix, 0, bmpPix.Length);

            bool agree = false;

            if( srcPix.SequenceEqual( bmpPix) == true) agree = true;
            src.UnlockBits(srcData);
            obj.pic_data.UnlockBits(bmpData);
            return agree;
        }
}

class pic_make
{
    public void pic_create(pic_data_class obj)
    {
        Bitmap bmp = new Bitmap( obj.pic_add_x, obj.pic_add_y);
        Graphics g = Graphics.FromImage(bmp);
        g.CopyFromScreen( new Point( obj.pic_x, obj.pic_y), new Point( 0, 0), bmp.Size);

        g.Dispose();
        obj.pic_data = bmp.Save(@".\pic\" + obj.name + ".bmp");
        
    }
}