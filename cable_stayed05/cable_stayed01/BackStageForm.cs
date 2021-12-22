using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication3
{
    public partial class BackStageForm : Form
    {
        public BackStageForm()
        {
            InitializeComponent();
        }

        private string filename = string.Empty;//用于获取图片
        int ifImgChanged = 0; // 用来判断是否进行了获取图片的操作

        private void button1_Click(object sender, EventArgs e)//插入桥数据
        {
             try
            {
                string strConn = "Data Source =47.102.209.81;Initial Catalog = cableStayedBridge; User ID = NanxiChen;Password=123456";
                SqlConnection connection = new SqlConnection(strConn);


                string bridgeID = textBox1.Text.ToString();
                string d_bridgeName = "";
                string d_builtYear = "";
                //string = textBox4.Text.ToString();
                string span = textBox5.Text.ToString();
                string towerHeight = textBox6.Text.ToString();
                string d_towerCrosswide = "";
                string d_section = "";
                string d_materialTower = "";
                string d_materialBeam = "";
                string d_briefIntro = "";
                //获取输入的桥数据

                if (textBox2.Text.Trim() == "")
                {
                    d_bridgeName = "NULL";
                }
                else
                {
                    d_bridgeName = "'" + textBox2.Text.Trim() + "'";
                }

                if (textBox3.Text.Trim() == "")
                {
                    d_builtYear = "NULL";
                }
                else
                {
                    d_builtYear = "'" + textBox3.Text.Trim() + "'";
                }

                if (comboBox1.Text.Trim() == "")
                {
                    d_towerCrosswide = "NULL";
                }
                else
                {
                    d_towerCrosswide = "'" + comboBox1.Text.Trim() + "'";
                }

                if (comboBox2.Text.Trim() == "")
                {
                    d_section = "NULL";
                }
                else
                {
                    d_section = "'" + comboBox2.Text.Trim() + "'";
                }

                if (comboBox3.Text.Trim() == "")
                {
                    d_materialTower = "NULL";
                }
                else
                {
                    d_materialTower = "'" + comboBox3.Text.Trim() + "'";
                }

                if (comboBox4.Text.Trim() == "")
                {
                    d_materialBeam = "NULL";
                }
                else
                {
                    d_materialBeam = "'" + comboBox4.Text.Trim() + "'";
                }

                if (textBox11.Text.Trim() == "")
                {
                    d_briefIntro = "NULL";
                }
                else
                {
                    d_briefIntro = "'" + textBox11.Text.Trim() + "'";
                }



                string sql =
                    "INSERT INTO bridge(bridgeId,bridgeName,builtYear,span,towerHeight,towerCrosswide,section,materialTower,materialBeam,briefIntro,bridgeImg) VALUES("
                    + "'" + bridgeID + "'," + d_bridgeName + "," + d_builtYear + ",'" + span + "','" + towerHeight + "'," + d_towerCrosswide + "," + d_section + "," + d_materialTower + "," + d_materialBeam + "," + d_briefIntro + ",@blobdata)";
                SqlCommand command = new SqlCommand(sql, connection);
                string picturePath = filename;
                //字符串功能：将获取的数据放入数据库

                FileStream fs = new FileStream(picturePath, FileMode.Open, FileAccess.Read);
                Byte[] mybyte = new byte[fs.Length];
                fs.Read(mybyte, 0, mybyte.Length);
                fs.Close();
                SqlParameter prm = new SqlParameter("@blobdata", SqlDbType.VarBinary, mybyte.Length);
                prm.Value = mybyte;
                command.Parameters.Add(prm);
                //将图片转化为二进制方便放入数据库

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("存储成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             formInit();
        }


        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)//选择桥名获取桥数据
        {
            string bridgeName = comboBox5.Text.ToString();
            //获取所选择的桥名

            string strConn = "Data Source =47.102.209.81;Initial Catalog = cableStayedBridge; User ID = NanxiChen;Password=123456";
            SqlConnection connection = new SqlConnection(strConn);


            string mystr1 = "SELECT bridgeID FROM bridge";
            SqlDataAdapter myadapter1 = new SqlDataAdapter(mystr1, connection);
            DataSet mydataset1 = new DataSet();
            myadapter1.Fill(mydataset1, "bridge");
            int index = this.comboBox5.SelectedIndex;
            string bridgeID = mydataset1.Tables["bridge"].Rows[index].ItemArray[0].ToString();
            //通过桥名获取桥ID

            string mystr2 = "SELECT * FROM bridge WHERE bridgeID = '" + bridgeID +"'";
            SqlDataAdapter myadapter2 = new SqlDataAdapter(mystr2, connection);
            DataSet mydataset2 = new DataSet();
            myadapter2.Fill(mydataset2, "bridgeInfo");
            //通过桥ID获取桥数据放入"bridgeInfo"

            textBox1.Text = mydataset2.Tables["bridgeInfo"].Rows[0].ItemArray[0].ToString();
            textBox2.Text = mydataset2.Tables["bridgeInfo"].Rows[0].ItemArray[1].ToString();
            textBox3.Text = mydataset2.Tables["bridgeInfo"].Rows[0].ItemArray[2].ToString();
            //textBox4.Text = mydataset2.Tables["bridgeInfo"].Rows[0].ItemArray[3].ToString();
            textBox5.Text = mydataset2.Tables["bridgeInfo"].Rows[0].ItemArray[3].ToString();
            textBox6.Text = mydataset2.Tables["bridgeInfo"].Rows[0].ItemArray[4].ToString();
            comboBox1.Text = mydataset2.Tables["bridgeInfo"].Rows[0].ItemArray[5].ToString();
            comboBox2.Text = mydataset2.Tables["bridgeInfo"].Rows[0].ItemArray[6].ToString();
            comboBox3.Text = mydataset2.Tables["bridgeInfo"].Rows[0].ItemArray[7].ToString();
            comboBox4.Text = mydataset2.Tables["bridgeInfo"].Rows[0].ItemArray[8].ToString();
            textBox11.Text = mydataset2.Tables["bridgeInfo"].Rows[0].ItemArray[9].ToString();
            Byte[] mybyte = new byte[0];
            mybyte = (Byte[])(mydataset2.Tables["bridgeInfo"].Rows[0]["bridgeImg"]);
            MemoryStream ms = new MemoryStream(mybyte);
            pictureBox1.Image = Image.FromStream(ms);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            //显示"bridgeInfo"中的桥数据
        }
        public void formInit()
        {
            string strConn = "Data Source =47.102.209.81;Initial Catalog = cableStayedBridge; User ID = NanxiChen;Password=123456";
            SqlConnection connection = new SqlConnection(strConn);
            //连接数据库

            string mystr1 = "SELECT bridgeName FROM bridge";
            SqlDataAdapter myadapter1 = new SqlDataAdapter(mystr1, connection);
            DataSet mydataset1 = new DataSet();
            myadapter1.Fill(mydataset1, "bridge");
            comboBox5.DataSource = mydataset1.Tables["bridge"];
            comboBox5.DisplayMember = "bridgeName";
            //数据库获取桥名放入下拉框

            comboBox1.Items.Add("A");
            comboBox1.Items.Add("钻石");
            comboBox1.Items.Add("H");
            comboBox1.Items.Add("倒Y");
            comboBox1.Items.Add("独柱");

            comboBox2.Items.Add("箱形");
            comboBox2.Items.Add("分离式箱形");
            comboBox2.Items.Add("分离实主梁");
            comboBox2.Items.Add("桁架");

            comboBox3.Items.Add("钢");
            comboBox3.Items.Add("砼");

            comboBox4.Items.Add("钢");
            comboBox4.Items.Add("砼");
            comboBox4.Items.Add("混合");
            comboBox4.Items.Add("叠合");
            //一些桥参数的下拉框内容

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            //textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            comboBox1.Text = null;
            comboBox2.Text = null;
            comboBox3.Text = null;
            comboBox4.Text = null;
            textBox11.Text = null;
            pictureBox1.ImageLocation = "图片示意.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.Cursor = Cursors.Hand;
            //打开时清空内容
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //textBox1.BackColor = ColorTranslator.FromHtml("#AFB7DB");
            //comboBox1.BackColor = ColorTranslator.FromHtml("#AFB7DB");
            formInit();
            this.comboBox5.IntegralHeight = false;
            this.comboBox5.MaxDropDownItems = 15;
            //this.BackgroundImage = Image.FromFile("bgblur.png");
        }

        private void button3_Click(object sender, EventArgs e)//更新桥数据
        {
            DialogResult result = MessageBox.Show("确认要提交更改吗？", "更新确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string strConn = "Data Source =47.102.209.81;Initial Catalog = cableStayedBridge; User ID = NanxiChen;Password=123456";
                    SqlConnection connection = new SqlConnection(strConn);


                    string bridgeID = textBox1.Text.ToString();
                    string bridgeName = textBox2.Text.ToString();
                    string builtYear = textBox3.Text.ToString();
                    //string mainSpan = textBox4.Text.ToString();
                    string span = textBox5.Text.ToString();
                    string towerHeight = textBox6.Text.ToString();
                    string towerCrosswide = comboBox1.Text.ToString();
                    string section = comboBox2.Text.ToString();
                    string materialTower = comboBox3.Text.ToString();
                    string materialBeam = comboBox4.Text.ToString();
                    string briefIntro = textBox11.Text.ToString();
                    //获取更新后的桥数据

                    string sql =
                        "UPDATE bridge SET bridgeName = '" + bridgeName + "',builtYear = '" + builtYear + "',span = '" + span + "',towerHeight = '" + towerHeight + "',towerCrosswide = '" + towerCrosswide + "',section = '" + section + "',materialTower = '" + materialTower + "',materialBeam = '" + materialBeam + "',briefIntro = '" + briefIntro + "' WHERE bridgeID = '" + bridgeID + "'";
                    SqlCommand command = new SqlCommand(sql, connection);
                    //字符串功能：更新桥数据（除图片）

                    string picturePath = filename;
                    if (ifImgChanged == 1)
                    {
                        //判断是否更新图片
                        string sql1 = "UPDATE bridge SET bridgeImg = @blobdata WHERE bridgeID = '" + bridgeID + "'";
                        SqlCommand command1 = new SqlCommand(sql1, connection);
                        FileStream fs = new FileStream(picturePath, FileMode.Open, FileAccess.Read);
                        Byte[] mybyte = new byte[fs.Length];
                        fs.Read(mybyte, 0, mybyte.Length);
                        fs.Close();
                        SqlParameter prm = new SqlParameter("@blobdata", SqlDbType.VarBinary, mybyte.Length);
                        prm.Value = mybyte;
                        command1.Parameters.Add(prm);
                        connection.Open();
                        command1.ExecuteNonQuery();
                        connection.Close();
                    }

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("更新成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                formInit();
            }
            else
            {
                return;
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = this.openFileDialog1.FileName;//获取图片地址
                pictureBox1.ImageLocation = openFileDialog1.FileName;//显示该地址的图片给用户
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;//更改图片格式
                ifImgChanged = 1;//表示进行了获取图片的操作
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("确认要删除数据吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string bridgeName = comboBox5.Text.ToString();
                //获取所选择的桥名

                string strConn = "Data Source =47.102.209.81;Initial Catalog = cableStayedBridge; User ID = NanxiChen;Password=123456";
                SqlConnection connection = new SqlConnection(strConn);


                string mystr1 = "SELECT bridgeID FROM bridge";
                SqlDataAdapter myadapter1 = new SqlDataAdapter(mystr1, connection);
                DataSet mydataset1 = new DataSet();
                myadapter1.Fill(mydataset1, "bridge");
                int index = this.comboBox5.SelectedIndex;
                string bridgeID = mydataset1.Tables["bridge"].Rows[index].ItemArray[0].ToString();
                //通过桥名获取桥ID

                string mysql = "DELETE FROM bridge WHERE bridgeID = '" + bridgeID + "'";
                SqlCommand mycmd = new SqlCommand(mysql, connection);

                connection.Open();
                mycmd.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("删除成功");
                formInit();
            }
            else
            {
                return;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }


        //private void BackStageForm_Paint(object sender, PaintEventArgs e)
        //{
        //    Graphics g = e.Graphics;
        //    Color FColor = ColorTranslator.FromHtml("#454F5C");
        //    Color TColor = ColorTranslator.FromHtml("#E9EEF5");
        //    Brush b = new LinearGradientBrush(this.ClientRectangle, TColor, FColor, LinearGradientMode.Vertical);
        //    g.FillRectangle(b, this.ClientRectangle);
        //}

        private void BackStageForm_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
