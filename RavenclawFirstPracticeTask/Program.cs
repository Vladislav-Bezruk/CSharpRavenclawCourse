using System;

namespace RavenclawFirstPracticeTask
{
    class Program
    {
        static int Maximum(int Pos, int Count, int[] Num)
        {
            int MaxCount = 0, Max = -2147483647, PreMax = 0, MMax = 0;

            while (!(MaxCount == Pos || MaxCount >= Count))
            {
                Max = -2147483647;
                for (int i = 0; i < Count; i++)
                    if (Num[i] > Max && (Num[i] < PreMax || MaxCount == 0))
                        Max = Num[i];
                if (MaxCount == 0)
                    MMax = Max;
                if (Max == -2147483647)
                    break;
                PreMax = Max;
                MaxCount++;
            }
            if (MaxCount == Pos)
                return Max;
            else
                return MMax;
        }

        static void Main(string[] args)
        {
            int Count, Pos;

            Console.WriteLine("Enter the degree of maximum you want to find:");
            Pos = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of elements in the array:");
            Count = Convert.ToInt32(Console.ReadLine());
            int[] Num = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine("Enter the " + (i + 1) + " element in the array:");
                Num[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("The " + Pos + " maximum = " + Maximum(Pos, Count, Num));
            Console.ReadKey();
        }
    }
}