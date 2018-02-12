using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Linq;
using System;

class test
{
    static void Main()
    {
        string x = "test,555,6547";
        foreach (string y in x.Split(','))
        {
            Console.WriteLine(y);
        }

    }
}