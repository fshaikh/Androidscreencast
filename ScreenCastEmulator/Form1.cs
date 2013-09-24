using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCastEmulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bool init = JavaInterop.Application.Init();
            if (!init)
            {
                MessageBox.Show("Unable to start ADB server");
                return;
            }
            System.Threading.Thread imageThread = new System.Threading.Thread(this.ThreadProc);
            imageThread.Name = "Image Thread: " + imageThread.ManagedThreadId.ToString();
            imageThread.Start();
        }

        private void ThreadProc(object obj)
        {
            JavaInterop.Application.AutoEvent.Wait();
            while (true)
            {

                var image = JavaInterop.ImageManager.GetScreenshot();
                pictureBox1.Image = image;
            }

        }
    }
}
