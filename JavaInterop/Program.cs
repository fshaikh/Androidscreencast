using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using com.android.ddmlib;
using java.lang;

namespace JavaInterop
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Init();

            System.Threading.Thread imageThread = new System.Threading.Thread(ThreadProc);
            imageThread.Name = "Image Thread: " + imageThread.ManagedThreadId.ToString();
            imageThread.Start();
        }

        private static void ThreadProc(object obj)
        {
            Application.AutoEvent.Wait();
            while (true)
            {
                  
                ImageManager.SaveScreenshot();
            }

        }
    }
}
