using System;
using System.Drawing;
using System.Windows.Forms;


namespace WinFormsApp13
{
    public partial class Form1 : Form
    {
        private int clickCount = 0;
        private int maxClicks = 0;
        private int timeLeft = 20;
        private Timer gameTimer;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {

            gameTimer = new Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += OnGameTimerTick;

            
            button1.Text = "׸ ������, �����";
            button1.Click += OnButtonClick;

            
            gameTimer.Start();
        }

        private void OnGameTimerTick(object sender, EventArgs e)
        {
            timeLeft--;

            if (timeLeft <= 0)
            {
                gameTimer.Stop();
                ShowResult();
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            clickCount++;

            if (clickCount > maxClicks)
            {
                maxClicks = clickCount;
            }

            
            button1.Text = $"������: {clickCount}";
        }

        private void ShowResult()
        {
            string message = $"�� ��, �� ������ {clickCount} ������.\n������������ ������: {maxClicks}";
            MessageBox.Show(message, "���������", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            clickCount = 0;
            timeLeft = 20;
            button1.Text = "����� �� ����";
            gameTimer.Start();
        }

    }
}
