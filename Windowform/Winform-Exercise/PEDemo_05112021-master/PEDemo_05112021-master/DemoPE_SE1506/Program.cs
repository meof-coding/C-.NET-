using System;

namespace DemoPE_SE1506
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student s = new Student("SE12067");  //0.5
                s.InputInfo();  //0.5
                Console.WriteLine(s.ToString());  //0.5
            }
            catch (IncorrectNameFormatException e)  //0.5
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();

        }
    }
}
