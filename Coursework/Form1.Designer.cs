namespace Coursework
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.stopBtn = new System.Windows.Forms.Button();
            this.stepBtn = new System.Windows.Forms.Button();
            this.timeTB = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.vectorsBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTB)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(12, 12);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(788, 474);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.Click += new System.EventHandler(this.picDisplay_Click);
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(830, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Debug";
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(830, 145);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(94, 44);
            this.stopBtn.TabIndex = 2;
            this.stopBtn.Text = "Стоп/старт";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // stepBtn
            // 
            this.stepBtn.Location = new System.Drawing.Point(830, 195);
            this.stepBtn.Name = "stepBtn";
            this.stepBtn.Size = new System.Drawing.Size(94, 38);
            this.stepBtn.TabIndex = 3;
            this.stepBtn.Text = "Шаг";
            this.stepBtn.UseVisualStyleBackColor = true;
            this.stepBtn.Click += new System.EventHandler(this.stepBtn_Click);
            // 
            // timeTB
            // 
            this.timeTB.Location = new System.Drawing.Point(815, 303);
            this.timeTB.Maximum = 1000;
            this.timeTB.Minimum = 40;
            this.timeTB.Name = "timeTB";
            this.timeTB.Size = new System.Drawing.Size(130, 56);
            this.timeTB.TabIndex = 4;
            this.timeTB.Value = 40;
            this.timeTB.Scroll += new System.EventHandler(this.timeTB_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(815, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 40);
            this.label2.TabIndex = 5;
            this.label2.Text = "Замедление\r\nвремени";
            // 
            // vectorsBtn
            // 
            this.vectorsBtn.Location = new System.Drawing.Point(830, 365);
            this.vectorsBtn.Name = "vectorsBtn";
            this.vectorsBtn.Size = new System.Drawing.Size(94, 43);
            this.vectorsBtn.TabIndex = 6;
            this.vectorsBtn.Text = "Вектора";
            this.vectorsBtn.UseVisualStyleBackColor = true;
            this.vectorsBtn.Click += new System.EventHandler(this.vectorsBtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 638);
            this.Controls.Add(this.vectorsBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timeTB);
            this.Controls.Add(this.stepBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.Text = "Система частиц";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button stepBtn;
        private System.Windows.Forms.TrackBar timeTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button vectorsBtn;
    }
}

