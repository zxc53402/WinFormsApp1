namespace WinFormsApp1
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.訂單資訊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.訂單ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.訂單明細ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.產品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.產品資訊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.供應商ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.供應商資訊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.員工資訊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.員工資訊ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.顧客ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.顧客資訊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.訂單資訊ToolStripMenuItem,
            this.產品ToolStripMenuItem,
            this.供應商ToolStripMenuItem,
            this.顧客ToolStripMenuItem,
            this.員工資訊ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(962, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 訂單資訊ToolStripMenuItem
            // 
            this.訂單資訊ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.訂單ToolStripMenuItem,
            this.訂單明細ToolStripMenuItem});
            this.訂單資訊ToolStripMenuItem.Name = "訂單資訊ToolStripMenuItem";
            this.訂單資訊ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.訂單資訊ToolStripMenuItem.Text = "訂單";
            // 
            // 訂單ToolStripMenuItem
            // 
            this.訂單ToolStripMenuItem.Name = "訂單ToolStripMenuItem";
            this.訂單ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.訂單ToolStripMenuItem.Text = "訂單建立";
            this.訂單ToolStripMenuItem.Click += new System.EventHandler(this.訂單ToolStripMenuItem_Click);
            // 
            // 訂單明細ToolStripMenuItem
            // 
            this.訂單明細ToolStripMenuItem.Name = "訂單明細ToolStripMenuItem";
            this.訂單明細ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.訂單明細ToolStripMenuItem.Text = "訂單資訊";
            this.訂單明細ToolStripMenuItem.Click += new System.EventHandler(this.訂單明細ToolStripMenuItem_Click);
            // 
            // 產品ToolStripMenuItem
            // 
            this.產品ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.產品資訊ToolStripMenuItem});
            this.產品ToolStripMenuItem.Name = "產品ToolStripMenuItem";
            this.產品ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.產品ToolStripMenuItem.Text = "產品";
            // 
            // 產品資訊ToolStripMenuItem
            // 
            this.產品資訊ToolStripMenuItem.Name = "產品資訊ToolStripMenuItem";
            this.產品資訊ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.產品資訊ToolStripMenuItem.Text = "產品資訊";
            this.產品資訊ToolStripMenuItem.Click += new System.EventHandler(this.產品資訊ToolStripMenuItem_Click);
            // 
            // 供應商ToolStripMenuItem
            // 
            this.供應商ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.供應商資訊ToolStripMenuItem});
            this.供應商ToolStripMenuItem.Name = "供應商ToolStripMenuItem";
            this.供應商ToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.供應商ToolStripMenuItem.Text = "供應商";
            // 
            // 供應商資訊ToolStripMenuItem
            // 
            this.供應商資訊ToolStripMenuItem.Name = "供應商資訊ToolStripMenuItem";
            this.供應商資訊ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.供應商資訊ToolStripMenuItem.Text = "供應商資訊";
            this.供應商資訊ToolStripMenuItem.Click += new System.EventHandler(this.供應商資訊ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(818, 625);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "結束";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 員工資訊ToolStripMenuItem
            // 
            this.員工資訊ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.員工資訊ToolStripMenuItem1});
            this.員工資訊ToolStripMenuItem.Name = "員工資訊ToolStripMenuItem";
            this.員工資訊ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.員工資訊ToolStripMenuItem.Text = "員工";
            // 
            // 員工資訊ToolStripMenuItem1
            // 
            this.員工資訊ToolStripMenuItem1.Name = "員工資訊ToolStripMenuItem1";
            this.員工資訊ToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.員工資訊ToolStripMenuItem1.Text = "員工資訊";
            // 
            // 顧客ToolStripMenuItem
            // 
            this.顧客ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.顧客資訊ToolStripMenuItem});
            this.顧客ToolStripMenuItem.Name = "顧客ToolStripMenuItem";
            this.顧客ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.顧客ToolStripMenuItem.Text = "顧客";
            // 
            // 顧客資訊ToolStripMenuItem
            // 
            this.顧客資訊ToolStripMenuItem.Name = "顧客資訊ToolStripMenuItem";
            this.顧客資訊ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.顧客資訊ToolStripMenuItem.Text = "顧客資訊";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 704);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 訂單資訊ToolStripMenuItem;
        private ToolStripMenuItem 訂單ToolStripMenuItem;
        private ToolStripMenuItem 訂單明細ToolStripMenuItem;
        private ToolStripMenuItem 產品ToolStripMenuItem;
        private ToolStripMenuItem 產品資訊ToolStripMenuItem;
        private ToolStripMenuItem 供應商ToolStripMenuItem;
        private ToolStripMenuItem 供應商資訊ToolStripMenuItem;
        private Button button1;
        private ToolStripMenuItem 顧客ToolStripMenuItem;
        private ToolStripMenuItem 顧客資訊ToolStripMenuItem;
        private ToolStripMenuItem 員工資訊ToolStripMenuItem;
        private ToolStripMenuItem 員工資訊ToolStripMenuItem1;
    }
}