using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BAi14_XuLyNgoaiLe
{
    class FileNotFound
    { 
        static void Main()
        {
            try
            {               
                using (StreamReader reader = new StreamReader("not-there.txt"))
                {
                    reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.GetType());
            }
        }
    }
}
