using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

partial class test
{
    /*csvファイルのデータを格納するデータ型クラス宣言 */
    public pic_data_class[] p_class;

    /*csvファイル名の設定 */
    public string csv_file{get{return "csv_file.csv";}}

    /*データの数(csvファイルの行数)設定 */
    public int rows =96;

/* 
    static void Main()
    {
        var t =new test();
        t.read_csv();
        t.add_bool();
        
        t.p_class = new pic_data_class[1];
        t.p_class[0] = new pic_data_class();
        t.p_class[0].name = "test";
        Console.Write("マウスカーソル位置を取得します。よければキーを押して下さい。");
        Console.ReadLine();
        t.p_class[0].pic_x = Cursor.Position.X;
        t.p_class[0].pic_y = Cursor.Position.Y;
        Console.Write("マウスカーソルの位置２を取得します。よければキーを押してください。");
        Console.ReadLine();
        t.p_class[0].pic_add_x = Cursor.Position.X - t.p_class[0].pic_x;
        t.p_class[0].pic_add_y = Cursor.Position.Y - t.p_class[0].pic_y;
        
        t.write_csv();
    }
*/

    /*csvファイルを読み込んでデータ型クラスに入れるメソッド */
    public void read_csv()
    {
        this.p_class = new pic_data_class[rows];

        string file_path = csv_file; //picplace.csv";
        if(!System.IO.File.Exists(file_path)) {Console.WriteLine("csvファイルがありません");return;}

        System.IO.StreamReader text_strm = new System.IO.StreamReader(file_path, System.Text.Encoding.GetEncoding("shift_jis"));
        for(int i = 0; i < rows ; ++i)
        {
            this.p_class[i] = new pic_data_class();
            string[] test_str;
            string s = text_strm.ReadLine();
            test_str = s.Split(',');
            
            this.p_class[i].Name = test_str[0];
            if(test_str.Length >= 2) this.p_class[i].Set_Necessity = test_str[1];
            if(test_str.Length >= 3) this.p_class[i].X = int.Parse(test_str[2]);
            if(test_str.Length >= 4) this.p_class[i].Y = int.Parse(test_str[3]);
            if(test_str.Length >= 5) this.p_class[i].Width = int.Parse(test_str[4]);
            if(test_str.Length >= 6) this.p_class[i].Height = int.Parse(test_str[5]);
            if(test_str.Length >= 7) this.p_class[i].Pic_X = int.Parse(test_str[6]);
            if(test_str.Length >= 8) this.p_class[i].Pic_Y = int.Parse(test_str[7]);
            if(test_str.Length >= 9) this.p_class[i].Pic_Width = int.Parse(test_str[8]);
            if(test_str.Length >= 10) this.p_class[i].Pic_Height = int.Parse(test_str[9]);
            if(test_str.Length >= 11) this.p_class[i].Pic_CreateDate = test_str[10];
            
            if(p_class[i].Necessity == true)
            {
                if(System.IO.File.Exists(p_class[i].Address))
                    this.p_class[i].Pic_data = new Bitmap(p_class[i].Address);
                else
                    MessageBox.Show(p_class[i].Name + "のファイルがありません");
            }
            
        }
        text_strm.Close();
    }

