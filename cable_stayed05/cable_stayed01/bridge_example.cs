using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //命名空间
using System.IO;
using System.Threading;

namespace cable_stayed01
{
    public partial class bridge_example : Form
    {
        public bridge_example()
        {
            InitializeComponent();
        }

        //创建数据库连接字符串
        static string strConn = "Data Source =47.102.209.81;Initial Catalog = cableStayedBridge; User ID = NanxiChen;Password=123456";
        //创建SqlConnection对象
        SqlConnection connection = new SqlConnection(strConn);
        BindingSource mybind = new BindingSource(); //数据绑定
        static String bridgeID="";

        public void matchingImage(string bridgeID)
        {
            try
            {

                //打开数据库连接
                connection.Open();


                //创建SQL语句
                string sql = "SELECT bridgeImg FROM bridge WHERE bridgeID = '" + bridgeID + "'";
                //创建SqlCommand对象
                SqlCommand command = new SqlCommand(sql, connection);
                //创建DataAdapter对象
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                //创建DataSet对象
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "BLOBTest");

                Byte[] mybyte = new byte[0];
                mybyte = (Byte[])(dataSet.Tables["BLOBTest"].Rows[0]["bridgeImg"]);
                MemoryStream ms = new MemoryStream(mybyte);
                pictureBox1.Image = Image.FromStream(ms);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_seeComment.Text = "";
            String span = textBox_matchingSpan.Text;
            string[] sArray = span.Split('+');
            int main_span = 0;  //主跨
            foreach (string i in sArray)
            {
                if (Convert.ToInt32(i) > main_span)
                {
                    main_span = Convert.ToInt32(i);
                }

            }
            String towerHeight = textBox_matchingTowerHeight.Text; //塔高
            string mystr1 = "select * from dbo.matchingBridge(" + main_span + "," + towerHeight + ")"; //填入跨径布置、塔高
            SqlDataAdapter myadapter1 = new SqlDataAdapter(mystr1, connection);
            DataSet mydataset1 = new DataSet();
            myadapter1.Fill(mydataset1, "bridge");
            int index = this.comboBox_matchingResults.SelectedIndex;
            bridgeID = mydataset1.Tables["bridge"].Rows[index].ItemArray[0].ToString();  //static变量
            matchingImage(bridgeID);  //显示图片

            string mystr2 = "select * from bridge where bridgeID='" + bridgeID + "'";
            SqlDataAdapter myadapter2 = new SqlDataAdapter(mystr2, connection);
            DataSet mydataset2 = new DataSet();
            myadapter2.Fill(mydataset2, "bridgeInfo");
            mybind.DataSource = mydataset2;
            mybind.DataMember = "bridgeInfo";

            //清除绑定
            textBox_bridgeName.DataBindings.Clear();
            textBox_builtYear.DataBindings.Clear();
            textBox_briefIntro.DataBindings.Clear();
            textBox_materialBeam.DataBindings.Clear();
            textBox_materialTower.DataBindings.Clear();
            textBox_section.DataBindings.Clear();
            textBox_span.DataBindings.Clear();
            textBox_towerCrosswide.DataBindings.Clear();
            textBox_towerHeight.DataBindings.Clear();

            //重新绑定
            textBox_bridgeName.DataBindings.Add(new Binding("Text", mybind, "bridgeName", true));
            textBox_builtYear.DataBindings.Add(new Binding("Text", mybind, "builtYear", true));
            textBox_briefIntro.DataBindings.Add(new Binding("Text", mybind, "briefIntro", true));
            textBox_materialBeam.DataBindings.Add(new Binding("Text", mybind, "materialBeam", true));
            textBox_materialTower.DataBindings.Add(new Binding("Text", mybind, "materialTower", true));
            textBox_section.DataBindings.Add(new Binding("Text", mybind, "section", true));
            textBox_span.DataBindings.Add(new Binding("Text", mybind, "span", true));
            textBox_towerCrosswide.DataBindings.Add(new Binding("Text", mybind, "towerCrosswide", true));
            textBox_towerHeight.DataBindings.Add(new Binding("Text", mybind, "towerHeight", true));
        }

        private void textBox_matchingTowerHeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox_seeComment.Text = "";
                String s = textBox_matchingSpan.Text;
                string[] sArray = s.Split('+');
                int main_span = 0;  //主跨
                foreach (string i in sArray)
                {
                    if (Convert.ToInt32(i) > main_span)
                    {
                        main_span = Convert.ToInt32(i);
                    }

                }
                String towerHeight = textBox_matchingTowerHeight.Text; //塔高
                string mystr1 = "select * from dbo.matchingBridge(" + main_span + "," + towerHeight + ")"; //独塔？
                SqlDataAdapter myadapter1 = new SqlDataAdapter(mystr1, connection);
                DataSet mydataset1 = new DataSet();
                myadapter1.Fill(mydataset1, "bridge");
                comboBox_matchingResults.DataSource = mydataset1.Tables["bridge"];
                comboBox_matchingResults.DisplayMember = "bridgeName";
                int index = this.comboBox_matchingResults.SelectedIndex;
                bridgeID = mydataset1.Tables["bridge"].Rows[index].ItemArray[0].ToString();
                matchingImage(bridgeID);  //显示图片

                string mystr2 = "select * from bridge where bridgeID='" + bridgeID + "'";
                SqlDataAdapter myadapter2 = new SqlDataAdapter(mystr2, connection);
                DataSet mydataset2 = new DataSet();
                myadapter2.Fill(mydataset2, "bridgeInfo");
                mybind.DataSource = mydataset2;
                mybind.DataMember = "bridgeInfo";
                textBox_bridgeName.Text = mydataset2.Tables["bridgeInfo"].Rows[0].ItemArray[0].ToString();

