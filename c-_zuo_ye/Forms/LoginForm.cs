using c__zuo_ye.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c__zuo_ye.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.userService = new UserService();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string account = this.account_comboBox.Text;
            string password = this.password_textBox.Text;
            User user = userService.login()

        }

        private void signup_button_Click(object sender, EventArgs e)
        {
            string account = this.account_comboBox.Text;
            string password = this.password_textBox.Text;
            if (userService.signup(account, password))
                signup_button.Text = "注册成功，请登录";
        }
    }
}
