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
    public partial class PlayerScore : UserControl
    {
        public event Action<string> PlayerWon;

        int currentScore = 0;
        const int finalScore = 1000;

        public PlayerScore() {
            InitializeComponent();
        }

        public PlayerScore(string name) : this() {
            label1.Text = name;
        }

        public void AddScore(int score) {
            currentScore += score;
            richTextBox1.Text += currentScore + "\n";

            if (currentScore >= finalScore) {
                PlayerWon?.Invoke(label1.Text);
            }
        }

        public void SwitchPlayer(bool isPlaying) {
            BackColor = isPlaying ? Color.LightGreen : Color.White;
        }
    }
}
