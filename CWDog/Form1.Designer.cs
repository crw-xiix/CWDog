namespace CWDog
{
    partial class FormCW
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Main = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.tUpper = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.tLower = new System.Windows.Forms.TrackBar();
            this.bEmpty = new CWDog.TButton();
            this.bTone = new CWDog.TButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lLeft = new System.Windows.Forms.Label();
            this.bClose = new CWDog.TButton();
            this.lDit = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tDit = new System.Windows.Forms.TrackBar();
            this.lStatic = new System.Windows.Forms.Label();
            this.lFreq = new System.Windows.Forms.Label();
            this.lTone = new System.Windows.Forms.Label();
            this.tTone = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tStatic = new System.Windows.Forms.TrackBar();
            this.bSend = new CWDog.TButton();
            this.tSend = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tUpper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tDit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStatic)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Main);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(-1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(764, 560);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tabControl1_KeyPress);
            // 
            // Main
            // 
            this.Main.Controls.Add(this.label5);
            this.Main.Controls.Add(this.tUpper);
            this.Main.Controls.Add(this.label4);
            this.Main.Controls.Add(this.tLower);
            this.Main.Controls.Add(this.bEmpty);
            this.Main.Controls.Add(this.bTone);
            this.Main.Controls.Add(this.textBox1);
            this.Main.Controls.Add(this.lLeft);
            this.Main.Controls.Add(this.bClose);
            this.Main.Controls.Add(this.lDit);
            this.Main.Controls.Add(this.label3);
            this.Main.Controls.Add(this.tDit);
            this.Main.Controls.Add(this.lStatic);
            this.Main.Controls.Add(this.lFreq);
            this.Main.Controls.Add(this.lTone);
            this.Main.Controls.Add(this.tTone);
            this.Main.Controls.Add(this.label1);
            this.Main.Controls.Add(this.tStatic);
            this.Main.Controls.Add(this.bSend);
            this.Main.Controls.Add(this.tSend);
            this.Main.Location = new System.Drawing.Point(4, 22);
            this.Main.Name = "Main";
            this.Main.Padding = new System.Windows.Forms.Padding(3);
            this.Main.Size = new System.Drawing.Size(756, 534);
            this.Main.TabIndex = 0;
            this.Main.Text = "Main";
            this.Main.UseVisualStyleBackColor = true;
            this.Main.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Tone Frequency (400-1000 Hz)";
            // 
            // tUpper
            // 
            this.tUpper.LargeChange = 50;
            this.tUpper.Location = new System.Drawing.Point(51, 298);
            this.tUpper.Maximum = 4000;
            this.tUpper.Minimum = 40;
            this.tUpper.Name = "tUpper";
            this.tUpper.Size = new System.Drawing.Size(584, 42);
            this.tUpper.SmallChange = 50;
            this.tUpper.TabIndex = 19;
            this.tUpper.TickFrequency = 50;
            this.tUpper.Value = 400;
            this.tUpper.Scroll += new System.EventHandler(this.tUpper_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Tone Frequency (400-1000 Hz)";
            // 
            // tLower
            // 
            this.tLower.LargeChange = 50;
            this.tLower.Location = new System.Drawing.Point(51, 250);
            this.tLower.Maximum = 4000;
            this.tLower.Minimum = 40;
            this.tLower.Name = "tLower";
            this.tLower.Size = new System.Drawing.Size(584, 42);
            this.tLower.SmallChange = 50;
            this.tLower.TabIndex = 17;
            this.tLower.TickFrequency = 50;
            this.tLower.Value = 400;
            this.tLower.Scroll += new System.EventHandler(this.tLower_Scroll);
            // 
            // bEmpty
            // 
            this.bEmpty.BorderColor = System.Drawing.Color.Black;
            this.bEmpty.BorderWidth = 0;
            this.bEmpty.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bEmpty.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEmpty.Location = new System.Drawing.Point(128, 6);
            this.bEmpty.Name = "bEmpty";
            this.bEmpty.Radius = -1;
            this.bEmpty.Size = new System.Drawing.Size(75, 39);
            this.bEmpty.TabIndex = 16;
            this.bEmpty.Text = "Empty";
            this.bEmpty.UseVisualStyleBackColor = true;
            this.bEmpty.Click += new System.EventHandler(this.bEmpty_Click);
            // 
            // bTone
            // 
            this.bTone.BorderColor = System.Drawing.Color.Black;
            this.bTone.BorderWidth = 0;
            this.bTone.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bTone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bTone.Location = new System.Drawing.Point(51, 6);
            this.bTone.Name = "bTone";
            this.bTone.Radius = -1;
            this.bTone.Size = new System.Drawing.Size(75, 39);
            this.bTone.TabIndex = 15;
            this.bTone.Text = "Solid Tone";
            this.bTone.UseVisualStyleBackColor = true;
            this.bTone.Click += new System.EventHandler(this.bTone_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 436);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 14;
            // 
            // lLeft
            // 
            this.lLeft.AutoSize = true;
            this.lLeft.Location = new System.Drawing.Point(600, 45);
            this.lLeft.Name = "lLeft";
            this.lLeft.Size = new System.Drawing.Size(35, 13);
            this.lLeft.TabIndex = 13;
            this.lLeft.Text = "label2";
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.Tomato;
            this.bClose.BorderColor = System.Drawing.Color.Black;
            this.bClose.BorderWidth = 0;
            this.bClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bClose.Location = new System.Drawing.Point(435, 475);
            this.bClose.Name = "bClose";
            this.bClose.Radius = -1;
            this.bClose.Size = new System.Drawing.Size(118, 37);
            this.bClose.TabIndex = 12;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // lDit
            // 
            this.lDit.BackColor = System.Drawing.SystemColors.ControlText;
            this.lDit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lDit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDit.ForeColor = System.Drawing.Color.GreenYellow;
            this.lDit.Location = new System.Drawing.Point(660, 375);
            this.lDit.Name = "lDit";
            this.lDit.Size = new System.Drawing.Size(88, 42);
            this.lDit.TabIndex = 11;
            this.lDit.Text = "480";
            this.lDit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Dit Time (ms) 10-250";
            // 
            // tDit
            // 
            this.tDit.LargeChange = 50;
            this.tDit.Location = new System.Drawing.Point(51, 375);
            this.tDit.Maximum = 250;
            this.tDit.Minimum = 10;
            this.tDit.Name = "tDit";
            this.tDit.Size = new System.Drawing.Size(584, 42);
            this.tDit.SmallChange = 50;
            this.tDit.TabIndex = 9;
            this.tDit.TickFrequency = 20;
            this.tDit.Value = 250;
            this.tDit.Scroll += new System.EventHandler(this.tDit_Scroll);
            // 
            // lStatic
            // 
            this.lStatic.BackColor = System.Drawing.SystemColors.ControlText;
            this.lStatic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lStatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lStatic.ForeColor = System.Drawing.Color.GreenYellow;
            this.lStatic.Location = new System.Drawing.Point(660, 129);
            this.lStatic.Name = "lStatic";
            this.lStatic.Size = new System.Drawing.Size(88, 42);
            this.lStatic.TabIndex = 8;
            this.lStatic.Text = "480";
            this.lStatic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lFreq
            // 
            this.lFreq.BackColor = System.Drawing.SystemColors.ControlText;
            this.lFreq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFreq.ForeColor = System.Drawing.Color.GreenYellow;
            this.lFreq.Location = new System.Drawing.Point(660, 190);
            this.lFreq.Name = "lFreq";
            this.lFreq.Size = new System.Drawing.Size(88, 42);
            this.lFreq.TabIndex = 7;
            this.lFreq.Text = "480";
            this.lFreq.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTone
            // 
            this.lTone.AutoSize = true;
            this.lTone.Location = new System.Drawing.Point(48, 174);
            this.lTone.Name = "lTone";
            this.lTone.Size = new System.Drawing.Size(155, 13);
            this.lTone.TabIndex = 6;
            this.lTone.Text = "Tone Frequency (400-1000 Hz)";
            // 
            // tTone
            // 
            this.tTone.LargeChange = 50;
            this.tTone.Location = new System.Drawing.Point(51, 190);
            this.tTone.Maximum = 4000;
            this.tTone.Minimum = 40;
            this.tTone.Name = "tTone";
            this.tTone.Size = new System.Drawing.Size(584, 42);
            this.tTone.SmallChange = 50;
            this.tTone.TabIndex = 5;
            this.tTone.TickFrequency = 50;
            this.tTone.Value = 400;
            this.tTone.Scroll += new System.EventHandler(this.tTone_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Static Level";
            // 
            // tStatic
            // 
            this.tStatic.Location = new System.Drawing.Point(51, 129);
            this.tStatic.Maximum = 100;
            this.tStatic.Name = "tStatic";
            this.tStatic.Size = new System.Drawing.Size(584, 42);
            this.tStatic.TabIndex = 3;
            this.tStatic.Scroll += new System.EventHandler(this.tStatic_Scroll);
            // 
            // bSend
            // 
            this.bSend.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.bSend.BorderColor = System.Drawing.Color.Black;
            this.bSend.BorderWidth = 0;
            this.bSend.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSend.Location = new System.Drawing.Point(369, 58);
            this.bSend.Name = "bSend";
            this.bSend.Radius = -1;
            this.bSend.Size = new System.Drawing.Size(110, 38);
            this.bSend.TabIndex = 2;
            this.bSend.Text = "Translate";
            this.bSend.UseVisualStyleBackColor = false;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // tSend
            // 
            this.tSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSend.Location = new System.Drawing.Point(51, 65);
            this.tSend.Name = "tSend";
            this.tSend.Size = new System.Drawing.Size(312, 22);
            this.tSend.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(756, 534);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Straight Key";
            this.tabPage2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPage2_MouseDown);
            this.tabPage2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabPage2_MouseUp);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(10, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(196, 316);
            this.listBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Left mouse down to depress key anywhere in this area.";
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(756, 534);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Iambic";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // FormCW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 558);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Name = "FormCW";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown_1);
            this.tabControl1.ResumeLayout(false);
            this.Main.ResumeLayout(false);
            this.Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tUpper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tDit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStatic)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage Main;
        private TButton bClose;
        private System.Windows.Forms.Label lDit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar tDit;
        private System.Windows.Forms.Label lStatic;
        private System.Windows.Forms.Label lFreq;
        private System.Windows.Forms.Label lTone;
        private System.Windows.Forms.TrackBar tTone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tStatic;
        private TButton bSend;
        private System.Windows.Forms.TextBox tSend;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lLeft;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ListBox listBox1;
        private TButton bEmpty;
        private TButton bTone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar tUpper;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tLower;
      
    }
}

