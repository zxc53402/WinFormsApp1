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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.訂單資訊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.訂單ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.訂單明細ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.產品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.產品資訊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.供應商ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.供應商資訊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.顧客ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.顧客資訊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.員工資訊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.員工資訊ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(1199, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 訂單資訊ToolStripMenuItem
            // 
            this.訂單資訊ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.訂單ToolStripMenuItem,
            this.訂單明細ToolStripMenuItem});
            this.訂單資訊ToolStripMenuItem.Name = "訂單資訊ToolStripMenuItem";
            this.訂單資訊ToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.訂單資訊ToolStripMenuItem.Text = "訂單";
            // 
            // 訂單ToolStripMenuItem
            // 
            this.訂單ToolStripMenuItem.Name = "訂單ToolStripMenuItem";
            this.訂單ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.訂單ToolStripMenuItem.Text = "訂單建立";
            this.訂單ToolStripMenuItem.Click += new System.EventHandler(this.訂單ToolStripMenuItem_Click);
            // 
            // 訂單明細ToolStripMenuItem
            // 
            this.訂單明細ToolStripMenuItem.Name = "訂單明細ToolStripMenuItem";
            this.訂單明細ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.訂單明細ToolStripMenuItem.Text = "訂單資訊";
            this.訂單明細ToolStripMenuItem.Click += new System.EventHandler(this.訂單明細ToolStripMenuItem_Click);
            // 
            // 產品ToolStripMenuItem
            // 
            this.產品ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.產品資訊ToolStripMenuItem});
            this.產品ToolStripMenuItem.Name = "產品ToolStripMenuItem";
            this.產品ToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.產品ToolStripMenuItem.Text = "產品";
            // 
            // 產品資訊ToolStripMenuItem
            // 
            this.產品資訊ToolStripMenuItem.Name = "產品資訊ToolStripMenuItem";
            this.產品資訊ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.產品資訊ToolStripMenuItem.Text = "產品資訊";
            this.產品資訊ToolStripMenuItem.Click += new System.EventHandler(this.產品資訊ToolStripMenuItem_Click);
            // 
            // 供應商ToolStripMenuItem
            // 
            this.供應商ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.供應商資訊ToolStripMenuItem});
            this.供應商ToolStripMenuItem.Name = "供應商ToolStripMenuItem";
            this.供應商ToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.供應商ToolStripMenuItem.Text = "供應商";
            // 
            // 供應商資訊ToolStripMenuItem
            // 
            this.供應商資訊ToolStripMenuItem.Name = "供應商資訊ToolStripMenuItem";
            this.供應商資訊ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.供應商資訊ToolStripMenuItem.Text = "供應商資訊";
            this.供應商資訊ToolStripMenuItem.Click += new System.EventHandler(this.供應商資訊ToolStripMenuItem_Click);
            // 
            // 顧客ToolStripMenuItem
            // 
            this.顧客ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.顧客資訊ToolStripMenuItem});
            this.顧客ToolStripMenuItem.Name = "顧客ToolStripMenuItem";
            this.顧客ToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.顧客ToolStripMenuItem.Text = "顧客";
            // 
            // 顧客資訊ToolStripMenuItem
            // 
            this.顧客資訊ToolStripMenuItem.Name = "顧客資訊ToolStripMenuItem";
            this.顧客資訊ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.顧客資訊ToolStripMenuItem.Text = "顧客資訊";
            this.顧客資訊ToolStripMenuItem.Click += new System.EventHandler(this.顧客資訊ToolStripMenuItem_Click);
            // 
            // 員工資訊ToolStripMenuItem
            // 
            this.員工資訊ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.員工資訊ToolStripMenuItem1});
            this.員工資訊ToolStripMenuItem.Name = "員工資訊ToolStripMenuItem";
            this.員工資訊ToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.員工資訊ToolStripMenuItem.Text = "員工";
            // 
            // 員工資訊ToolStripMenuItem1
            // 
            this.員工資訊ToolStripMenuItem1.Name = "員工資訊ToolStripMenuItem1";
            this.員工資訊ToolStripMenuItem1.Size = new System.Drawing.Size(152, 26);
            this.員工資訊ToolStripMenuItem1.Text = "員工資訊";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1054, 646);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "結束";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(436, 553);
            this.dataGridView1.TabIndex = 2;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(499, 75);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 29;
            this.dataGridView2.Size = new System.Drawing.Size(664, 553);
            this.dataGridView2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(33, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "產品銷量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("標楷體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(499, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "顧客訂單量";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(396, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(73, 27);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "預設本月";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(273, 37);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(108, 27);
            this.comboBox2.TabIndex = 9;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 704);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
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
        private BindingSource bindingSource1;
        private BindingSource bindingSource2;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private ComboBox comboBox2;
    }
}