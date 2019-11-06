using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 多线程闹钟
{
    public partial class Form1 : Form
    {
        List<Thread> Threads;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            InitThread();
        }

        private void GetTime()
        {
            for(; ; ) 
            {
                label1.Text = DateTime.Now.ToLongTimeString().ToString();
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            Thread AlarmThread = new Thread(new ThreadStart(SetAlarm));
            AlarmThread.Start();
        }

        private void InitThread()
        {
            Thread TimeThread = new Thread(new ThreadStart(GetTime));
            TimeThread.Start();
            Threads = new List<Thread>();
        }

        private void SetAlarm()
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("请输入正确的时间！", "ERROR!");
                return;
            }
            int SetH = int.Parse(textBox1.Text);
            int SetM = int.Parse(textBox2.Text);

            listBox1.Items.Add("闹钟: " + SetH + ":" + SetM);

            for (; ; )
            {
                int HourNow = int.Parse(DateTime.Now.Hour.ToString());
                int MinNow = int.Parse(DateTime.Now.Minute.ToString());
                if (SetH == HourNow && SetM == MinNow)
                {
                    MessageBox.Show(DateTime.Now.ToShortTimeString().ToString(), "时间到了！");
                    break;
                }
            }
        }
    }
}
