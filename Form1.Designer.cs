namespace Tetris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Canvas = new System.Windows.Forms.Panel();
            this.pB_nextBlock = new System.Windows.Forms.PictureBox();
            this.lbl_nextBlock = new System.Windows.Forms.Label();
            this.lbl_score = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pB_nextBlock)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Canvas.AutoScroll = true;
            this.Canvas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.Canvas.Location = new System.Drawing.Point(250, 50);
            this.Canvas.MinimumSize = new System.Drawing.Size(400, 800);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(400, 800);
            this.Canvas.TabIndex = 5;
            // 
            // pB_nextBlock
            // 
            this.pB_nextBlock.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pB_nextBlock.Location = new System.Drawing.Point(683, 338);
            this.pB_nextBlock.Name = "pB_nextBlock";
            this.pB_nextBlock.Size = new System.Drawing.Size(150, 150);
            this.pB_nextBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_nextBlock.TabIndex = 6;
            this.pB_nextBlock.TabStop = false;
            // 
            // lbl_nextBlock
            // 
            this.lbl_nextBlock.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_nextBlock.AutoSize = true;
            this.lbl_nextBlock.BackColor = System.Drawing.Color.Black;
            this.lbl_nextBlock.Font = new System.Drawing.Font("Segoe UI Light", 15F);
            this.lbl_nextBlock.Location = new System.Drawing.Point(678, 307);
            this.lbl_nextBlock.Name = "lbl_nextBlock";
            this.lbl_nextBlock.Size = new System.Drawing.Size(140, 28);
            this.lbl_nextBlock.TabIndex = 7;
            this.lbl_nextBlock.Text = "Nächster Block:";
            // 
            // lbl_score
            // 
            this.lbl_score.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_score.AutoSize = true;
            this.lbl_score.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_score.Font = new System.Drawing.Font("Segoe UI Light", 20F);
            this.lbl_score.Location = new System.Drawing.Point(376, 9);
            this.lbl_score.Name = "lbl_score";
            this.lbl_score.Size = new System.Drawing.Size(85, 37);
            this.lbl_score.TabIndex = 8;
            this.lbl_score.Text = "Score:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(884, 861);
            this.Controls.Add(this.lbl_score);
            this.Controls.Add(this.lbl_nextBlock);
            this.Controls.Add(this.pB_nextBlock);
            this.Controls.Add(this.Canvas);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI Light", 8.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(900, 900);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Window_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pB_nextBlock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.PictureBox pB_nextBlock;
        private System.Windows.Forms.Label lbl_nextBlock;
        private System.Windows.Forms.Label lbl_score;
    }
}

