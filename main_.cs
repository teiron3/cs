using System;

partial class test
{
    static void Main()
    {
        test tt = new test();
        tt.read_csv(); //p_class[]���f�[�^�N���X�̃C���X�^���X


        return;
    }
    mouse_class mmv = new mouse_class{};
    //pic_hit p_hit = new pic_hit{};

    void motherport()
    {
        //��`��ʂ̊m�F
        while (!pic_hit.pic_con(p_class[1]))
        {
            System.Threading.Thread.Sleep(2000);
        }

        //�����͑��̊m�F
        Byte flg = 0;
        if(pic_hit.pic_con(p_class[2]))flg += 2; 
        if(pic_hit.pic_con(p_class[3]))flg += 4;
        if(pic_hit.pic_con(p_class[4]))flg += 8;

        //�����͑����A�҂��Ă����ꍇ�⋋
        if(flg > 0)
        {
            //�⋋��ʂ�
            do
            {
                mmv.click(p_class[5]);
                System.Threading.Thread.Sleep(2000);
            } while (!pic_hit.pic_con(p_class[6]));

                


        }

    }
}