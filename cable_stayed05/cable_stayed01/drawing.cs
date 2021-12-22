using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;  //命名空间
using System.IO;

namespace cable_stayed01
{
    public partial class drawing : Form
    {
        public drawing()
        {
            InitializeComponent();
        }

        public static String local_userID;

        private void button1_Click(object sender, EventArgs e)
        {

            string Line = "DrawPic\\DrawPic.exe";
            Process p = new Process();
            //设置要启动的应用程序
            p.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = true;
            // 输出错误
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = true;
            //启动程序
            p.Start();

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(Line + " " + textBox_modelSpan.Text + " " + textBox_modelTowerHeight.Text + " " + textBox_cableDisBeam.Text + " " + textBox_cableDisTower.Text + " " + textBox_cableBeginLocTower.Text);
            p.StandardInput.WriteLine("exit");

            p.StandardInput.AutoFlush = true;
            //获取输出信息
            string strOuput = p.StandardOutput.ReadToEnd();
            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();

            pictureBox1.ImageLocation = "./temp.png";
        }
            

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_cableBeginLocTower.Text = "";
            textBox_cableDisBeam.Text = "";
            textBox_cableDisTower.Text = "";
            textBox_modelTowerHeight.Text = "";
            textBox_modelSpan.Text = "";  //清空
        }

