using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RC1._0.RentMana
{
    public partial class CheckRent : Form
    {
        public CheckRent()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            con.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();//实例化sqldataadpter
            //DataSet ds1 = new DataSet();//实例化dataset
            DataTable dt = new DataTable();
            com.CommandText = "select 订单号,开始时间,订单状态,租车门店ID,创建时间,日租金 from 订单信息";
            da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            con.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();//实例化sqldataadpter
            //DataSet ds1 = new DataSet();//实例化dataset
            DataTable dt = new DataTable();
            com.CommandText = "select * from 订单信息 where 订单号='" + textBox1.Text + "'";
            da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令
            da.Fill(dt);
            {
                textBox2.Text = dt.Rows[0]["订单号"].ToString();
                textBox3.Text = dt.Rows[0]["预约人编号"].ToString();
                textBox4.Text = dt.Rows[0]["使用人编号"].ToString();
                textBox5.Text = dt.Rows[0]["车辆ID"].ToString();
                textBox6.Text = dt.Rows[0]["车型ID"].ToString();
                textBox7.Text = dt.Rows[0]["开始时间"].ToString();
                textBox8.Text = dt.Rows[0]["预计还车时间"].ToString();
                textBox9.Text = dt.Rows[0]["实际还车时间"].ToString();
                textBox10.Text = dt.Rows[0]["订单状态"].ToString();
                textBox11.Text = dt.Rows[0]["租车门店ID"].ToString();
                textBox12.Text = dt.Rows[0]["车损押金"].ToString();
                textBox13.Text = dt.Rows[0]["使用押金"].ToString();
                textBox14.Text = dt.Rows[0]["违章押金"].ToString();
                textBox15.Text = dt.Rows[0]["日租金"].ToString();
                textBox16.Text = dt.Rows[0]["行驶公里数"].ToString();
                textBox17.Text = dt.Rows[0]["超时费用"].ToString();
                textBox18.Text = dt.Rows[0]["超公里费用"].ToString();
                textBox19.Text = dt.Rows[0]["服务费"].ToString();
                textBox20.Text = dt.Rows[0]["赔偿金"].ToString();
                textBox21.Text = dt.Rows[0]["实际租金"].ToString();
                textBox22.Text = dt.Rows[0]["总费用"].ToString();
                textBox23.Text = dt.Rows[0]["创建时间"].ToString();
                textBox24.Text = dt.Rows[0]["创建人职工号"].ToString();
            }
            con.Close();
        }
    }
}
