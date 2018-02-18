using System;
using System.Drawing;
using System.Drawing.Imaging;

class test
{
    static void Main()
    {
        string file_path = "picplace.csv";
        if(System.IO.File.Exists(file_path) == false) return;

        System.IO.StreamReader text_strm = new System.IO.StreamReader(file_path, System.Text.Encoding.GetEncoding("shift_jis"));
        pic_data_class[] p_class = new pic_data_class[82];

        for(int i = 0; i < 82 ; ++i)
        {
            p_class[i] = new pic_data_class();
            string[] test_str;
            string s = text_strm.ReadLine();
            test_str = s.Split(',');
            p_class[i].name = test_str.Length == 1 ? test_str[0]: test_str[1]; 
        }
        foreach(pic_data_class p in p_class) Console.WriteLine(p.name);
        

        text_strm.Close();
    }
}

class pic_data_class
{
    public string name;
    public int pic_x;
    public int pic_y;
    public int pic_add_x;
    public int pic_add_y;
    public string pic_address;
    public Bitmap pic_data;

}