namespace c__zuo_ye.Forms
{
    partial class IndexForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.最新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最热ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.个人中心ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最近浏览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(883, 532);
            this.listBox1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.用户名ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1088, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.最新ToolStripMenuItem,
            this.最热ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(65, 20);
            this.toolStripMenuItem1.Text = "排序方式";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 最新ToolStripMenuItem
            // 
            this.最新ToolStripMenuItem.Name = "最新ToolStripMenuItem";
            this.最新ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.最新ToolStripMenuItem.Text = "最新";
            // 
            // 最热ToolStripMenuItem
            // 
            this.最热ToolStripMenuItem.Name = "最热ToolStripMenuItem";
            this.最热ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.最热ToolStripMenuItem.Text = "最热";
            // 
            // 用户名ToolStripMenuItem
            // 
            this.用户名ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.用户名ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.个人中心ToolStripMenuItem,
            this.最近浏览ToolStripMenuItem});
            this.用户名ToolStripMenuItem.Name = "用户名ToolStripMenuItem";
            this.用户名ToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.用户名ToolStripMenuItem.Text = "用户名";
            // 
            // 个人中心ToolStripMenuItem
            // 
            this.个人中心ToolStripMenuItem.Name = "个人中心ToolStripMenuItem";
            this.个人中心ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.个人中心ToolStripMenuItem.Text = "修改资料";
            // 
            // 最近浏览ToolStripMenuItem
            // 
            this.最近浏览ToolStripMenuItem.Name = "最近浏览ToolStripMenuItem";
            this.最近浏览ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.最近浏览ToolStripMenuItem.Text = "最近浏览";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(893, 27);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(195, 244);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1038, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "大家在看";
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(893, 301);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(198, 258);
            this.listView2.TabIndex = 4;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 557);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "IndexForm";
            this.Text = "首页";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 最新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最热ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 个人中心ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最近浏览ToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView2;
    }
}