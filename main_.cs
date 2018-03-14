using System;

partial class test
{
    static void Main()
    {
        test tt = new test();
        tt.read_csv(); //p_class[]がデータクラスのインスタンス


        return;
    }
    mouse_class mmv = new mouse_class{};
    //pic_hit p_hit = new pic_hit{};

    void motherport()
    {
        //母港画面の確認
        while (!pic_hit.pic_con(p_class[1]))
        {
            System.Threading.Thread.Sleep(2000);
        }

        //遠征艦隊の確認
        Byte flg = 0;
        if(pic_hit.pic_con(p_class[2]))flg += 2; 
        if(pic_hit.pic_con(p_class[3]))flg += 4;
        if(pic_hit.pic_con(p_class[4]))flg += 8;

        //遠征艦隊が帰還していた場合補給
        if(flg > 0)
        {
            //補給画面に
            do
            {
                mmv.click(p_class[5]);
                System.Threading.Thread.Sleep(2000);
            } while (!pic_hit.pic_con(p_class[6]));

                


        }

    }
}