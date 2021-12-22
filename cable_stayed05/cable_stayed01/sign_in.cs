using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;  //命名空间


namespace cable_stayed01
{
    public partial class sign_in : Form
    {
        public sign_in()
        {
            InitializeComponent();
        }
        static string mystr = @"Data Source=47.102.209.81;Initial Catalog=cableStayedBridge;User ID=NanxiChen;Password=123456";
        SqlConnection myconn = new SqlConnection(mystr);


        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text.Trim();
            String password = textBox2.Text.Trim();
            string mystr1 = "select userID,psw from bridgeDesigner where userID='" + username + "'";
            SqlDataAdapter myadapter1 = new SqlDataAdapter(mystr1, myconn);
            DataSet mydataset1 = new DataSet();
            myadapter1.Fill(mydataset1, "user");
            if (mydataset1.Tables["user"].Rows.Count == 0)    //Rows.Count多少行
            {
                MessageBox.Show("该用户未注册，请先注册", "提示", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (password == mydataset1.Tables["user"].Rows[0].ItemArray[1].ToString())
                {
                    //MessageBox.Show("登录成功！", "提示", MessageBoxButtons.OK);
                    Form main1 = new main01();
                    main1.Show();  //进入设计主界面
                    Class_user.userID = username;  //更新公共类当前用户名
                    //MessageBox.Show(Class_user.userID);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码错误！", "提示", MessageBoxButtons.OK);
                }
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {
            Form f1 = new sign_up();  // 进入注册界面
            f1.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form f2 = new adminpass();
            f2.Show();  //进入管理员登录界面
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();  // 关闭窗体
        }

        private void sign_in_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.ImageLocation = "隐藏密码.png";
            textBox2.PasswordChar = '*';
            Class_user.userID = "";  //公共类用户名置空
            //textBox1.BorderStyle = BorderStyle.None;
            //textBox2.BorderStyle = BorderStyle.None;
        }

        int hidePswTag = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            hidePswTag += 1;
            if (hidePswTag % 2 == 0)
            {
                pictureBox1.ImageLocation = "隐藏密码.png";
                textBox2.PasswordChar = '*';
            }
            else
            {
                pictureBox1.ImageLocation = "显示密码.png";
                textBox2.PasswordChar = new char();
            }
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.Font = new Font("楷体", 10.8F, FontStyle.Underline);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.Font = new Font("楷体", 10.8F, FontStyle.Regular);
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.Font = new Font("楷体", 10.8F, FontStyle.Underline);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.Font = new Font("楷体", 10.8F, FontStyle.Regular);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
