namespace SortingAlgorithmVisualizer {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            comboBox1 = new ComboBox();
            buttonReset = new Button();
            panel1 = new Panel();
            buttonStart = new Button();
            buttonPause = new Button();
            output1 = new RichTextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(1924, 35);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(141, 34);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click +=  exitToolStripMenuItem_Click ;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(65, 29);
            helpToolStripMenuItem.Text = "Help";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 77);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(92, 25);
            label1.TabIndex = 1;
            label1.Text = "Algorithm";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(166, 72);
            comboBox1.Margin = new Padding(4, 5, 4, 5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(217, 33);
            comboBox1.TabIndex = 2;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(419, 70);
            buttonReset.Margin = new Padding(4, 5, 4, 5);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(107, 38);
            buttonReset.TabIndex = 3;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click +=  buttonReset_Click ;
            // 
            // panel1
            // 
            panel1.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right ;
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Location = new Point(29, 172);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1855, 861);
            panel1.TabIndex = 4;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(551, 70);
            buttonStart.Margin = new Padding(4, 5, 4, 5);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(107, 38);
            buttonStart.TabIndex = 5;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click +=  buttonStart_Click ;
            // 
            // buttonPause
            // 
            buttonPause.Location = new Point(713, 70);
            buttonPause.Margin = new Padding(4, 5, 4, 5);
            buttonPause.Name = "buttonPause";
            buttonPause.Size = new Size(257, 38);
            buttonPause.TabIndex = 6;
            buttonPause.Text = "Pause / Resume";
            buttonPause.UseVisualStyleBackColor = true;
            buttonPause.Click +=  buttonPause_Click ;
            // 
            // output1
            // 
            output1.BackColor = SystemColors.Control;
            output1.Location = new Point(1060, 63);
            output1.Name = "output1";
            output1.ReadOnly = true;
            output1.ScrollBars = RichTextBoxScrollBars.Vertical;
            output1.Size = new Size(304, 88);
            output1.TabIndex = 7;
            output1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1047);
            Controls.Add(output1);
            Controls.Add(buttonPause);
            Controls.Add(buttonStart);
            Controls.Add(panel1);
            Controls.Add(buttonReset);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Label label1;
        private ComboBox comboBox1;
        private Button buttonReset;
        private Panel panel1;
        private Button buttonStart;
        private Button buttonPause;
        private RichTextBox output1;
    }
}
