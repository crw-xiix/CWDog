namespace CWDog
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tDit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStatic)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(567, 420);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lDit);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tDit);
            this.tabPage1.Controls.Add(this.lStatic);
            this.tabPage1.Controls.Add(this.lFreq);
            this.tabPage1.Controls.Add(this.lTone);
            this.tabPage1.Controls.Add(this.tTone);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tStatic);
            this.tabPage1.Controls.Add(this.bSend);
            this.tabPage1.Controls.Add(this.tSend);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(559, 394);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // lDit
            // 
            this.lDit.BackColor = System.Drawing.SystemColors.ControlText;
            this.lDit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lDit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDit.ForeColor = System.Drawing.Color.GreenYellow;
            this.lDit.Location = new System.Drawing.Point(474, 251);
            this.lDit.Name = "lDit";
            this.lDit.Size = new System.Drawing.Size(66, 42);
            this.lDit.TabIndex = 11;
            this.lDit.Text = "480";
            this.lDit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Dit Time (ms) 10-250";
            // 
            // tDit
            // 
            this.tDit.LargeChange = 50;
            this.tDit.Location = new System.Drawing.Point(51, 251);
            this.tDit.Maximum = 250;
            this.tDit.Minimum = 10;
            this.tDit.Name = "tDit";
            this.tDit.Size = new System.Drawing.Size(417, 42);
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
            this.lStatic.Location = new System.Drawing.Point(474, 129);
            this.lStatic.Name = "lStatic";
            this.lStatic.Size = new System.Drawing.Size(66, 42);
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
            this.lFreq.Location = new System.Drawing.Point(474, 190);
            this.lFreq.Name = "lFreq";
            this.lFreq.Size = new System.Drawing.Size(66, 42);
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
            this.tTone.Maximum = 1000;
            this.tTone.Minimum = 400;
            this.tTone.Name = "tTone";
            this.tTone.Size = new System.Drawing.Size(417, 42);
            this.tTone.SmallChange = 50;
            this.tTone.TabIndex = 5;
            this.tTone.TickFrequency = 20;
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
            this.tStatic.Size = new System.Drawing.Size(417, 42);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(559, 394);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 418);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tDit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tTone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStatic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tSend;
        private TButton bSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tStatic;
        private System.Windows.Forms.Label lTone;
        private System.Windows.Forms.TrackBar tTone;
        private System.Windows.Forms.Label lFreq;
        private System.Windows.Forms.Label lStatic;
        private System.Windows.Forms.Label lDit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar tDit;
    }
}

