using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace WinFormsApp12
{
    public partial class Form1 : Form
    {
        private Color[] colors = { Color.Red, Color.Yellow, Color.Green, Color.Cyan, Color.Blue, Color.Pink, Color.White, Color.Black };
        private int currentColorIndex = 0;

        private System.Timers.Timer colorChangeTimer;

        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
            panel1.BackColor = colors[currentColorIndex];
        }

        private void InitializeTimer()
        {
            colorChangeTimer = new System.Timers.Timer();
            colorChangeTimer.Interval = 2000; 
            colorChangeTimer.Elapsed += OnColorChangeTimerElapsed;
            colorChangeTimer.Start();
        }

        private void OnColorChangeTimerElapsed(object sender, ElapsedEventArgs e)
        {
            ChangeBackgroundColor();
        }

        private void ChangeBackgroundColor()
        {
            if (currentColorIndex < colors.Length - 1)
            {
                currentColorIndex++;
            }
            else
            {
                currentColorIndex = 0;
            }

            Color nextColor = colors[currentColorIndex];

           
            if (InvokeRequired)
            {
                Invoke(new Action(() => { panel1.BackColor = nextColor; }));
            }
            else
            {
                panel1.BackColor = nextColor;
            }
        }
    }
}

