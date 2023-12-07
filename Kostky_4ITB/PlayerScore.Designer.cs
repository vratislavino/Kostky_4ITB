namespace Kostky_4ITB
{
    partial class PlayerScore
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent() {
            label1 = new Label();
            pictureBox1 = new PictureBox();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize) pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(-1, 0);
            label1.Name = "label1";
            label1.Size = new Size(252, 46);
            label1.TabIndex = 0;
            label1.Text = "Karel";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Location = new Point(-1, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(252, 10);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.Enabled = false;
            richTextBox1.Location = new Point(3, 65);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.RightToLeft = RightToLeft.Yes;
            richTextBox1.Size = new Size(244, 546);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // PlayerScore
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(richTextBox1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "PlayerScore";
            Size = new Size(250, 614);
            ((System.ComponentModel.ISupportInitialize) pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private RichTextBox richTextBox1;
    }
}
