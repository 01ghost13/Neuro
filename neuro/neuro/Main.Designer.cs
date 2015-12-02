namespace neuro
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbPics = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPicture = new System.Windows.Forms.Label();
            this.btnParse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbExit = new System.Windows.Forms.RadioButton();
            this.rbHidden = new System.Windows.Forms.RadioButton();
            this.rbEnter = new System.Windows.Forms.RadioButton();
            this.lbSinapses = new System.Windows.Forms.ListView();
            this.btnLearn = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.rtbSinapses = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPics
            // 
            this.lbPics.FormattingEnabled = true;
            this.lbPics.Location = new System.Drawing.Point(243, 57);
            this.lbPics.Name = "lbPics";
            this.lbPics.Size = new System.Drawing.Size(151, 225);
            this.lbPics.TabIndex = 1;
            this.lbPics.SelectedIndexChanged += new System.EventHandler(this.lbPics_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(401, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Таблица Нейронов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Картинки";
            // 
            // lblPicture
            // 
            this.lblPicture.AutoSize = true;
            this.lblPicture.Location = new System.Drawing.Point(240, 9);
            this.lblPicture.MinimumSize = new System.Drawing.Size(30, 30);
            this.lblPicture.Name = "lblPicture";
            this.lblPicture.Size = new System.Drawing.Size(30, 30);
            this.lblPicture.TabIndex = 4;
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(13, 177);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 5;
            this.btnParse.Text = "Распознать";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbExit);
            this.groupBox1.Controls.Add(this.rbHidden);
            this.groupBox1.Controls.Add(this.rbEnter);
            this.groupBox1.Location = new System.Drawing.Point(13, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Переключение между слоями";
            // 
            // rbExit
            // 
            this.rbExit.AutoSize = true;
            this.rbExit.Location = new System.Drawing.Point(7, 66);
            this.rbExit.Name = "rbExit";
            this.rbExit.Size = new System.Drawing.Size(102, 17);
            this.rbExit.TabIndex = 2;
            this.rbExit.TabStop = true;
            this.rbExit.Text = "Выходной слой";
            this.rbExit.UseVisualStyleBackColor = true;
            this.rbExit.CheckedChanged += new System.EventHandler(this.showNeurons);
            // 
            // rbHidden
            // 
            this.rbHidden.AutoSize = true;
            this.rbHidden.Location = new System.Drawing.Point(7, 43);
            this.rbHidden.Name = "rbHidden";
            this.rbHidden.Size = new System.Drawing.Size(98, 17);
            this.rbHidden.TabIndex = 1;
            this.rbHidden.TabStop = true;
            this.rbHidden.Text = "Скрытый слой";
            this.rbHidden.UseVisualStyleBackColor = true;
            this.rbHidden.CheckedChanged += new System.EventHandler(this.showNeurons);
            // 
            // rbEnter
            // 
            this.rbEnter.AutoSize = true;
            this.rbEnter.Location = new System.Drawing.Point(7, 20);
            this.rbEnter.Name = "rbEnter";
            this.rbEnter.Size = new System.Drawing.Size(94, 17);
            this.rbEnter.TabIndex = 0;
            this.rbEnter.TabStop = true;
            this.rbEnter.Text = "Входной слой";
            this.rbEnter.UseVisualStyleBackColor = true;
            this.rbEnter.CheckedChanged += new System.EventHandler(this.showNeurons);
            // 
            // lbSinapses
            // 
            this.lbSinapses.Location = new System.Drawing.Point(404, 59);
            this.lbSinapses.Name = "lbSinapses";
            this.lbSinapses.Size = new System.Drawing.Size(246, 223);
            this.lbSinapses.TabIndex = 7;
            this.lbSinapses.UseCompatibleStateImageBehavior = false;
            this.lbSinapses.SelectedIndexChanged += new System.EventHandler(this.lbSinapses_SelectedIndexChanged);
            // 
            // btnLearn
            // 
            this.btnLearn.Location = new System.Drawing.Point(12, 206);
            this.btnLearn.Name = "btnLearn";
            this.btnLearn.Size = new System.Drawing.Size(75, 23);
            this.btnLearn.TabIndex = 8;
            this.btnLearn.Text = "Обучить";
            this.btnLearn.UseVisualStyleBackColor = true;
            this.btnLearn.Click += new System.EventHandler(this.learn);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 235);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rtbSinapses
            // 
            this.rtbSinapses.BackColor = System.Drawing.Color.White;
            this.rtbSinapses.Location = new System.Drawing.Point(668, 59);
            this.rtbSinapses.Name = "rtbSinapses";
            this.rtbSinapses.ReadOnly = true;
            this.rtbSinapses.Size = new System.Drawing.Size(304, 223);
            this.rtbSinapses.TabIndex = 10;
            this.rtbSinapses.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(665, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Значения синапсов";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(243, 299);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 340);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbSinapses);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLearn);
            this.Controls.Add(this.lbSinapses);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.lblPicture);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbPics);
            this.MaximumSize = new System.Drawing.Size(1054, 379);
            this.MinimumSize = new System.Drawing.Size(1054, 379);
            this.Name = "Main";
            this.Text = "Главное Окно";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbPics;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPicture;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbExit;
        private System.Windows.Forms.RadioButton rbHidden;
        private System.Windows.Forms.RadioButton rbEnter;
        private System.Windows.Forms.ListView lbSinapses;
        private System.Windows.Forms.Button btnLearn;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox rtbSinapses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdate;
    }
}

