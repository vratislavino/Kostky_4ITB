using System.Diagnostics;

namespace Kostky_4ITB
{
    public partial class Form1 : Form
    {
        int diceCount = 6;
        List<Dice> dices = new List<Dice>();

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            Dice dice;
            for (int i = 0; i < diceCount; i++) {
                dice = new Dice();
                dices.Add(dice);
                flowLayoutPanel1.Controls.Add(dice);
                dice.RollEnded += OnRollEnded;
            }
        }

        private void OnRollEnded(Dice dice) {

            if (dices.Any(d => d.AAA_IsAnimationRunning)) return;
            
            Debug.WriteLine(string.Join(", ", dices.Select(d => d.CurrentNumber)));
        }

        private void button1_Click(object sender, EventArgs e) {
            dices.ForEach(dice => dice.Roll());
        }
    }
}