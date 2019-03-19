using NTPServerApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        System.Timers.Timer m_timer = new System.Timers.Timer();
        NTPC ntpc;
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            Task.Run(() =>
            {
                ntpc = new NTPC();
                if (ntpc.Get() == false)
                {
                    label1.ForeColor = Color.Red;
                }
                else
                {
                    label1.ForeColor = Color.Green;

                }
            });

            m_timer.Elapsed += M_timer_Elapsed;
            m_timer.Interval = 1;
            m_timer.Enabled = true;
        }

        private void M_timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime d = DateTime.Now;
            label1.Text = d.Hour.ToString("00") + ":" + d.Minute.ToString("00") + ":" + d.Second.ToString("00") + "." + d.Millisecond;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                ntpc = new NTPC(comboBox1.Text);
                if (ntpc.Get() == false)
                {
                    label1.ForeColor = Color.Red;
                }
                else
                {
                    label1.ForeColor = Color.Green;

                }
            });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_timer.Enabled = false;
        }
    }
}
