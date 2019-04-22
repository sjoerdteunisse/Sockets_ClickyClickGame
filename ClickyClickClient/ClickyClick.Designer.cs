namespace ClickyClickClient
{
    partial class ClickyClick
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
            this.pbx_game = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.lbl_Score = new System.Windows.Forms.Label();
            this.lbl_GameText = new System.Windows.Forms.Label();
            this.lbl_TimeRemaining = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_game)).BeginInit();
            this.SuspendLayout();
            // 
            // pbx_game
            // 
            this.pbx_game.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbx_game.Location = new System.Drawing.Point(2, 3);
            this.pbx_game.Name = "pbx_game";
            this.pbx_game.Size = new System.Drawing.Size(800, 450);
            this.pbx_game.TabIndex = 0;
            this.pbx_game.TabStop = false;
            // 
            // lbl_Score
            // 
            this.lbl_Score.AutoSize = true;
            this.lbl_Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Score.Location = new System.Drawing.Point(12, 417);
            this.lbl_Score.Name = "lbl_Score";
            this.lbl_Score.Size = new System.Drawing.Size(0, 24);
            this.lbl_Score.TabIndex = 1;
            // 
            // lbl_GameText
            // 
            this.lbl_GameText.AutoSize = true;
            this.lbl_GameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GameText.Location = new System.Drawing.Point(12, 9);
            this.lbl_GameText.Name = "lbl_GameText";
            this.lbl_GameText.Size = new System.Drawing.Size(0, 24);
            this.lbl_GameText.TabIndex = 2;
            // 
            // lbl_TimeRemaining
            // 
            this.lbl_TimeRemaining.AutoSize = true;
            this.lbl_TimeRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TimeRemaining.Location = new System.Drawing.Point(645, 9);
            this.lbl_TimeRemaining.Name = "lbl_TimeRemaining";
            this.lbl_TimeRemaining.Size = new System.Drawing.Size(0, 20);
            this.lbl_TimeRemaining.TabIndex = 3;
            // 
            // ClickyClick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_TimeRemaining);
            this.Controls.Add(this.lbl_GameText);
            this.Controls.Add(this.lbl_Score);
            this.Controls.Add(this.pbx_game);
            this.MaximizeBox = false;
            this.Name = "ClickyClick";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClickyClick";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ClickyClick_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_game)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbx_game;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label lbl_Score;
        private System.Windows.Forms.Label lbl_GameText;
        private System.Windows.Forms.Label lbl_TimeRemaining;
    }
}