                //清除绑定
                textBox_bridgeName.DataBindings.Clear();
                textBox_builtYear.DataBindings.Clear();
                textBox_briefIntro.DataBindings.Clear();
                textBox_materialBeam.DataBindings.Clear();
                textBox_materialTower.DataBindings.Clear();
                textBox_section.DataBindings.Clear();
                textBox_span.DataBindings.Clear();
                textBox_towerCrosswide.DataBindings.Clear();
                textBox_towerHeight.DataBindings.Clear();

                //重新绑定
                textBox_bridgeName.DataBindings.Add(new Binding("Text", mybind, "bridgeName", true));
                textBox_builtYear.DataBindings.Add(new Binding("Text", mybind, "builtYear", true));
                textBox_briefIntro.DataBindings.Add(new Binding("Text", mybind, "briefIntro", true));
                textBox_materialBeam.DataBindings.Add(new Binding("Text", mybind, "materialBeam", true));
                textBox_materialTower.DataBindings.Add(new Binding("Text", mybind, "materialTower", true));
                textBox_section.DataBindings.Add(new Binding("Text", mybind, "section", true));
                textBox_span.DataBindings.Add(new Binding("Text", mybind, "span", true));
                textBox_towerCrosswide.DataBindings.Add(new Binding("Text", mybind, "towerCrosswide", true));
                textBox_towerHeight.DataBindings.Add(new Binding("Text", mybind, "towerHeight", true));
            }
            
            
        }

        private void bridge_example_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Image.FromFile(Application.StartupPath + (@"\图片示意.png"));

            //提示信息显示
            ToolTip ttpSettings = new ToolTip();
            ttpSettings.InitialDelay = 100;   //延迟200毫秒提示
            ttpSettings.AutoPopDelay = 10 * 1000;  //提示信息在控件上的显示时间
            ttpSettings.ReshowDelay = 100;
            ttpSettings.ShowAlways = true;
            ttpSettings.IsBalloon = true;

            string tipOverwrite1 = "输入跨径布置，用“+”隔开，形如“100+200+100”";  //提示信息
            ttpSettings.SetToolTip(textBox_matchingSpan, tipOverwrite1);  // 指定控件为textBox_matchingSpan

            string tipOverwrite2 = "输入上塔柱高度，输入完按enter，\r\n程序将自动查询与模型信息匹配的案例资料";  //提示信息
            ttpSettings.SetToolTip(textBox_matchingTowerHeight, tipOverwrite2);  

            string tipOverwrite3 = "点击此按钮以刷新评论";  //提示信息
            ttpSettings.SetToolTip(button_seeComment, tipOverwrite3);

            string tipOverwrite4 = "点击此按钮以上传评论，\r\n想看到刚上传的评论需要点击加载评论按钮刷新哦~";  //提示信息
            ttpSettings.SetToolTip(button_comment, tipOverwrite4);

            string tipOverwrite5 = "可在此处键入自己的评论哦~";  //提示信息
            ttpSettings.SetToolTip(textBox_comment, tipOverwrite5);

            string tipOverwrite6 = "下拉以选择不同匹配结果查看";  //提示信息
            ttpSettings.SetToolTip(comboBox_matchingResults, tipOverwrite6); 

        }

        private void button_comment_Click(object sender, EventArgs e)
        {
            String userID = Class_user.userID;  // 获取当前用户名
            userID = "abc";
            //userID = "NanxiChen";
            DateTime currentTime = new DateTime();      //创建一个DateTime类型变量currentTime， DateTime 为类型，currentTime为变量名
            currentTime = System.DateTime.Now;

            if (textBox_comment.Text == "")
            {
                MessageBox.Show("不能添加空评论！");
            }
            else
            {
                //往数据库中添加用户评论
                String cmd1 = "insert into userComment values('" + userID + "','" + bridgeID + "','" + textBox_comment.Text + "'," + "convert(datetime,'" + currentTime.ToString() + "',20))";
                //MessageBox.Show(cmd1);
                SqlCommand mycmd1 = new SqlCommand(cmd1, connection);  // 显式连接
                connection.Open();
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
                connection.Close();
                MessageBox.Show("评论添加成功！");
                textBox_comment.Text = "";  //清空
            }
        }

        private void button_seeComment_Click(object sender, EventArgs e)
        {
            //加载桥梁对应的评论
            textBox_seeComment.Text = "";
            String mystr3 = "select * from userComment where bridgeID='"+bridgeID+"'"; 
            SqlDataAdapter myadapter3 = new SqlDataAdapter(mystr3, connection);
            DataSet mydataset3 = new DataSet();
            myadapter3.Fill(mydataset3, "bridgeComment");
            int rowsNum = mydataset3.Tables["bridgeComment"].Rows.Count;  //获取表格行数
            for (int i = 0; i < rowsNum; i++)
            {
                String time = mydataset3.Tables["bridgeComment"].Rows[i].ItemArray[3].ToString();
                String temp_userID = mydataset3.Tables["bridgeComment"].Rows[i].ItemArray[0].ToString();
                String temp_comment = mydataset3.Tables["bridgeComment"].Rows[i].ItemArray[2].ToString();
                String commentString = "---------------------------\r\n评论时间：" + time + "\r\n用户名：" + temp_userID + "\r\n内容：" + temp_comment + "\r\n";
                textBox_seeComment.Text += commentString;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        
    }
}
