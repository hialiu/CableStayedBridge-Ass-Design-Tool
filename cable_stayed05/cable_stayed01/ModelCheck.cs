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
using System.Drawing.Drawing2D;
using System.IO;
using cable_stayed01;

namespace WindowsFormsApplication3
{
    public partial class ModelCheck : Form
    {
        public ModelCheck()
        {
            InitializeComponent();
        }

        string userID = Class_user.userID;
        static string strConn = "Data Source =47.102.209.81;Initial Catalog = cableStayedBridge; User ID = NanxiChen;Password=123456";
        SqlConnection connection = new SqlConnection(strConn);
        int ifLoad = 0;


        public void FormInit()
        {
            string mystr = "SELECT modelID FROM bridgeModel WHERE userID = '" + userID + "'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(mystr, strConn);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "bridgeModel");
            comboBox1.DataSource = dataSet.Tables["bridgeModel"];
            comboBox1.DisplayMember = "modelID";
            comboBox1.IntegralHeight = false;
            comboBox1.MaxDropDownItems = 5;
            textBox1.Text = null;
        }

        private void ModelCheck_Load(object sender, EventArgs e)
        {
            FormInit();
            ifLoad = 1;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ifLoad == 0)
            {
                return;
            }
            string mystr = "SELECT * FROM bridgeModel WHERE userID = '" + userID + "' and modelID = '" + comboBox1.Text + "'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(mystr, strConn);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "bridgeModel");

            string modelID = dataSet.Tables["bridgeModel"].Rows[0].ItemArray[0].ToString().Trim();
            string modelUserID = dataSet.Tables["bridgeModel"].Rows[0].ItemArray[1].ToString().Trim();
            string modifyDate = dataSet.Tables["bridgeModel"].Rows[0].ItemArray[2].ToString().Trim();
            string remark = dataSet.Tables["bridgeModel"].Rows[0].ItemArray[3].ToString().Trim();
            string modelSpan = dataSet.Tables["bridgeModel"].Rows[0].ItemArray[4].ToString().Trim();
            string modelTowerHeight = dataSet.Tables["bridgeModel"].Rows[0].ItemArray[5].ToString().Trim();
            string modelTowerCrosswide = dataSet.Tables["bridgeModel"].Rows[0].ItemArray[6].ToString().Trim();
            string modelSection = dataSet.Tables["bridgeModel"].Rows[0].ItemArray[7].ToString().Trim();
            string modelTowerAlong = dataSet.Tables["bridgeModel"].Rows[0].ItemArray[8].ToString().Trim();
            string cableDisBeam = dataSet.Tables["bridgeModel"].Rows[0].ItemArray[9].ToString().Trim();
            string cableDisTower = dataSet.Tables["bridgeModel"].Rows[0].ItemArray[10].ToString().Trim();
            string cableBeginLocTower = dataSet.Tables["bridgeModel"].Rows[0].ItemArray[11].ToString().Trim();

            if (cableBeginLocTower == "") { cableBeginLocTower = "2/3"; }


            textBox1.Text = 
                "模型信息\r\n------------------------" + 
                "\r\n模型编号：\t" + modelID + "\r\n用户名：\t" + modelUserID +"\r\n修改时间：\t" + modifyDate +
                "\r\n\r\n主梁参数\r\n------------------------" + 
                "\r\n跨径组合：\t" + modelSpan + "\r\n主梁截面：\t"+ modelSection +
                "\r\n\r\n主塔参数\r\n------------------------" +
                "\r\n桥塔高度：\t" + modelTowerHeight + "\r\n横向布置：\t" + modelTowerCrosswide + "\r\n纵向布置：\t" + modelTowerAlong +
                "\r\n\r\n拉索参数\r\n------------------------" +
                "\r\n梁上索距：\t" + cableDisBeam + "\r\n塔上索距：\t" + cableDisTower + "\r\n塔拉索起始位：\t" + cableBeginLocTower;
        }

        //private void ModelCheck_Paint(object sender, PaintEventArgs e)
        //{
        //    Graphics g = e.Graphics;
        //    Color FColor = ColorTranslator.FromHtml("#454F5C");
        //    Color TColor = ColorTranslator.FromHtml("#E9EEF5");
        //    Brush b = new LinearGradientBrush(this.ClientRectangle, TColor, FColor, LinearGradientMode.Vertical);
        //    g.FillRectangle(b, this.ClientRectangle);
        //}

        private void ModelCheck_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("确认删除模型吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string bridgeName = comboBox1.Text.ToString();
                //获取所选择的桥名

                string strConn = "Data Source =47.102.209.81;Initial Catalog = cableStayedBridge; User ID = NanxiChen;Password=123456";
                SqlConnection connection = new SqlConnection(strConn);


                string mysql = "DELETE FROM bridgeModel WHERE userID = '" + userID + "' and modelID = '" + comboBox1.Text + "'";
                SqlCommand mycmd = new SqlCommand(mysql, connection);

                connection.Open();
                mycmd.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("删除成功");
                FormInit();
            }
            else
            {
                return;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "纯文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.Write(textBox1.Text);
                streamWriter.Close();

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
