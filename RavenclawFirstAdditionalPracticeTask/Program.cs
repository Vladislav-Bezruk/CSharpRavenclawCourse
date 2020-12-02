using System;

namespace RavenclawFirstAdditionalPracticeTask
{
    class Program
    {
        static void PrintHex(int[] HexNum)
        {
            bool t = false;

            for (int i = 3; i >= 0; i--)
            {
                if (HexNum[i] > 0)
                    t = true;

                if (t == true)
                {
                    if (HexNum[i] < 10) Console.Write(HexNum[i]);
                    if (HexNum[i] == 10) Console.Write("A");
                    if (HexNum[i] == 11) Console.Write("B");
                    if (HexNum[i] == 12) Console.Write("C");
                    if (HexNum[i] == 13) Console.Write("D");
                    if (HexNum[i] == 14) Console.Write("E");
                    if (HexNum[i] == 15) Console.Write("F");
                }
            }
        }

        static int[] Conv(int Num, int System)
        {
            int[] HexNum = new int[4];
            int i = 0;

            while (Num > 0)
            {
                HexNum[i] = Num % System;
                Num /= System;
                i++;
            }

            return HexNum;
        }

        static int ConvDec(int[] Num, int System)
        {
            int NumDec = 0, s = 1;

            for (int i = 0; i < 4; i++)
            {
                NumDec += s * Num[i];
                s *= System;
            }

            return NumDec;
        }

        static int[] Sort(int[] Num)
        {
            int size = 0, min = 0, imin = 0;
            int[] NumS = new int[4];

            for (int i = 3; i >= 0; i--)
                if (Num[i] > 0)
                {
                    size = i;
                    break;
                }

            for (int j = 0; j <= size; j++)
            {
                min = 16;
                for (int i = size; i >= 0; i--)
                    if (Num[i] < min)
                    {
                        imin = i;
                        min = Num[i];
                    }
                Num[imin] = 17;
                NumS[j] = min;
            }
            return NumS;
        }

        static void Main(string[] args)
        {
            int Num;
            int[] HexNum = new int[4];
            bool r = false;

            Console.WriteLine("Enter the number:");
            Num = Convert.ToInt32(Console.ReadLine());
            HexNum = Conv(Num, 16);

            Console.Write("1) " + Num + " in Dec = ");
            PrintHex(HexNum);
            Console.Write(" in Hex");
            Console.WriteLine("");

            HexNum = Sort(HexNum);

            Console.Write("2) Sorted " + Num + " in Dec = ");
            PrintHex(HexNum);

            Console.Write(" in Hex");
            Console.WriteLine("");


            Console.Write("3) ");
            PrintHex(HexNum);

            Console.Write(" in Hex = " + ConvDec(HexNum, 16) + " in Dec");
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}