using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_CSharp_pt2
{
    public class LibImport
    {
        [DllImport("FirstDLL.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = false, EntryPoint = "Sum")]
        public static extern  int Sum1(int a, int b);
        public int Sum(int a, int b)
        {
            return Sum1(a, b);
        }

        [DllImport(@"C:\Users\asus\Desktop\pt2\FirstDLL\Debug\FirstDLL.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = false, EntryPoint = "Subtract")]
        public static extern int Sub1(int a, int b);
        public int Sub(int a, int b)
        {
            return Sub1(a, b);
        }

        [DllImport(@"C:\Users\asus\Desktop\pt2\FirstDLL\Debug\FirstDLL.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = false, EntryPoint = "Multi")]
        public static extern int Mult1(int a, int b);
        public int Mult(int a, int b)
        {
            return Mult1(a, b);
        }

        [DllImport(@"C:\Users\asus\Desktop\pt2\FirstDLL\Debug\FirstDLL.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = false, EntryPoint = "Div")]
        public static extern float Div1(int a, int b);
        public float Div(int a, int b)
        {
            return Div1(a, b);
        }

        [DllImport(@"C:\Users\asus\Desktop\pt2\FirstDLL\Debug\FirstDLL.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = false, EntryPoint = "Power")]
        public static extern int Power1(int a, int b);
        public int Power(int a, int b)
        {
            return Power1(a, b);
        }




    }
    class Program
    {
        public static void InputControl(out int a, out int b)
        {
            while (!int.TryParse(Console.ReadLine(),out a) || !int.TryParse(Console.ReadLine(), out b))
            {
                Console.Write("Input a number : ");
            }
        }
        static void Main()
        {
            LibImport import = new LibImport();


            while (true)
            {
                Console.Clear();

                Console.WriteLine("Input 2 numbers(separate with Enter) : ");
                InputControl(out int a, out int b);



                Console.WriteLine("Choose the operation : \n1 - Sum\n2 - Subtraction\n3 - Miltiplication\n4 - Power\n5 - Division\n6 - Exit");
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.D1: Console.Clear(); Console.WriteLine("a + b = " + import.Sum(a, b)); break;
                    case ConsoleKey.D2: Console.Clear(); Console.WriteLine("a - b = " + import.Sub(a, b)); break;
                    case ConsoleKey.D3: Console.Clear(); Console.WriteLine("a * b = " + import.Mult(a, b)); break;
                    case ConsoleKey.D4: Console.Clear(); Console.WriteLine("a ^ b = " + import.Power(a, b)); break;
                    case ConsoleKey.D5: Console.Clear(); Console.WriteLine("a / b = " + import.Div(a, b)); break;
                    case ConsoleKey.D6: return;
                }
                Console.ReadKey();
                continue;
            }
        }
    }
}
