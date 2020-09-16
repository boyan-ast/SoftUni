using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalMoney = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsabresPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            int freeBelts = students / 6;
            double lightsabres = Math.Ceiling(1.1 * students);

            double spentMoney = lightsabres * lightsabresPrice + (students - freeBelts) * beltsPrice + students * robesPrice;

            if (spentMoney <= totalMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {spentMoney:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(spentMoney - totalMoney):f2}lv more.");
            }
        }
    }
}
