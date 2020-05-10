namespace MakeItTrue.View
{
    partial class Benvenuto
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
            this.menuButt = new System.Windows.Forms.Button();
            this.titolo = new System.Windows.Forms.Label();
            this.timerTitolo = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // menuButt
            // 
            this.menuButt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.menuButt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuButt.FlatAppearance.BorderSize = 0;
            this.menuButt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.menuButt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.menuButt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButt.ForeColor = System.Drawing.Color.Gainsboro;
            this.menuButt.Location = new System.Drawing.Point(536, 369);
            this.menuButt.Name = "menuButt";
            this.menuButt.Size = new System.Drawing.Size(95, 40);
            this.menuButt.TabIndex = 0;
            this.menuButt.Text = "Menu ->";
            this.menuButt.UseVisualStyleBackColor = false;
            // 
            // titolo
            // 
            this.titolo.AutoSize = true;
            this.titolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titolo.ForeColor = System.Drawing.Color.Gainsboro;
            this.titolo.Location = new System.Drawing.Point(175, 191);
            this.titolo.Name = "titolo";
            this.titolo.Size = new System.Drawing.Size(290, 55);
            this.titolo.TabIndex = 1;
            this.titolo.Text = "Make it True";
            // 
            // timerTitolo
            // 
            this.timerTitolo.Tick += new System.EventHandler(this.TimerTitolo_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ink Free", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(180, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "Welcome to...";
            // 
            // Benvenuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(634, 411);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titolo);
            this.Controls.Add(this.menuButt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Benvenuto";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Benvenuto";
            this.Load += new System.EventHandler(this.Benvenuto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button menuButt;
        private System.Windows.Forms.Label titolo;
        private System.Windows.Forms.Timer timerTitolo;
        private System.Windows.Forms.Label label1;
    }
}