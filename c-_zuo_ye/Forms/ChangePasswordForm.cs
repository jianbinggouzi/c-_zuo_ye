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
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String str1 = this.textBox1.Text;
            String str2 = this.textBox2.Text;
            if (str1.Equals(str2))
            {
                RuntimeContext.Context.userService.changUserPassword(RuntimeContext.Context.user.getUuid(), str1);
                MessageBox.Show("修改成功");
                RuntimeContext.Context.user.setPassword(str1);
                this.Close();
            }
            else
            {
                MessageBox.Show("两次密码不一致");
                this.textBox1.Clear();
                this.textBox2.Clear();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
