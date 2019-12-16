using c__zuo_ye.Domain;
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
    public partial class WriteForm : Form
    {
        public WriteForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String text = textBox1.Text.ToString();
            Post post = new Post(text, RuntimeContext.Context.user.getUuid(), "");
            RuntimeContext.Context.postService.addPost(post);
            MessageBox.Show("发布成功");
            this.Close();
     
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
