namespace PT1._0
{
    partial class GearParam
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортВWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DB)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DB
            // 
            this.DB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DB.Location = new System.Drawing.Point(12, 36);
            this.DB.Name = "DB";
            this.DB.Size = new System.Drawing.Size(776, 423);
            this.DB.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.импортВExcelToolStripMenuItem,
            this.экспортВWordToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(143, 20);
            this.файлToolStripMenuItem.Text = "Сохранить результаты";
            // 
            // импортВExcelToolStripMenuItem
            // 
            this.импортВExcelToolStripMenuItem.Name = "импортВExcelToolStripMenuItem";
            this.импортВExcelToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.импортВExcelToolStripMenuItem.Text = "Экспорт в Excel";
            this.импортВExcelToolStripMenuItem.Click += new System.EventHandler(this.импортВExcelToolStripMenuItem_Click);
            // 
            // экспортВWordToolStripMenuItem
            // 
            this.экспортВWordToolStripMenuItem.Name = "экспортВWordToolStripMenuItem";
            this.экспортВWordToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.экспортВWordToolStripMenuItem.Text = "Экспорт в Word";
            this.экспортВWordToolStripMenuItem.Click += new System.EventHandler(this.экспортВWordToolStripMenuItem_Click);
            // 
            // GearParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 471);
            this.Controls.Add(this.DB);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GearParam";
            this.Text = "Параметры по ступеням";
            ((System.ComponentModel.ISupportInitialize)(this.DB)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem импортВExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экспортВWordToolStripMenuItem;
    }
}