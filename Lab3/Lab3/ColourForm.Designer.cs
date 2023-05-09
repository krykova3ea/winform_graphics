namespace Lab3
{
    partial class ColourForm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 340);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 73);
            this.button1.TabIndex = 0;
            this.button1.Text = "Смена цвета точки";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.PointColour_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(266, 340);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 73);
            this.button2.TabIndex = 1;
            this.button2.Text = "Смена цвета линии";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.LineColour_Click);
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Items.Add("AliceBlue");
            this.domainUpDown1.Items.Add("AntiqueWhite");
            this.domainUpDown1.Items.Add("Aqua");
            this.domainUpDown1.Items.Add("Aquamarine");
            this.domainUpDown1.Items.Add("Azure");
            this.domainUpDown1.Items.Add("Beige");
            this.domainUpDown1.Items.Add("Bisque");
            this.domainUpDown1.Items.Add("Black");
            this.domainUpDown1.Items.Add("BlanchedAlmond");
            this.domainUpDown1.Items.Add("Blue");
            this.domainUpDown1.Items.Add("BlueViolet");
            this.domainUpDown1.Items.Add("Brown");
            this.domainUpDown1.Items.Add("BurlyWood");
            this.domainUpDown1.Items.Add("CadetBlue");
            this.domainUpDown1.Items.Add("Chartreuse");
            this.domainUpDown1.Items.Add("Chocolate");
            this.domainUpDown1.Items.Add("Coral");
            this.domainUpDown1.Items.Add("CornflowerBlue");
            this.domainUpDown1.Items.Add("Cornsilk");
            this.domainUpDown1.Items.Add("Crimson");
            this.domainUpDown1.Items.Add("Cyan");
            this.domainUpDown1.Items.Add("DarkBlue");
            this.domainUpDown1.Items.Add("DarkCyan");
            this.domainUpDown1.Items.Add("DarkGoldenrod");
            this.domainUpDown1.Items.Add("DarkGray");
            this.domainUpDown1.Items.Add("DarkGreen");
            this.domainUpDown1.Items.Add("DarkKhaki");
            this.domainUpDown1.Items.Add("DarkMagenta");
            this.domainUpDown1.Items.Add("DarkOliveGreen");
            this.domainUpDown1.Items.Add("DarkOrange");
            this.domainUpDown1.Items.Add("DarkOrchid");
            this.domainUpDown1.Items.Add("DarkRed");
            this.domainUpDown1.Items.Add("DarkSalmon");
            this.domainUpDown1.Items.Add("DarkSeaGreen");
            this.domainUpDown1.Items.Add("DarkSlateBlue");
            this.domainUpDown1.Items.Add("DarkSlateGray");
            this.domainUpDown1.Items.Add("DarkTurquoise");
            this.domainUpDown1.Items.Add("DarkViolet");
            this.domainUpDown1.Items.Add("DeepPink");
            this.domainUpDown1.Items.Add("DeepSkyBlue");
            this.domainUpDown1.Location = new System.Drawing.Point(84, 188);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(271, 26);
            this.domainUpDown1.TabIndex = 2;
            this.domainUpDown1.Text = "Выбор цвета";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(266, 248);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 43);
            this.button3.TabIndex = 3;
            this.button3.Text = "Сброс";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ColourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 452);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.domainUpDown1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ColourForm";
            this.Text = "Смена цвета";
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.Button button3;
    }
}