    /*クラス内のデータをcsvファイルに書き込むメソッド */
    public void write_csv()
    {
        if(System.IO.File.Exists(csv_file) == true)
        {
            Console.Write("以前のファイルはバックアップフォルダに移します");
            if(System.IO.Directory.Exists(@".\csv_bk") == false)System.IO.Directory.CreateDirectory(@".\csv_bk");
            System.IO.File.Move(csv_file, @".\csv_bk\" + System.DateTime.Now.ToString("yyMMddHHmmss") + csv_file);
        }
        else
            Console.WriteLine("以前のファイルは見つかりませんでした。新たに作成します");
            
        System.IO.StreamWriter text_strm = new System.IO.StreamWriter(csv_file, false, System.Text.Encoding.GetEncoding("shift_jis"));
        foreach(pic_data_class p in this.p_class)
            text_strm.WriteLine(p.Name + "," + p.Necessity + "," + p.X + "," + p.Y + "," + p.Width + "," + p.Height + ","
            + p.Pic_X + "," + p.Pic_Y + "," + p.Pic_Width + "," + p.Pic_Height + "," + p.Pic_CreateDate);
        text_strm.Close();
    }

    public void get_data(pic_data_class p)
    {
        Console.Write("左上座標として取得します。マウスカーソルを合わせてキーを押して下さい。");
        Console.ReadLine();
        p.X = Cursor.Position.X;
        p.Y = Cursor.Position.Y;
        do{
            Console.Write("右下座標として取得します。");
            Console.Write("値が+になるようにマウスカーソルを合わせてキーを押してください。");
            Console.ReadLine();
            p.Width = Cursor.Position.X - p.X;
            p.Height = Cursor.Position.Y - p.Y;            
        } while (p.Width <= 0 && p.Height <= 0);

        Console.Write("取得画像左上座標として取得します。マウスカーソルを合わせてキーを押して下さい。");
        Console.ReadLine();
        p.Pic_X = Cursor.Position.X;
        p.Pic_Y = Cursor.Position.Y;
        do{
            Console.Write("取得画像右下座標として取得します。");
            Console.Write("値が+になるようにマウスカーソルを合わせてキーを押してください。");
            Console.ReadLine();
            p.Pic_Width = Cursor.Position.X - p.Pic_X;
            p.Pic_Height = Cursor.Position.Y - p.Pic_Y;            
        } while (p.Pic_Width <= 0 && p.Pic_Height <= 0);

    }

    /*
    public void add_bool()
    {
        foreach(pic_data_class p in p_class)
        {
            for(int a = 0 ; a == 0 ; )
            {   
                a++;
                Console.Write("[" + p.Name +"]の画像取得が必要なら[t]を、不要な[f]を押してください=>");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                if(key.Key == ConsoleKey.T) p.Necessity = true;
                else if(key.Key == ConsoleKey.F) p.Necessity = false;
                    else a = 0;
            } 
        }
    }

    public void read_bmp()
    {
        if(!System.IO.Directory.Exists("pic_folder"))
        {
            Console.WriteLine("「pic_folder」がありません。フォルダを作成し、bmp読み込みは中止します。");
            System.IO.Directory.CreateDirectory("pic_folder");
            return;
        }
        foreach(pic_data_class p in this.p_class)
        {
            if(!p.Necessity) continue;
            if(System.IO.File.Exists(p.Address))
            {
                
            }
            else
                Console.WriteLine(p.Name + "のbmpファイルがありません");
        }
    }
     */



}

class pic_data_class
{
    bool need;

    public string Name{get;set;}
    public bool Necessity{get{return need;}set{need = value;}}
    public string Set_Necessity{get{return "";} set{ if(value == "True") need = true;else need = false;}}
    public int X{get;set;}
    public int Y{get;set;}
    public int Width{get;set;}
    public int Height{get;set;}
    public int Pic_X{get;set;}
    public int Pic_Y{get;set;}
    public int Pic_Width{get;set;}
    public int Pic_Height{get;set;}
    public string Pic_CreateDate{get;set;}
    public Bitmap Pic_data{get;set;}
    public string Address{get{return @".\pic_folder\" + this.Name + ".bmp";}}

}

class pic_make
{
    static public void pic_create(pic_data_class obj)
    {
        Bitmap bmp = new Bitmap( obj.Pic_Width, obj.Pic_Height);
        Graphics g = Graphics.FromImage(bmp);
        g.CopyFromScreen( new Point( obj.Pic_X, obj.Pic_Y), new Point( 0, 0), bmp.Size);

        g.Dispose();
        bmp.Save(obj.Address);
        
    }
}