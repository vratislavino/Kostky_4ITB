using System.Diagnostics;

namespace Kostky_4ITB
{
    public partial class Form1 : Form
    {
        int diceCount = 6;
        List<Dice> dices = new List<Dice>();
        List<PlayerScore> playerScores = new List<PlayerScore>();

        PlayerScore currentPlayer = null;

        int currentScore = 0;
        int currentlyLockedScore = 0;
        bool firstThrow = true;

        int CurrentScore {
            get { return currentScore; }
            set {
                currentScore = value;
                label1.Text = "Current score: " + currentScore;
            }
        }

        public Form1(List<string> players) {
            InitializeComponent();

            foreach (var player in players) {
                var playerScore = new PlayerScore(player);
                playerScores.Add(playerScore);
                flowLayoutPanel2.Controls.Add(playerScore);
            }
            flowLayoutPanel2.Width = (playerScores.First().Width + 8) * players.Count;
            flowLayoutPanel2.Location = new Point(
                this.Width - 40 - flowLayoutPanel2.Width,
                flowLayoutPanel2.Location.Y);
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
            dices.ForEach(dice => {
                dice.IsLocked = true;
                dice.IsDeeplyLocked = true;
            });
            NextPlayer();
        }

        private void NextPlayer() {
            if (currentPlayer == null) {
                currentPlayer = playerScores.First();
                currentPlayer.SwitchPlayer(true);
            } else {
                currentPlayer.SwitchPlayer(false);
                currentPlayer = playerScores[(playerScores.IndexOf(currentPlayer) + 1) % playerScores.Count];
                currentPlayer.SwitchPlayer(true);
            }
            button1.Enabled = true;
            CurrentScore = 0;
            currentlyLockedScore = 0;
            button3.Enabled = false;
            firstThrow = true;
        }

        private void OnDiceClicked(object? sender, EventArgs e) {
            Dice d = (Dice) sender;
            if (d.IsDeeplyLocked || d.IsAnimationRunning) return;

            d.IsLocked = !d.IsLocked;

            if (IsValidCombination(dices.Where(dice => dice.IsLocked && !dice.IsDeeplyLocked).ToList(), true)) {
                button1.Enabled = true;
                currentlyLockedScore = CalculateLockedScore(dices.Where(dice => dice.IsLocked && !dice.IsDeeplyLocked).ToList());

                int tempScore = currentScore + currentlyLockedScore;
                button3.Enabled = tempScore >= 350;

                label1.Text = "Current score: " + tempScore;
            } else {
                button1.Enabled = false;
                currentlyLockedScore = 0;
                label1.Text = "Current score: " + currentScore;
            }
        }

        private int CalculateLockedScore(List<Dice> dices) {
            if (dices.Count == 0) return 0;

            int[] counts = new int[6];
            for (int i = 0; i < dices.Count; i++) {
                counts[dices[i].CurrentNumber - 1]++;
            }

            if (dices.Count == 6) {
                var countsList = counts.ToList();
                if (countsList.Count(c => c == 1) == 6) // postupka, všechny èísla jsou tam 1x
                    return 2000;
                if (countsList.Count(c => c == 2) == 3) // dvojice, 3x jsem našel dvojku
                    return 1000;
            }

            int score = 0;

            for (; dices.Count > 0;) {
                int num = dices[0].CurrentNumber;
                int index = num - 1;
                if (counts[index] >= 3) {
                    score += GetScore(num, counts[index]);
                    dices.RemoveAll(dice => dice.CurrentNumber == num);
                } else {
                    if (num == 1) {
                        score += 100 * counts[index];
                    } else if (num == 5) {
                        score += 50 * counts[index];
                    }
                    dices.RemoveAll(dice => dice.CurrentNumber == num);
                }
            }
            return score;
        }

        private int GetScore(int number, int count) {
            if (number == 1) number *= 10;
            number *= 100;
            count -= 3;
            for (int i = 0; i < count; i++) {
                number *= 2;
            }
            return number;
        }

        private bool IsValidCombination(List<Dice> dices, bool checkAll) {
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

            bool foundSome = false;

            for (int i = 0; i < dices.Count; i++) {
                int num = dices[i].CurrentNumber;
                int index = num - 1;
                if (counts[index] >= 3) {
                    dices.RemoveAll(dice => dice.CurrentNumber == num);
                    foundSome = true;
                } else {
                    if (num == 1 || num == 5) {
                        dices.RemoveAll(dice => dice.CurrentNumber == num);
                        foundSome = true;
                    } else {
                        if (checkAll)
                            return false;
                    }
                }
            }

            if (checkAll && dices.Count == 0)
                return true;

            // ?? odebral jsem všechny validní kombinace
            return foundSome;
        }

        private void OnRollEnded(Dice dice) {

            if (dices.Any(d => d.IsAnimationRunning)) return;

            if (!IsValidCombination(dices.Where(d => !d.IsLocked).ToList(), false)) {
                dices.ForEach(x => x.IsDeeplyLocked = true);
                NextPlayer();
            }

            Debug.WriteLine(string.Join(", ", dices.Select(d => d.CurrentNumber)));
        }

        private void button1_Click(object sender, EventArgs e) {
            if(firstThrow) {
                firstThrow = false;
                dices.ForEach(dice => {
                    dice.IsDeeplyLocked = false;
                    dice.IsLocked = false;
                });
            }

            if (dices.All(dice => dice.IsLocked)) {
                dices.ForEach(dice => {
                    dice.IsDeeplyLocked = false;
                    dice.IsLocked = false;
                });
            }

            CurrentScore += currentlyLockedScore;
            currentlyLockedScore = 0;

            button1.Enabled = false;
            dices.ForEach(dice => dice.Roll());
        }

        private void button2_Click(object sender, EventArgs e) {
            dices.ForEach(dice => dice.Roll());
        }

        private void button3_Click(object sender, EventArgs e) {
            dices.ForEach(dice => {
                dice.IsDeeplyLocked = true;
                dice.IsLocked = true;
            });
            currentScore += currentlyLockedScore;
            currentPlayer.AddScore(currentScore);
            NextPlayer();
        }
    }
}