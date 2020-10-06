namespace Summative_2D_Game
{
    partial class Win
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.winLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.againButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // winLabel
            // 
            this.winLabel.AutoSize = true;
            this.winLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winLabel.Location = new System.Drawing.Point(197, 72);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(419, 91);
            this.winLabel.TabIndex = 0;
            this.winLabel.Text = "YOU WIN!";
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Black;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.Firebrick;
            this.exitButton.Location = new System.Drawing.Point(542, 258);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(129, 92);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit Game";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // againButton
            // 
            this.againButton.BackColor = System.Drawing.Color.Black;
            this.againButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.againButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.againButton.ForeColor = System.Drawing.Color.Firebrick;
            this.againButton.Location = new System.Drawing.Point(149, 258);
            this.againButton.Name = "againButton";
            this.againButton.Size = new System.Drawing.Size(129, 92);
            this.againButton.TabIndex = 2;
            this.againButton.Text = "Play Again";
            this.againButton.UseVisualStyleBackColor = false;
            this.againButton.Click += new System.EventHandler(this.againButton_Click);
            // 
            // Win
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.Controls.Add(this.againButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.winLabel);
            this.Name = "Win";
            this.Size = new System.Drawing.Size(800, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label winLabel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button againButton;
    }
}
