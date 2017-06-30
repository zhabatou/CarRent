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
    public partial class CarInfo : Form
    {
        string str = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";

        public CarInfo(string address)
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            con.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();//实例化sqldataadpter
            DataSet ds1 = new DataSet();//实例化dataset
            DataTable dt = new DataTable();
            com.CommandText = "select 车辆ID,车牌号码,车辆类型ID,门店ID,服役状态 from 车辆基本信息 where 门店ID='"+address+"'";
            da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令            
            da.Fill(ds1);//把数据填充到dataset            
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        public CarInfo()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            con.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();//实例化sqldataadpter
            DataSet ds1 = new DataSet();//实例化dataset
            DataTable dt = new DataTable();
            com.CommandText = "select 车辆ID,车牌号码,门店ID,服役状态 from 车辆基本信息";
            da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令            
            da.Fill(ds1);//把数据填充到dataset            
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox20.Text != "")
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();

                string strSql = "select * from 车辆基本信息 where  车辆ID = '" + textBox20.Text + "'";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);

                textBox19.Text = dt.Rows[0]["车辆ID"].ToString();
                textBox2.Text = dt.Rows[0]["车牌号码"].ToString();
                textBox3.Text = dt.Rows[0]["车辆类型ID"].ToString();
                
                textBox5.Text = dt.Rows[0]["车辆颜色"].ToString();
                textBox6.Text = dt.Rows[0]["发动机号"].ToString();
                textBox7.Text = dt.Rows[0]["车架编号"].ToString();
                textBox8.Text = dt.Rows[0]["燃油编号"].ToString();
                textBox9.Text = dt.Rows[0]["购买日期"].ToString();
                textBox10.Text = dt.Rows[0]["销售商"].ToString();
                textBox18.Text = dt.Rows[0]["服役状态"].ToString();
                textBox12.Text = dt.Rows[0]["门店ID"].ToString();

                Byte[] mybyte = (Byte[])(dt.Rows[0]["车辆图片"]);
                MemoryStream ms = new MemoryStream(mybyte);

                pictureBox1.Image = Image.FromStream(ms);

                dt.Clear();
                conn.Close();

            }
            else if (textBox1.Text != "")
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();

                string strSql = "select * from 车辆基本信息 where  车牌号码 = '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);

                textBox19.Text = dt.Rows[0]["车辆ID"].ToString();
                textBox2.Text = dt.Rows[0]["车牌号码"].ToString();
                textBox3.Text = dt.Rows[0]["车辆类型ID"].ToString();
                
                textBox5.Text = dt.Rows[0]["车辆颜色"].ToString();
                textBox6.Text = dt.Rows[0]["发动机号"].ToString();
                textBox7.Text = dt.Rows[0]["车架编号"].ToString();
                textBox8.Text = dt.Rows[0]["燃油编号"].ToString();
                textBox9.Text = dt.Rows[0]["购买日期"].ToString();
                textBox10.Text = dt.Rows[0]["销售商"].ToString();
                textBox18.Text = dt.Rows[0]["服役状态"].ToString();
                textBox12.Text = dt.Rows[0]["门店ID"].ToString();

                Byte[] mybyte = (Byte[])(dt.Rows[0]["车辆图片"]);
                MemoryStream ms = new MemoryStream(mybyte);
                pictureBox1.Image = Image.FromStream(ms);

                dt.Clear();
                conn.Close();
            }
            else 
            {
                MessageBox.Show("请输入车辆ID或车牌号码");
            }


        }
    }
}
