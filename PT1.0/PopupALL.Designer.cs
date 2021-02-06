namespace PT1._0
{
    partial class PopupALL
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
            this.DB = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DB)).BeginInit();
            this.SuspendLayout();
            // 
            // DB
            // 
            this.DB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DB.Location = new System.Drawing.Point(12, 29);
            this.DB.Name = "DB";
            this.DB.Size = new System.Drawing.Size(913, 525);
            this.DB.TabIndex = 0;
            this.DB.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DB_CellBeginEdit);
            this.DB.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DB_CellEndEdit);
            this.DB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DB_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Дополнительные данные для ступеней";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 561);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "** целое число от 1 до 7 в зависимости от типа уплотнения";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 579);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "*** 1 - если бандаж присутствует, в обратном случае - 0";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(334, 556);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Нумерация уплотнений";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 595);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(182, 47);
            this.button3.TabIndex = 74;
            this.button3.Text = "Изменить исходные данные";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(724, 595);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(201, 48);
            this.button4.TabIndex = 75;
            this.button4.Text = "Продолжить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(503, 561);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "* 0 если не предусмотрен сепаратор";
            // 
            // PopupALL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 652);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DB);
            this.Controls.Add(this.label1);
            this.Name = "PopupALL";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.DB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
    }
}