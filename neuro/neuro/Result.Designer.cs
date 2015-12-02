namespace neuro
{
    partial class Result
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
            this.lblImg = new System.Windows.Forms.Label();
            this.tbResult = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.tbResult)).BeginInit();
            this.SuspendLayout();
            // 
            // lblImg
            // 
            this.lblImg.AutoSize = true;
            this.lblImg.Location = new System.Drawing.Point(12, 9);
            this.lblImg.MinimumSize = new System.Drawing.Size(30, 30);
            this.lblImg.Name = "lblImg";
            this.lblImg.Size = new System.Drawing.Size(30, 30);
            this.lblImg.TabIndex = 0;
            // 
            // tbResult
            // 
            this.tbResult.AutoSize = true;
            this.tbResult.BackColor = System.Drawing.Color.White;
            this.tbResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbResult.Location = new System.Drawing.Point(0, 41);
            this.tbResult.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.Size = new System.Drawing.Size(284, 20);
            this.tbResult.TabIndex = 3;
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 61);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.lblImg);
            this.MaximumSize = new System.Drawing.Size(300, 100);
            this.MinimumSize = new System.Drawing.Size(300, 100);
            this.Name = "Result";
            this.Text = "Результат";
            ((System.ComponentModel.ISupportInitialize)(this.tbResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblImg;
        private System.Windows.Forms.NumericUpDown tbResult;
    }
}