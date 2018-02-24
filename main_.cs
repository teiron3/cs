using System;

class main_class
{
    static void Main()
    {
    Console.Write("test");
    
    mouse_class tt = new mouse_class{};
 
    tt.click(300 , 50 , 500, 800);

    csv_class csv = new csv_class{};
    csv.read_csv();
    pic_make pmake = new pic_make{};
    pmake.pic_create(csv.p_class[1]);
    pic_hit pcon = new pic_hit{};
    if(pcon.pic_con(csv.p_class[1]))Console.WriteLine("Ç†ÇËÇ‹ÇµÇΩÅ[");
    else Console.WriteLine("Ç»Ç¢Ç∑");
    return;
    }
}