using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication3;  //要合并的项目的命名空间

namespace cable_stayed01
{
    public partial class main01 : Form
    {
        public main01()
        {
            InitializeComponent();
        }

        //public void Showform(Form form)
        //{
        //    //清除panel里面的其他窗体
        //    this.panel1.Controls.Clear();
        //    //将该子窗体设置成非顶级控件
        //    form.TopLevel = false;
        //    //将该子窗体的边框去掉
        //    form.FormBorderStyle = FormBorderStyle.None;
        //    //设置子窗体随容器大小自动调整
        //    form.Dock = DockStyle.Fill;
        //    //设置mdi父容器为当前窗口
        //    form.Parent = this.panel1;
        //    //子窗体显示
        //    form.Show();
        //}

        private void label1_Click(object sender, EventArgs e)
        {
            ////实例化查看上机记录窗体
            //Form f1 = new bridge_example();
            //Showform(f1);  //为了统一风格，不嵌套窗体了
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f2 = new drawing();
            //Showform(f2);  //窗体嵌套绘图速度太慢
            //this.Hide(); 隐藏了，但会占内存
            f2.ShowDialog();
            //this.Close();  两个窗体一起关闭
        }

        public void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            g.DrawPath(p, gp);
            gp.Dispose();
        }

        //private void pictureBox1_Paint(object sender, PaintEventArgs e)
        //{
        //    Pen p = new Pen(Color.Black, 2);
        //    DrawRoundRect(e.Graphics, p, 0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1, 10); //绘制圆角矩形,太丑了，啊啊啊
            
        //}

        private void main01_Load(object sender, EventArgs e)
        {
            //pictureBox1.Refresh();
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label_bridge_Click(object sender, EventArgs e)
        {
            Form f1 = new bridge_example();
            f1.ShowDialog();  //案例参考窗口
        }

        private void label_model_Click(object sender, EventArgs e)
        {
            Form f2 = new drawing();
            f2.ShowDialog();   //模型设计窗口
        }

        private void label_manage_Click(object sender, EventArgs e)
        {
            Form f3 = new ModelCheck();
            f3.ShowDialog();   //模型管理窗口
        }

        
    }
}
