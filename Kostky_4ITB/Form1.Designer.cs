namespace Kostky_4ITB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            flowLayoutPanel1 = new FlowLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button3 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Black;
            flowLayoutPanel1.Location = new Point(49, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(4);
            flowLayoutPanel1.Size = new Size(1244, 216);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(12, 282);
            button1.Name = "button1";
            button1.Size = new Size(216, 206);
            button1.TabIndex = 1;
            button1.Text = "Roll";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1154, 239);
            button2.Name = "button2";
            button2.Size = new Size(139, 37);
            button2.TabIndex = 2;
            button2.Text = "Roll Anyway";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.White;
            flowLayoutPanel2.Location = new Point(344, 282);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(998, 570);
            flowLayoutPanel2.TabIndex = 3;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(12, 494);
            button3.Name = "button3";
            button3.Size = new Size(216, 77);
            button3.TabIndex = 4;
            button3.Text = "Keep score";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 239);
            label1.Name = "label1";
            label1.Size = new Size(244, 45);
            label1.TabIndex = 0;
            label1.Text = "Current score: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1354, 864);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(flowLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button button1;
        private Button button2;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button3;
        private Label label1;
    }
}