namespace CatchGame
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
            this.components = new System.ComponentModel.Container();
            this.gameLoop = new System.Windows.Forms.Timer(this.components);
            this.titleLabel = new System.Windows.Forms.Label();
            this.subTitlelabel = new System.Windows.Forms.Label();
            this.hero2Points = new System.Windows.Forms.Label();
            this.hero1Points = new System.Windows.Forms.Label();
            this.winLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameLoop
            // 
            this.gameLoop.Enabled = true;
            this.gameLoop.Interval = 60;
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.titleLabel.Location = new System.Drawing.Point(140, 67);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(130, 31);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title label";
            // 
            // subTitlelabel
            // 
            this.subTitlelabel.AutoSize = true;
            this.subTitlelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subTitlelabel.ForeColor = System.Drawing.Color.Salmon;
            this.subTitlelabel.Location = new System.Drawing.Point(134, 98);
            this.subTitlelabel.Name = "subTitlelabel";
            this.subTitlelabel.Size = new System.Drawing.Size(136, 25);
            this.subTitlelabel.TabIndex = 1;
            this.subTitlelabel.Text = "Subtitle label";
            // 
            // hero2Points
            // 
            this.hero2Points.AutoSize = true;
            this.hero2Points.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hero2Points.ForeColor = System.Drawing.Color.Salmon;
            this.hero2Points.Location = new System.Drawing.Point(516, 9);
            this.hero2Points.Name = "hero2Points";
            this.hero2Points.Size = new System.Drawing.Size(72, 25);
            this.hero2Points.TabIndex = 2;
            this.hero2Points.Text = "Points";
            // 
            // hero1Points
            // 
            this.hero1Points.AutoSize = true;
            this.hero1Points.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hero1Points.ForeColor = System.Drawing.Color.Salmon;
            this.hero1Points.Location = new System.Drawing.Point(12, 9);
            this.hero1Points.Name = "hero1Points";
            this.hero1Points.Size = new System.Drawing.Size(72, 25);
            this.hero1Points.TabIndex = 3;
            this.hero1Points.Text = "Points";
            // 
            // winLabel
            // 
            this.winLabel.AutoSize = true;
            this.winLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winLabel.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.winLabel.Location = new System.Drawing.Point(214, 65);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(135, 33);
            this.winLabel.TabIndex = 4;
            this.winLabel.Text = "Win label";
            this.winLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(600, 378);
            this.Controls.Add(this.winLabel);
            this.Controls.Add(this.hero1Points);
            this.Controls.Add(this.hero2Points);
            this.Controls.Add(this.subTitlelabel);
            this.Controls.Add(this.titleLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer gameLoop;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subTitlelabel;
        private System.Windows.Forms.Label hero2Points;
        private System.Windows.Forms.Label hero1Points;
        private System.Windows.Forms.Label winLabel;
    }
}

