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
                dice.Click += OnDiceClicked;
            }
        }

        private void OnDiceClicked(object? sender, EventArgs e) {
            Dice d = (Dice) sender;
            if (d.IsDeeplyLocked || d.IsAnimationRunning) return;

            d.IsLocked = !d.IsLocked;

            if (IsValidCombination(dices.Where(dice => dice.IsLocked && !dice.IsDeeplyLocked).ToList())) {
                button1.Enabled = true;
            } else {
                button1.Enabled = false;
            }
        }
        // 2,2,1,1 -> špatnì
        // 2,2,2 -> správnì
        // 6,6,6
        private bool IsValidCombination(List<Dice> dices) {
            if (dices.Count == 0) return false;

            int[] counts = new int[6];
            for (int i = 0; i < dices.Count; i++) {
                counts[dices[i].CurrentNumber - 1]++;
            }

            if (dices.Count == 6) {
                var countsList = counts.ToList();
                if (countsList.Count(c => c == 1) == 6) // postupka, všechny èísla jsou tam 1x
                    return true;
                if (countsList.Count(c => c == 2) == 3) // dvojice, 3x jsem našel dvojku
                    return true;
            }

            for (int i = 0; i < dices.Count; i++) {
                int num = dices[i].CurrentNumber;
                int index = num - 1;
                if (counts[index] >= 3) {
                    dices.RemoveAll(dice => dice.CurrentNumber == num);
                } else {
                    if (num == 1 || num == 5) {
                        dices.RemoveAll(dice => dice.CurrentNumber == num);
                    } else {
                        return false;
                    }
                }
            }

            return true;





        }

        private void OnRollEnded(Dice dice) {

            if (dices.Any(d => d.IsAnimationRunning)) return;

            Debug.WriteLine(string.Join(", ", dices.Select(d => d.CurrentNumber)));
        }

        private void button1_Click(object sender, EventArgs e) {
            if (dices.All(dice => dice.IsLocked)) {
                dices.ForEach(dice => {
                    dice.IsDeeplyLocked = false;
                    dice.IsLocked = false;
                });
            }

            button1.Enabled = false;
            dices.ForEach(dice => dice.Roll());
        }

        private void button2_Click(object sender, EventArgs e) {
            dices.ForEach(dice => dice.Roll());
        }
    }
}