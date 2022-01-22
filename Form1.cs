using KAutoHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool
{
    public partial class Form1 : Form
    {
        private Point[] points;
        private NumericUpDown[] numericUpDowns;
        private Thread thread;
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            thread = new Thread(Tracker);
            thread.Start();
            points = new Point[10];
            numericUpDowns = new NumericUpDown[] { numericUpDown0, numericUpDown1, numericUpDown2, numericUpDown3,
                   numericUpDown4, numericUpDown5, numericUpDown6, numericUpDown7, numericUpDown8, numericUpDown9};
        }

        private void Tracker()
        {
            while (true)
            {
                pX.Text = $"({MousePosition.X},{MousePosition.Y})";
            }
        }

        private void choose(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D0:
                    label0.Text = $"({MousePosition.X},{MousePosition.Y})";
                    points[0] = new Point(MousePosition.X, MousePosition.Y);
                    break;
                case Keys.D1:
                    label1.Text = $"({MousePosition.X},{MousePosition.Y})";
                    points[1] = new Point(MousePosition.X, MousePosition.Y);
                    break;
                case Keys.D2:
                    label2.Text = $"({MousePosition.X},{MousePosition.Y})";
                    points[2] = new Point(MousePosition.X, MousePosition.Y);
                    break;
                case Keys.D3:
                    label3.Text = $"({MousePosition.X},{MousePosition.Y})";
                    points[3] = new Point(MousePosition.X, MousePosition.Y);
                    break;
                case Keys.D4:
                    label4.Text = $"({MousePosition.X},{MousePosition.Y})";
                    points[4] = new Point(MousePosition.X, MousePosition.Y);
                    break;
                case Keys.D5:
                    label5.Text = $"({MousePosition.X},{MousePosition.Y})";
                    points[5] = new Point(MousePosition.X, MousePosition.Y);
                    break;
                case Keys.D6:
                    label6.Text = $"({MousePosition.X},{MousePosition.Y})";
                    points[6] = new Point(MousePosition.X, MousePosition.Y);
                    break;
                case Keys.D7:
                    label7.Text = $"({MousePosition.X},{MousePosition.Y})";
                    points[7] = new Point(MousePosition.X, MousePosition.Y);
                    break;
                case Keys.D8:
                    label8.Text = $"({MousePosition.X},{MousePosition.Y})";
                    points[8] = new Point(MousePosition.X, MousePosition.Y);
                    break;
                case Keys.D9:
                    label9.Text = $"({MousePosition.X},{MousePosition.Y})";
                    points[9] = new Point(MousePosition.X, MousePosition.Y);
                    break;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            thread.Abort();
            thread = new Thread(RunTool);
            thread.Start();
        }

        private void RunTool()
        {
            for (int currentPoint = 0; currentPoint < 10; currentPoint++)
            {
                if (points[currentPoint] != null && numericUpDowns[currentPoint].Value > 0)
                {
                    EMouseKey mouseKey = EMouseKey.LEFT;
                    AutoControl.MouseClick(points[currentPoint], mouseKey);
                    Thread.Sleep(20000);
                    wheelMouse(Convert.ToInt32(numericUpDowns[currentPoint].Value));
                }
            }
            AutoControl.SendMultiKeysFocus(new KeyCode[] { KeyCode.CONTROL, KeyCode.KEY_W });
            pX.Text = " Done!";
        }

        private void wheelMouse(int minute)
        {
            int cycle = minute * 10 + 1;
            for(int i = 0; i < 1*cycle/5; i++)
            {
                AutoControl.MouseScroll(new Point(800, 400), -200, true);
                Thread.Sleep(6000);
            }
            for (int i = 0; i < 4*cycle / 5; i++)
            {
                AutoControl.MouseScroll(new Point(800, 400), 200);
                Thread.Sleep(6000);
            }
        }

        private void btnIntro_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "B1: Đưa con trỏ chuột vào tài liệu cần xem"
                + System.Environment.NewLine
                + "     Đánh dấu tài liệu bằng cách bấm từ 0-9"
                + System.Environment.NewLine
                +"    (không cần chọn đủ 10)"
                + System.Environment.NewLine
                + System.Environment.NewLine
                +"B2: Cài đặt thời gian tương ứng"
                + System.Environment.NewLine
                + System.Environment.NewLine
                + "B3: Bấm start =))"
                + System.Environment.NewLine
                + System.Environment.NewLine
                + "Lưu ý: Chọn xong tài liệu mới cài time!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thread.Abort();
            thread = null;
            this.Close();
        }
    }
}
