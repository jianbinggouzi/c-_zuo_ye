using c__zuo_ye.Service;

namespace c__zuo_ye.Forms
{
    partial class LoginForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.account_comboBox = new System.Windows.Forms.ComboBox();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.login_button = new System.Windows.Forms.Button();
            this.signup_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(305, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "账号";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(305, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // account_comboBox
            // 
            this.account_comboBox.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.account_comboBox.FormattingEnabled = true;
            this.account_comboBox.Location = new System.Drawing.Point(391, 252);
            this.account_comboBox.Name = "account_comboBox";
            this.account_comboBox.Size = new System.Drawing.Size(252, 29);
            this.account_comboBox.TabIndex = 2;
            // 
            // password_textBox
            // 
            this.password_textBox.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.password_textBox.Location = new System.Drawing.Point(391, 304);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(252, 29);
            this.password_textBox.TabIndex = 3;
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(310, 368);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(130, 34);
            this.login_button.TabIndex = 4;
            this.login_button.Text = "登录";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // signup_button
            // 
            this.signup_button.Location = new System.Drawing.Point(513, 369);
            this.signup_button.Name = "signup_button";
            this.signup_button.Size = new System.Drawing.Size(130, 33);
            this.signup_button.TabIndex = 5;
            this.signup_button.Text = "注册";
            this.signup_button.UseVisualStyleBackColor = true;
            this.signup_button.Click += new System.EventHandler(this.signup_button_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 577);
            this.Controls.Add(this.signup_button);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.account_comboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox account_comboBox;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Button login_button;
        private UserService userService;
        private System.Windows.Forms.Button signup_button;
    }
}