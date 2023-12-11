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
    public partial class Menu : Form
    {
        List<TextBox> textboxes = new List<TextBox>();

        public Menu() {
            InitializeComponent();
            foreach(var ctrl in this.Controls) {
                if(ctrl is TextBox)
                    textboxes.Add((TextBox)ctrl);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            List<string> names;
            names = textboxes.Select(x => x.Text).ToList();
            names.RemoveAll((n) => { return string.IsNullOrWhiteSpace(n); }); 

            if(names.Count < 2) {
                MessageBox.Show("Potřebuješ kamarády!", "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var game = new Form1(names);

            game.FormClosing += (obj, evt) => {
                this.Show();
            };

            this.Hide();
            game.Show();
        }

        private void button2_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
