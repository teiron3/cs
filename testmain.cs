using System;

partial class test
{
    static void Main()
    {
        
        test t = new test{};
        pic_hit phit = new pic_hit();
        pic_make pmake = new pic_make();

        t.read_csv();
        //Console.WriteLine(t.p_class[2].Address);
        //pmake.pic_create(t.p_class[2]);
        //t.read_csv();


        Console.WriteLine(phit.pic_search(t.p_class[2]));

        return;
    }
}