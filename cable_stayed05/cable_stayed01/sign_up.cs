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
    public partial class sign_up : Form
    {
        public sign_up()
        {
            InitializeComponent();
        }

        static string mystr = @"Data Source=47.102.209.81;Initial Catalog=cableStayedBridge;User ID=NanxiChen;Password=123456";
        SqlConnection myconn = new SqlConnection(mystr);

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text.Trim();
            String password1 = textBox2.Text.Trim();
            String password2 = textBox3.Text.Trim();
            String cmd1 = "insert into bridgeDesigner values('" + username + "','" + password1 + "')";  //插入数据
            //MessageBox.Show(cmd1);
            String cmd2 = "select userID from bridgeDesigner where userID ='"+username+"'";  // 查询该用户名是否已经存在
            SqlCommand mycmd2 = new SqlCommand(cmd2, myconn);
            string name_exist;
            myconn.Open();
            {
                name_exist = Convert.ToString(mycmd2.ExecuteScalar());
            }
            myconn.Close();

            if (name_exist == username)
            {
                MessageBox.Show("该用户名已存在！");
            }
            else
            {
                if (password1 == password2)
                {
                    SqlCommand mycmd1 = new SqlCommand(cmd1, myconn);  // 显式连接
                    myconn.Open();
                    {
                        try
                        {
                            mycmd1.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    myconn.Close();
                    MessageBox.Show("注册成功！\r\n您的用户名是：" + username + "\r\n密码是：" + password1);
                }
                else
                {
                    MessageBox.Show("两次输入的密码不一致，请重新输入");
                }
            }
            //Form f1 = new main();
            //f1.Show();  //进入设计主界面
            this.Close();  //关闭注册界面，用户需要在登录界面登录

            
        }


        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();  //关闭窗体
        }

        private void sign_up_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.ImageLocation = "隐藏密码.png";
            textBox2.PasswordChar = '*';
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.ImageLocation = "隐藏密码.png";
            textBox3.PasswordChar = '*';
        }

        int hidePswTag1 = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            hidePswTag1 += 1;
            if (hidePswTag1 % 2 == 0)
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

        int hidePswTag2 = 0;

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            hidePswTag2 += 1;
            if (hidePswTag2 % 2 == 0)
            {
                pictureBox2.ImageLocation = "隐藏密码.png";
                textBox3.PasswordChar = '*';
            }
            else
            {
                pictureBox2.ImageLocation = "显示密码.png";
                textBox3.PasswordChar = new char();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            label5.Text = "";
            String username = textBox1.Text.Trim();
            String cmd2 = "select userID from bridgeDesigner where userID ='" + username + "'";  // 查询该用户名是否已经存在
            SqlCommand mycmd2 = new SqlCommand(cmd2, myconn);
            string name_exist;
            myconn.Open();
            {
                name_exist = Convert.ToString(mycmd2.ExecuteScalar());
            }
            myconn.Close();

            if (name_exist == username)
            {
                label5.Text = "该用户名已存在！";
            }
            if (username == "")
            {
                label5.Text = "用户名不能为空！";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            label6.Text = "";
            String psw1 = textBox2.Text.Trim();
            if (psw1.Length < 8)
            {
                label6.Text = "密码长度必须大于8(不含空格)";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            label7.Text = "";
            String psw1 = textBox2.Text.Trim();
            String psw2 = textBox3.Text.Trim();
            if (psw2 != psw1)
            {
                label7.Text = "两次输入的密码不一致！";
            }
        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
            label7.Text = "";
            String psw1 = textBox2.Text.Trim();
            String psw2 = textBox3.Text.Trim();
            if (psw2 != psw1)
            {
                label7.Text = "两次输入的密码不一致！";
            }
        }

       

    }
}
