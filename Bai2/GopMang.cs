using System;
namespace Bai2
{
    public static class MergingArray
    {
        public static void Main()
        {
            Console.Write("Array1: ");
            float[] array1 = generateArray();
            printfloatArray(array1);
            Console.Write("Array2: ");
            float[] array2 = generateArray(8);
            printfloatArray(array2);
            Console.Write("Array3: ");
            printfloatArray(mergingArray(array1, array2));

        }
        public static float[] generateArray(int size = 6)
        {
            float[] arrar = new float[size];
            Random rnd = new Random();
            for (byte i = 0; i < arrar.Length; i++)
            {
                arrar[i] = rnd.Next(-9, 9);
            }
            return arrar;
        }
        public static float[] mergingArray(float[] arr1, float[] arr2)
        {
            float[] arr3 = new float[arr1.Length + arr2.Length];
            for (byte i = 0; i < arr1.Length; i++)
            {
                arr3[i] = arr1[i];
            }
            for (byte i = 0; i < arr2.Length; i++)
            {
                arr3[arr1.Length + i] = arr2[i];
            }
            return arr3;
        }
        public static void printfloatArray(float[] array)
        {
            for (byte i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}