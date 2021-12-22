using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cable_stayed01
{
    public partial class START : Form
    {
        public START()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form f1=new sign_in();
            f1.Show();   //进入登录界面
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();  //关闭窗体
        }

        private void START_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "http://47.102.209.81:8080/Docs/preview/cableStayedHelp.html");
        }
    }
}
