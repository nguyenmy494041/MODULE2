using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BAi14_XuLyNgoaiLe
{
    class IndexOutOfRange
    {
        static void Main()
        {

            try
            {
                List<char> characters = new List<char>();
                characters.InsertRange(0, new Char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' });
                int value = characters[10];
                Console.WriteLine(value);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("aujshbjh");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType());
            }

        }
    }
}
