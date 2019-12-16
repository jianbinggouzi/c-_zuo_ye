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
    public partial class PostForm : Form
    {
        public PostForm()
        {
            InitializeComponent();
           
        }

        public PostForm(Post post)
        {
            InitializeComponent();
            this.post = post;
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

        //更新所有评论
        public void updateListBox1Data()
        {

            commentList = RuntimeContext.Context.postService.getComment(post.getUuid());
            commentList.Insert(0, this.post);
            Hashtable map = new Hashtable();
            for (int i = 0; i < commentList.Count; i++)
            {
                if (!map.Contains(commentList[i].getUuid()))
                {
                    string name = RuntimeContext.Context.userService.getUserNameByUuid(commentList[i].getUseruuid());
                    map.Add(commentList[i].getUuid(), name);
                }
            }

            this.dataTable = new DataTable("list");
            this.dataTable.Columns.Add("username");
            this.dataTable.Columns.Add("time");
            this.dataTable.Columns.Add("text", System.Type.GetType("System.String"));

            for (int i = 0; i < commentList.Count; i++)
            {
                this.dataTable.Rows.Add(new object[] { map[commentList[i].getUuid()], commentList[i].getTime(), commentList[i].getText() });

            }
            this.listBox1.Items.Clear();
            for (int i = 0; i < this.dataTable.Rows.Count; i++)
            {
                this.listBox1.Items.Add(i);
            }
        }

        //ListBox1测量子项目函数
        private void ListBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {

            Graphics graphics = e.Graphics;

            string dhead = this.dataTable.Rows[e.Index]["username"].ToString() + (e.Index == 0 ? " 发布于 " : " 评论于 ") + this.dataTable.Rows[e.Index]["time"].ToString();
            string dtext = this.dataTable.Rows[e.Index]["text"].ToString();

            SizeF numberSizeF = graphics.MeasureString(dhead, this.listBox1.Font);
            Rectangle rectangle = new Rectangle((int)numberSizeF.Width, (int)numberSizeF.Height, (int)(this.listBox1.ClientSize.Width - numberSizeF.Width), e.ItemHeight);

            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.FitBlackBox;
            SizeF f2 = graphics.MeasureString(dtext, this.listBox1.Font, rectangle.Width, stringFormat);

            e.ItemHeight = (e.Index==0? 15:5) + (int)numberSizeF.Height + (int)f2.Height;

        }

        //ListBox1添加子项目
        private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {

            int number = e.Index + 1;
            string dhead = this.dataTable.Rows[e.Index]["username"].ToString() + (e.Index==0?" 发布于 ":" 评论于 " )+ this.dataTable.Rows[e.Index]["time"].ToString();

            string dtext = this.dataTable.Rows[e.Index]["text"].ToString();

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                Graphics graphics = e.Graphics;

                Pen pen = new Pen(Brushes.SteelBlue, 0.4f);

                graphics.DrawRectangle(pen, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                graphics.FillRectangle(Brushes.LightSteelBlue, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);


                graphics.DrawString(dhead + ".", this.listBox1.Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                SizeF f1 = graphics.MeasureString(number.ToString() + ".", listBox1.Font);



                Rectangle rect = new Rectangle(e.Bounds.X + (int)f1.Width, e.Bounds.Y + (int)f1.Height , this.listBox1.ClientSize.Width - (int)f1.Width, this.ClientSize.Height + (e.Index == 0 ? 14 : 4));
                StringFormat stf = new StringFormat();
                stf.FormatFlags = StringFormatFlags.FitBlackBox;

                graphics.DrawString(dtext, listBox1.Font, Brushes.Black, rect, stf);

            }
            else
            {
                Graphics gfx = e.Graphics;
                gfx.FillRectangle(Brushes.White, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                gfx.FillRectangle(Brushes.SteelBlue, e.Bounds.X, e.Bounds.Y + e.Bounds.Height, e.Bounds.Width, 1);
                Pen pen = new Pen(Brushes.SteelBlue, 0.4f);

                gfx.DrawString(dhead + ".", listBox1.Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                SizeF f1 = gfx.MeasureString(number.ToString() + ".", listBox1.Font);

                Rectangle rect = new Rectangle(e.Bounds.X + (int)f1.Width, e.Bounds.Y + (int)f1.Height , this.listBox1.ClientSize.Width - (int)f1.Width, this.ClientSize.Height + (e.Index == 0 ? 14 : 4));
                StringFormat stf = new StringFormat();
                stf.FormatFlags = StringFormatFlags.FitBlackBox;
                gfx.DrawString(dtext, listBox1.Font, Brushes.Black, rect, stf);

            }
            e.DrawFocusRectangle();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Post post = new Post(this.textBox2.Text.ToString(), RuntimeContext.Context.user.getUuid(), this.post.getUuid());
            RuntimeContext.Context.postService.addPost(post);
            this.textBox2.Clear();
            updateListBox1Data();

        }
    }
}
