using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace RC1._0.CarInfo
{
    public partial class DeleteCar : Form
    {
        string IDstr1 = "";
        string IDstr2 = "";
        string str = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";

        public DeleteCar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox18.Text != "")
            {
                IDstr1 = textBox18.Text;

                SqlConnection conn = new SqlConnection(str);
                conn.Open();

                string strSql = "select * from 车辆基本信息 where  车辆ID = '" + textBox18.Text + "'";
                SqlCommand cmd = new SqlCommand(strSql, conn);

                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);

                textBox2.Text = dt.Rows[0]["车辆ID"].ToString();
                textBox3.Text = dt.Rows[0]["车牌号码"].ToString();
                textBox4.Text = dt.Rows[0]["车辆类型ID"].ToString();
                
                textBox6.Text = dt.Rows[0]["车辆颜色"].ToString();
                textBox7.Text = dt.Rows[0]["发动机号"].ToString();
                textBox8.Text = dt.Rows[0]["车架编号"].ToString();
                textBox9.Text = dt.Rows[0]["燃油编号"].ToString();
                textBox10.Text = dt.Rows[0]["购买日期"].ToString();
                textBox11.Text = dt.Rows[0]["销售商"].ToString();
                textBox12.Text = dt.Rows[0]["服役状态"].ToString();
                textBox13.Text = dt.Rows[0]["门店ID"].ToString();

                Byte[] mybyte = (Byte[])(dt.Rows[0]["车辆图片"]);
                MemoryStream ms = new MemoryStream(mybyte);
                pictureBox1.Image = Image.FromStream(ms);

                dt.Clear();
                conn.Close();
            }
            else if (textBox1.Text != "")
            {
                IDstr2 = textBox1.Text;
                SqlConnection conn = new SqlConnection(str);
                conn.Open();

                string strSql = "select * from 车辆基本信息 where  车牌号码 = '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(strSql, conn);

                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);

                textBox2.Text = dt.Rows[0]["车辆ID"].ToString();
                textBox3.Text = dt.Rows[0]["车牌号码"].ToString();
                textBox4.Text = dt.Rows[0]["车辆类型ID"].ToString();
                
                textBox6.Text = dt.Rows[0]["车辆颜色"].ToString();
                textBox7.Text = dt.Rows[0]["发动机号"].ToString();
                textBox8.Text = dt.Rows[0]["车架编号"].ToString();
                textBox9.Text = dt.Rows[0]["燃油编号"].ToString();
                textBox10.Text = dt.Rows[0]["购买日期"].ToString();
                textBox11.Text = dt.Rows[0]["销售商"].ToString();
                textBox12.Text = dt.Rows[0]["服役状态"].ToString();
                textBox13.Text = dt.Rows[0]["门店ID"].ToString();

                dt.Clear();
                conn.Close();
            }
            else
            {
                MessageBox.Show("请输入车辆ID或车牌号码！");
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fstr;
            string strSql="";
            SqlConnection conn = new SqlConnection(str);          
            conn.Open();

            if (IDstr1 != "")
            {
                string strSql2 = "select 服役状态 from 车辆基本信息 where 车辆ID = '" + textBox18.Text + "'";
                SqlCommand cmd = new SqlCommand(strSql2, conn);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);
                fstr = dt.Rows[0]["服役状态"].ToString();

                if (fstr == "否")
                {
                    MessageBox.Show("此车辆已处于未服役状态");
                }

                else if (fstr == "是")
                {
                    strSql = "update 车辆基本信息 set 服役状态 = '否' where 车辆ID = '" + textBox18.Text + "'";
                    cmd = new SqlCommand(strSql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("删除成功！");
                }            
                
            }
            else if (IDstr2 != "")
            {
                string strSql2 = "select 服役状态 from 车辆基本信息 where 车牌号码 = '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(strSql2, conn);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);
                fstr = dt.Rows[0]["服役状态"].ToString();

                if (fstr == "否")
                {
                    MessageBox.Show("此车辆已处于未服役状态，请勿重复删除！");
                }

                else if (fstr == "是")
                {
                    strSql = "update 车辆基本信息 set 服役状态 = '否' where 车牌号码 = '" + textBox1.Text + "'";
                    cmd = new SqlCommand(strSql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("删除成功！");
                }      
            }
            else
            {
                MessageBox.Show("未选择车辆！");
            }           
        }
    }
}
