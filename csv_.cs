using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

class test
{
    /*�f�[�^�^�N���X�錾 */
    public pic_data_class[] p_class;

    static void Main()
    {
        var t =new test();
        t.read_csv();
        t.add_bool();
        /* 
        t.p_class = new pic_data_class[1];
        t.p_class[0] = new pic_data_class();
        t.p_class[0].name = "test";
        Console.Write("�}�E�X�J�[�\���ʒu���擾���܂��B�悯��΃L�[�������ĉ������B");
        Console.ReadLine();
        t.p_class[0].pic_x = Cursor.Position.X;
        t.p_class[0].pic_y = Cursor.Position.Y;
        Console.Write("�}�E�X�J�[�\���̈ʒu�Q���擾���܂��B�悯��΃L�[�������Ă��������B");
        Console.ReadLine();
        t.p_class[0].pic_add_x = Cursor.Position.X - t.p_class[0].pic_x;
        t.p_class[0].pic_add_y = Cursor.Position.Y - t.p_class[0].pic_y;
        */
        t.write_csv();
    }

    /*csv�t�@�C����ǂݍ���Ńf�[�^�^�N���X�ɓ���郁�\�b�h */
    private void read_csv()
    {
        this.p_class = new pic_data_class[82];

        string file_path = "picplace.csv";
        if(System.IO.File.Exists(file_path) == false) return;

        System.IO.StreamReader text_strm = new System.IO.StreamReader(file_path, System.Text.Encoding.GetEncoding("shift_jis"));

        for(int i = 0; i < 82 ; ++i)
        {
            this.p_class[i] = new pic_data_class();
            string[] test_str;
            string s = text_strm.ReadLine();
            test_str = s.Split(',');
            
            this.p_class[i].name = test_str[0];
            if(test_str.Length >= 2) this.p_class[i].pic_x = int.Parse(test_str[1]);
            if(test_str.Length >= 3) this.p_class[i].pic_y = int.Parse(test_str[2]);
            if(test_str.Length >= 4) this.p_class[i].pic_add_x = int.Parse(test_str[3]);
            if(test_str.Length >= 5) this.p_class[i].pic_add_y = int.Parse(test_str[4]);
            if(test_str.Length >= 6) this.p_class[i].pic_address = test_str[5];
        }
            text_strm.Close();
    }

    /*�N���X���̃f�[�^��csv�t�@�C���ɏ������ރ��\�b�h */
    private void write_csv()
    {
        if(System.IO.Directory.Exists(@".\test") == false) System.IO.Directory.CreateDirectory(@".\test");
        string file_path = @".\test\" + Console.ReadLine();
        System.IO.StreamWriter text_strm = new System.IO.StreamWriter(file_path, false, System.Text.Encoding.GetEncoding("shift_jis"));
        foreach(pic_data_class p in this.p_class)text_strm.WriteLine(p.name + "," + p.pic_exist + ", " + p.pic_x + "," + p.pic_y + "," + p.pic_add_x + "," + p.pic_add_y + "," + p.pic_address );
        text_strm.Close();
    }

    private void add_bool()
    {
        foreach(pic_data_class p in p_class)
        {
            for(int a = 0 ; a == 0 ; )
            {   
                a++;
                Console.Write("[" + p.name +"]�̉摜�擾���K�v�Ȃ�[t]���A�s�v��[f]�������Ă�������=>");
                string flg = Console.ReadLine();
                if(flg == "t") p.pic_exist = true;
                else if(flg == "f") p.pic_exist = false;
                    else a = 0;
            } 
        }
    }



}

class pic_data_class
{
    public string name;
    public bool pic_exist;
    public int pic_x;
    public int pic_y;
    public int pic_add_x;
    public int pic_add_y;
    public string pic_address;
    public Bitmap pic_data;

}