        private void drawing_Load(object sender, EventArgs e)
        {
            local_userID = Class_user.userID;
            //主梁
            comboBox_modelSection.Items.Add("砼-边箱梁截面");
            comboBox_modelSection.Items.Add("砼-带斜撑箱形截面");
            comboBox_modelSection.Items.Add("砼-肋板式截面");
            comboBox_modelSection.Items.Add("砼-实心板截面");
            comboBox_modelSection.Items.Add("砼-箱形截面");
            comboBox_modelSection.Items.Add("钢-边箱梁截面-1");
            comboBox_modelSection.Items.Add("钢-边箱梁截面-2");
            comboBox_modelSection.Items.Add("钢-分体式箱形截面");
            comboBox_modelSection.Items.Add("钢-整体式箱形截面");
            //桥塔横向
            comboBox_modelTowerCrosswide.Items.Add("A形（1）");
            comboBox_modelTowerCrosswide.Items.Add("A形（2）");
            comboBox_modelTowerCrosswide.Items.Add("宝塔式");
            comboBox_modelTowerCrosswide.Items.Add("单柱式");
            comboBox_modelTowerCrosswide.Items.Add("倒Y形");
            comboBox_modelTowerCrosswide.Items.Add("花瓶式（1）");
            comboBox_modelTowerCrosswide.Items.Add("花瓶式（2）");
            comboBox_modelTowerCrosswide.Items.Add("门式");
            comboBox_modelTowerCrosswide.Items.Add("双柱式");
            comboBox_modelTowerCrosswide.Items.Add("钻石式");
            //桥塔纵向
            comboBox_modelTowerAlong.Items.Add("A形");
            comboBox_modelTowerAlong.Items.Add("单柱式");
            comboBox_modelTowerAlong.Items.Add("倒Y形");

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Image.FromFile(Application.StartupPath + (@"\图片示意.png"));
            pictureBox2.Image = Image.FromFile(Application.StartupPath + (@"\图片示意.png"));
            pictureBox3.Image = Image.FromFile(Application.StartupPath + (@"\图片示意.png"));
            pictureBox4.Image = Image.FromFile(Application.StartupPath + (@"\图片示意.png"));

            //提示信息显示
            ToolTip ttpSettings = new ToolTip();
            ttpSettings.InitialDelay = 100;   //延迟200毫秒提示
            ttpSettings.AutoPopDelay = 10 * 1000;  //提示信息在控件上的显示时间
            ttpSettings.ReshowDelay = 100;
            ttpSettings.ShowAlways = true;
            ttpSettings.IsBalloon = true;

            string tipOverwrite1 = "输入跨径布置，用“+”隔开，形如“100+200+100”";  //提示信息
            //ttpSettings.SetToolTip(label1, tipOverwrite1);  // 指定控件为label1
            ttpSettings.SetToolTip(textBox_modelSpan, tipOverwrite1);

            string tipOverwrite2 = "输入桥塔高度，可以只指定上塔柱高度，形如“70”，也可以指定下塔柱与上塔柱高度，形如“20+70”";  //提示信息
            ttpSettings.SetToolTip(textBox_modelTowerHeight, tipOverwrite2);  

            string tipOverwrite3 = "输入梁上索距，用一个数字表示，一般砼主梁为6~12，钢主梁为8~16";  //提示信息
            ttpSettings.SetToolTip(textBox_cableDisBeam, tipOverwrite3); 

            string tipOverwrite4 = "输入塔上索距，用一个数字表示，一般为2~2.5";  //提示信息
            ttpSettings.SetToolTip(textBox_cableDisTower, tipOverwrite4);  

            string tipOverwrite5 = "可选参数，可输入1号索在塔上的起始位置，如“3/4”表示在1号索在上塔柱3/4位置";  //提示信息
            ttpSettings.SetToolTip(textBox_cableBeginLocTower, tipOverwrite5);

            string tipOverwrite6 = "点击此按钮以生成立面图，立面图显示于左下角，请耐心等待。\r\n用户可反复调整参数以获得满意结果。";  //提示信息
            ttpSettings.SetToolTip(button_drawing, tipOverwrite6);

            string tipOverwrite7 = "点击此按钮以保存立面图的svg文件，该类型文件可转换为dwg文件";  //提示信息
            ttpSettings.SetToolTip(button_saveModel, tipOverwrite7);

            string tipOverwrite8 = "点击此按钮以将建模信息上传至云端";  //提示信息
            ttpSettings.SetToolTip(button_upload, tipOverwrite8);

            string tipOverwrite9 = "点击此按钮以清空立面绘制参数";  //提示信息
            ttpSettings.SetToolTip(button_clear, tipOverwrite9);

            string tipOverwrite10 = "可在此处键入文本以添加模型备注";  //提示信息
            ttpSettings.SetToolTip(textBox_remark, tipOverwrite10);

            string tipOverwrite11 = "下拉选择主梁截面类型";  //提示信息
            ttpSettings.SetToolTip(comboBox_modelSection, tipOverwrite11);

            string tipOverwrite12 = "下拉选择桥塔横向形式";  //提示信息
            ttpSettings.SetToolTip(comboBox_modelTowerCrosswide, tipOverwrite12);

            string tipOverwrite13 = "下拉选择桥塔纵向形式";  //提示信息
            ttpSettings.SetToolTip(comboBox_modelTowerAlong, tipOverwrite13);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = Image.FromFile(Application.StartupPath + (@"\pic\主梁\" + comboBox_modelSection.Text + ".png"));  //显示图片
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.Image = Image.FromFile(Application.StartupPath + (@"\pic\索塔横桥向\" + comboBox_modelTowerCrosswide.Text + ".png"));
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.Image = Image.FromFile(Application.StartupPath + (@"\pic\索塔纵桥向\" + comboBox_modelTowerAlong.Text + ".png"));
        }

        static string mystr = @"Data Source=47.102.209.81;Initial Catalog=cableStayedBridge;User ID=NanxiChen;Password=123456";
        SqlConnection myconn = new SqlConnection(mystr);

        private void button_upload_Click(object sender, EventArgs e)
        {
            DateTime currentTime = new DateTime();      //创建一个DateTime类型变量currentTime， DateTime 为类型，currentTime为变量名
            currentTime = System.DateTime.Now;
            //MessageBox.Show(currentTime.ToString());
            //String local_userID = "";  //定义Class_user类
            //local_userID = Class_user.userID;  //从公共类获取当前用户名
            //MessageBox.Show(local_userID);
            //local_userID = "abc";


            String modelID = "";  //之后通过调用sql sever存储过程获取
            SqlCommand mycmd = new SqlCommand("dbo.modelNumAll", myconn);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter numOut = new SqlParameter("@temp_modelNum", SqlDbType.Int, 4);   //输出参数
            mycmd.Parameters.Add(numOut);
            numOut.Direction = ParameterDirection.Output;
            
            //int num;
            //myconn.Open();
            //    num = Convert.ToInt32(mycmd.ExecuteScalar());
            //myconn.Close();
            //num = num + 1;
            ////MessageBox.Show(num.ToString());
            //modelID = "m"+ num.ToString().PadLeft(3,'0');  //模型编号，这个不行，总返回num=0

            int num;
            myconn.Open();
            //num = Convert.ToInt32(mycmd.ExecuteScalar());
            mycmd.ExecuteNonQuery();
            if (numOut.Value.ToString().Length == 0 )  //判断数据库中表是否为空
            {
                num = 0;
            }
            else
            {
                num = Convert.ToInt32(numOut.Value);
            }
            myconn.Close();
            num = num + 1;
            modelID = "m" + num.ToString().PadLeft(3, '0');  //模型编号
            //modelID = "m001";
            //MessageBox.Show(modelID.ToString());

            String d_remark = "";
            String modelSpan = textBox_modelSpan.Text.Trim();
           // String modelTowerHeight = textBox_modelTowerHeight.Text.Trim();
            String d_modelTowerCrosswide = "";
            String d_modelSection = "";
            String d_modelTowerAlong = "";
            String cableDisBeam = textBox_cableDisBeam.Text.Trim();
            String cableDisTower = textBox_cableDisTower.Text.Trim();
            String d_cableBeginLocTower = "";


            string[] sArray =textBox_modelTowerHeight.Text.Trim().Split('+');
            String modelTowerHeight = sArray[sArray.Length - 1];
            //MessageBox.Show(modelTowerHeight);


            if (textBox_remark.Text == "")
            {
                d_remark = "NULL";
            }
            else
            {
                d_remark = "'" + textBox_remark.Text + "'";
            }

            if (comboBox_modelTowerCrosswide.Text == "")
            {
                d_modelTowerCrosswide = "NULL";
            }
            else
            {
                d_modelTowerCrosswide = "'" + comboBox_modelTowerCrosswide.Text + "'";
            }

            if (comboBox_modelSection.Text == "")
            {
                d_modelSection = "NULL";
            }
            else
            {
                d_modelSection = "'" + comboBox_modelSection.Text + "'";
            }

            if (comboBox_modelTowerAlong.Text == "")
            {
                d_modelTowerAlong = "NULL";
            }
            else
            {
                d_modelTowerAlong = "'" + comboBox_modelTowerAlong.Text + "'";
            }

            if (textBox_cableBeginLocTower.Text.Trim() == "")
            {
                d_cableBeginLocTower = "NULL";
            }
            else
            {
                d_cableBeginLocTower = "'" + textBox_cableBeginLocTower.Text.Trim() + "'";
            }


            String cmd1 = "";

            cmd1 = "insert into bridgeModel values('" + modelID + "','" + local_userID + "'," + "convert(datetime,'" + currentTime.ToString() + "',20)," + d_remark + ",'" + modelSpan + "','" + modelTowerHeight + "'," + d_modelTowerCrosswide + "," + d_modelSection + "," + d_modelTowerAlong + ",'" + cableDisBeam + "','" + cableDisTower + "'," + d_cableBeginLocTower + ")";  //插入数据
            
            //MessageBox.Show(cmd1);
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
            MessageBox.Show("模型上传成功！");

            //datagridview测试
            //string mystr1 = "select * from bridgeModel";
            //SqlDataAdapter myadapter1 = new SqlDataAdapter(mystr1, myconn);
            //DataSet mydataset1 = new DataSet();
            //myadapter1.Fill(mydataset1, "model");
            //dataGridView1.DataSource = mydataset1.Tables["model"];
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void button_saveModel_Click(object sender, EventArgs e)
        {
            String filename;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SVG可缩放矢量图格式(*.svg)|*.svg|PNG可移植网络形状格式(*.png)|*.png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog.FileName;
                String Line;
                if (filename.EndsWith(".svg"))
                {
                    Line = "copy /Y temp.svg " + filename;
                }
                else
                {
                    Line = "copy /Y temp.png " + filename;
                }

                
                Process p = new Process();
                //设置要启动的应用程序
                p.StartInfo.FileName = "cmd.exe";
                //是否使用操作系统shell启动
                p.StartInfo.UseShellExecute = false;
                // 接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardInput = true;
                //输出信息
                p.StartInfo.RedirectStandardOutput = true;
                // 输出错误
                p.StartInfo.RedirectStandardError = true;
                //不显示程序窗口
                p.StartInfo.CreateNoWindow = true;
                //启动程序
                p.Start();

                //向cmd窗口发送输入信息
                p.StandardInput.WriteLine(Line);
                p.StandardInput.WriteLine("exit");
                p.StandardInput.AutoFlush = true;
                //获取输出信息
                string strOuput = p.StandardOutput.ReadToEnd();
                //等待程序执行完退出进程
                p.WaitForExit();
                p.Close();
            }
        }

    }
}
