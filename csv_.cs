using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

class csv_class
{
    /*csvファイルのデータを格納するデータ型クラス宣言 */
    public pic_data_class[] p_class;

    /*csvファイル名の設定 */
    private string csv_file = "csv_file.csv";

    /*データの数(csvファイルの行数)設定 */
    private int rows =96;

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
        Func<string, bool> exist = (ff) => {if(ff == "true") return true;else return false;};
        for(int i = 0; i < rows ; ++i)
        {
            this.p_class[i] = new pic_data_class();
            string[] test_str;
            string s = text_strm.ReadLine();
            test_str = s.Split(',');
            
            this.p_class[i].name = test_str[0];
            if(test_str.Length >= 2) this.p_class[i].pic_exist = exist(test_str[1]) ;
            if(test_str.Length >= 3) this.p_class[i].x = int.Parse(test_str[2]);
            if(test_str.Length >= 4) this.p_class[i].y = int.Parse(test_str[3]);
            if(test_str.Length >= 5) this.p_class[i].add_x = int.Parse(test_str[4]);
            if(test_str.Length >= 6) this.p_class[i].add_y = int.Parse(test_str[5]);
            if(test_str.Length >= 7) this.p_class[i].pic_x = int.Parse(test_str[6]);
            if(test_str.Length >= 8) this.p_class[i].pic_y = int.Parse(test_str[7]);
            if(test_str.Length >= 9) this.p_class[i].pic_add_x = int.Parse(test_str[8]);
            if(test_str.Length >= 10) this.p_class[i].pic_add_y = int.Parse(test_str[9]);
        }
        text_strm.Close();
    }

    /*クラス内のデータをcsvファイルに書き込むメソッド */
    public void write_csv()
    {
        if(System.IO.File.Exists(csv_file) == true)
        {
            Console.Write("以前のファイルはバックアップフォルダに移します");Console.ReadKey();
            if(System.IO.Directory.Exists(@".\csv_bk") == false)System.IO.Directory.CreateDirectory(@".\csv_bk");
            System.IO.File.Move(csv_file, @".\csv_bk\" + System.DateTime.Now.ToString("yyMMddHHmm") + csv_file);
        }
        else
            Console.WriteLine("以前のファイルは見つかりませんでした。新たに作成します");
            
        System.IO.StreamWriter text_strm = new System.IO.StreamWriter(csv_file, false, System.Text.Encoding.GetEncoding("shift_jis"));
        foreach(pic_data_class p in this.p_class)text_strm.WriteLine(p.name + "," + p.pic_exist + "," + p.x + "," + p.y + "," + p.add_x + "," + p.add_y + ","
                                                                    + p.pic_x + "," + p.pic_y + "," + p.pic_add_x + "," + p.pic_add_y );
        text_strm.Close();
    }

    public void add_bool()
    {
        foreach(pic_data_class p in p_class)
        {
            for(int a = 0 ; a == 0 ; )
            {   
                a++;
                Console.Write("[" + p.name +"]の画像取得が必要なら[t]を、不要な[f]を押してください=>");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                if(key.Key == ConsoleKey.T) p.pic_exist = true;
                else if(key.Key == ConsoleKey.F) p.pic_exist = false;
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
            if(!p.pic_exist) continue;
            if(System.IO.File.Exists(@"pic_folder\" + p.name + ".bmp"))
            {
                
            }
            else
                Console.WriteLine(p.name + "のbmpファイルがありません");
        }
    }



}

class pic_data_class
{
    public string name;
    public bool pic_exist;
    public int x;
    public int y;
    public int add_x;
    public int add_y;
    public int pic_x;
    public int pic_y;
    public int pic_add_x;
    public int pic_add_y;
    public Bitmap pic_data;

}