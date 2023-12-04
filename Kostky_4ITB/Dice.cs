using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kostky_4ITB
{
    public partial class Dice : UserControl
    {
        public event Action<Dice> RollEnded;
        public bool IsAnimationRunning => timer1.Enabled;

        private int currentNumber = 3;
        private static Random generator = new Random();
        private const int DOT_SIZE = 40;

        int fastIteration = 10;
        int slowIteration = 3;

        private bool isLocked;
        public bool IsLocked { 
            get { return isLocked; } 
            set { 
                isLocked = value;
                BackColor = isLocked ? Color.LightGreen : Color.White;
            }
        }

        private bool isDeeplyLocked;
        public bool IsDeeplyLocked {
            get { return isDeeplyLocked; }
            set {
                isDeeplyLocked = value;
                BackColor = isDeeplyLocked ? Color.PaleVioletRed : Color.White;
            }
        }

        public int CurrentNumber {
            get { return currentNumber; }
            private set {
                currentNumber = value;
                Refresh();
            }
        }

        public Dice() {
            InitializeComponent();
        }

        public void Roll() {
            if(IsLocked) {
                IsDeeplyLocked = true;
            }

            if (IsLocked || IsDeeplyLocked)
                return;

            timer1.Interval = 50;
            fastIteration = generator.Next(7,13);
            slowIteration = generator.Next(2, 5);
            timer1.Start();
        }

        private void Dice_Paint(object sender, PaintEventArgs e) {

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (currentNumber % 2 == 1) {
                DrawDot(e.Graphics, Width / 2, Height / 2);
            }
            if (currentNumber > 1) {
                DrawDot(e.Graphics, Width / 5, Height / 5);
                DrawDot(e.Graphics, Width - Width / 5, Height - Height / 5);
            }
            if (currentNumber > 3) {
                DrawDot(e.Graphics, Width / 5, Height - Height / 5);
                DrawDot(e.Graphics, Width - Width / 5, Height / 5);
            }
            if (currentNumber == 6) {
                DrawDot(e.Graphics, Width / 5, Height / 2);
                DrawDot(e.Graphics, Width - Width / 5, Height / 2);
            }
        }

        private void DrawDot(Graphics g, int x, int y) {
            g.FillEllipse(Brushes.Black, x - DOT_SIZE / 2, y - DOT_SIZE / 2, DOT_SIZE, DOT_SIZE);
        }

        private void GenerateNumber() {
            CurrentNumber = generator.Next(1, 7);
        }

        private void timer1_Tick(object sender, EventArgs e) {
            GenerateNumber();
            fastIteration--;
            if(fastIteration == 0) {
                timer1.Interval = 200;
                return;
            }
            slowIteration--;
            if(slowIteration == 0) {
                timer1.Stop();
                RollEnded?.Invoke(this);
            }
        }
    }
}
