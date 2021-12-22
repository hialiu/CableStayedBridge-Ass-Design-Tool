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
using WindowsFormsApplication3;  //要合并的项目的命名空间


namespace cable_stayed01
{
    public partial class adminpass : Form
    {
        public adminpass()
        {
            InitializeComponent();
        }

        static string mystr = @"Data Source=47.102.209.81;Initial Catalog=cableStayedBridge;User ID=NanxiChen;Password=123456";
        SqlConnection myconn = new SqlConnection(mystr);

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text.Trim();
            String password = textBox2.Text.Trim();
            string mystr1 = "select userID,psw from bridgeAdmin where userID='" + username + "'";
            SqlDataAdapter myadapter1 = new SqlDataAdapter(mystr1, myconn);
            DataSet mydataset1 = new DataSet();
            myadapter1.Fill(mydataset1, "user");
            if (mydataset1.Tables["user"].Rows.Count == 0)    //Rows.Count多少行
            {
                MessageBox.Show("该管理员账号不存在", "提示", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (password == mydataset1.Tables["user"].Rows[0].ItemArray[1].ToString())
                {
                    //MessageBox.Show("管理员身份验证成功", "提示", MessageBoxButtons.OK);
                    BackStageForm f1 = new BackStageForm();
                    this.Close();
                    f1.Show(); // 进入管理员界面
                    
                }
                else
                {
                    MessageBox.Show("管理员密钥错误！", "提示", MessageBoxButtons.OK);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();   //清除内容
            textBox1.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();  //关闭窗体
        }

        private void adminpass_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
