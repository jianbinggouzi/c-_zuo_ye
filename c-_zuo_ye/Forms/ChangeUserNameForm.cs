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
    public partial class ChangeUserNameForm : Form
    {
        public ChangeUserNameForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int n = RuntimeContext.Context.userService.changeUserName(RuntimeContext.Context.user.getUuid(), this.textBox1.Text);
            if (n > 0)
            {
                MessageBox.Show("修改成功");
                RuntimeContext.Context.user.setName(this.textBox1.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
