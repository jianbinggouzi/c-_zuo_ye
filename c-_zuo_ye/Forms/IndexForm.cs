using c__zuo_ye.Domain;
using System;
using System.Collections;
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
    public partial class IndexForm : Form
    {
        public IndexForm()
        {
            InitializeComponent();
            user = RuntimeContext.Context.user;

            initListView1();
            initListView2();
            initListBox1();

           

        }


        public void initListBox1()
        {

            listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            listBox1.MeasureItem +=
                new MeasureItemEventHandler(ListBox1_MeasureItem);
            listBox1.DrawItem += new DrawItemEventHandler(ListBox1_DrawItem);

            updateListBox1Data();
           
        }

        //更新ListBox1的数据部分
        public void updateListBox1Data()
        {
            posts = RuntimeContext.Context.postService.getPosts(-1, pageSize);

            Hashtable map = new Hashtable();
            for(int i = 0; i < posts.Count; i++)
            {
                if (!map.Contains(posts[i].getUuid()))
                {
                    string name = RuntimeContext.Context.userService.getUserNameByUuid(posts[i].getUseruuid());
                    map.Add(posts[i].getUuid(),name);
                }
            }

            this.postsTable = new DataTable("list");
            this.postsTable.Columns.Add("username");
            this.postsTable.Columns.Add("time");
            this.postsTable.Columns.Add("text", System.Type.GetType("System.String"));

            for(int i = 0; i < posts.Count; i++)
            {
                this.postsTable.Rows.Add(new object[] { map[posts[i].getUuid()], posts[i].getTime(), posts[i].getText() });
                
            }

            this.listBox1.Items.Clear();
            for (int i = 0; i < this.postsTable.Rows.Count; i++)
            {
                this.listBox1.Items.Add(i);
            }
            this.pageNo++;
         

        }
        //ListBox1测量子项目函数
        private void ListBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {

            Graphics graphics = e.Graphics;
            
            string dhead = this.postsTable.Rows[e.Index]["username"].ToString()+" 发布于 "+ this.postsTable.Rows[e.Index]["time"].ToString();            
            string dtext = this.postsTable.Rows[e.Index]["text"].ToString();
            
            SizeF numberSizeF = graphics.MeasureString(dhead, this.listBox1.Font);
            Rectangle rectangle = new Rectangle((int)numberSizeF.Width, (int)numberSizeF.Height, (int)(this.listBox1.ClientSize.Width - numberSizeF.Width), e.ItemHeight);

            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.FitBlackBox;
            SizeF f2 = graphics.MeasureString(dtext, this.listBox1.Font, rectangle.Width, stringFormat);
           
            e.ItemHeight = 5+(int)numberSizeF.Height + (int)f2.Height;
            
        }

        //ListBox1添加子项目
        private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            
            int number = e.Index + 1;
            string dhead = this.postsTable.Rows[e.Index]["username"].ToString() + " 发布于 " + this.postsTable.Rows[e.Index]["time"].ToString();

            string dtext = this.postsTable.Rows[e.Index]["text"].ToString();

            if((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                Graphics graphics = e.Graphics;

                Pen pen = new Pen(Brushes.SteelBlue, 0.4f);

                graphics.DrawRectangle(pen, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                graphics.FillRectangle(Brushes.LightSteelBlue, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);


                graphics.DrawString(dhead + ".", this.listBox1.Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                SizeF f1 = graphics.MeasureString(number.ToString() + ".", listBox1.Font);

              

                Rectangle rect = new Rectangle(e.Bounds.X  + (int)f1.Width, e.Bounds.Y  + (int)f1.Height+4 , this.listBox1.ClientSize.Width - (int)f1.Width, this.ClientSize.Height);
                StringFormat stf = new StringFormat();
                stf.FormatFlags = StringFormatFlags.FitBlackBox;

                graphics.DrawString(dtext, listBox1.Font, Brushes.Black, rect, stf);

            }
            else
            {
                Graphics gfx = e.Graphics;
                gfx.FillRectangle(Brushes.White, e.Bounds.X, e.Bounds.Y, e.Bounds.Width , e.Bounds.Height);
                gfx.FillRectangle(Brushes.SteelBlue, e.Bounds.X, e.Bounds.Y + e.Bounds.Height, e.Bounds.Width, 1);
                Pen pen = new Pen(Brushes.SteelBlue, 0.4f);

                gfx.DrawString(dhead + ".", listBox1.Font, Brushes.Black, e.Bounds.X , e.Bounds.Y);
                SizeF f1 = gfx.MeasureString(number.ToString() + ".", listBox1.Font);

                Rectangle rect = new Rectangle(e.Bounds.X + (int)f1.Width, e.Bounds.Y + (int)f1.Height+4, this.listBox1.ClientSize.Width - (int)f1.Width, this.ClientSize.Height);
                StringFormat stf = new StringFormat();
                stf.FormatFlags = StringFormatFlags.FitBlackBox;
                gfx.DrawString(dtext, listBox1.Font, Brushes.Black, rect, stf);

            }
            e.DrawFocusRectangle();
           
        }


        public void initListView1(){
            listView1.Items.Add("UUID:");
            listView1.Items.Add("   " + user.getUuid());
            listView1.Items.Add("用户名:");
            listView1.Items.Add("   "+user.getName());
            listView1.Items.Add("发帖数:");
            listView1.Items.Add("   "+user.getSend().ToString());
           
            ListViewItem item = new ListViewItem();
            item.ForeColor = Color.Blue;
            item.Text = "发布新帖子";
            listView1.Items.Add(item);

            item = new ListViewItem();
            item.ForeColor = Color.Blue;
            item.Text = "刷新";
            listView1.Items.Add(item);
        }

        public void initListView2()
        {
            ListViewItem item = new ListViewItem();
            item.ForeColor = Color.Blue;
            item.Text = "修改用户名";
            listView2.Items.Add(item);

            item = new ListViewItem();
            item.ForeColor = Color.Blue;
            item.Text = "修改密码";
            listView2.Items.Add(item);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        //listView1发布新帖子
        private void ListView1_Click(object sender, EventArgs e)
        {
            string str = listView1.SelectedItems[0].ToString();
            listView2.SelectedItems.Clear();
            if (str.Contains("发布新帖子"))
            {
                (new WriteForm()).ShowDialog();
                updateListBox1Data();
            }
            else if(str.Contains("刷新"))
            {
                updateListBox1Data();
            }
        }

        private void ListBox1_Click(object sender, EventArgs e)
        {
           
            (new PostForm(posts[listBox1.SelectedIndex])).ShowDialog();
        }

        private void ListView2_Click(object sender, EventArgs e)
        {
            string str = (listView2.SelectedItems[0].ToString());
            listView2.SelectedItems.Clear();
           
            if (str.Contains("修改用户名"))
            {
                (new ChangeUserNameForm()).ShowDialog();
                updateListBox1Data();
            }
            else if (str.Contains("修改密码"))
            {
                (new ChangePasswordForm()).ShowDialog();
                updateListBox1Data();
            }
        }
    }
}
