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
    public partial class BaseInfo : Form
    {
        public BaseInfo()
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
            com.CommandText = "select 车型ID,车型名称,车损押金,日租金,座位数,车辆描述 from 车型信息 ";
            da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令            
            da.Fill(ds1);//把数据填充到dataset            
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
            DataSet ds1 = new DataSet();//实例化dataset
            DataTable dt = new DataTable();
            com.CommandText = "select * from 车型信息 where 车型ID=" + textBox7.Text;
            da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令            
            da.Fill(ds1);//把数据填充到dataset            
            da.Fill(dt);
            {
                textBox1.Text = dt.Rows[0]["车型名称"].ToString();
                textBox2.Text = dt.Rows[0]["车损押金"].ToString();
                textBox3.Text = dt.Rows[0]["日租金"].ToString();
                textBox4.Text = dt.Rows[0]["超时费用"].ToString()+"元每小时";
                textBox5.Text = dt.Rows[0]["超公里费用"].ToString()+"元每公里";
                textBox6.Text = dt.Rows[0]["额定行驶公里数"].ToString()+"公里每天";
                textBox8.Text = dt.Rows[0]["座位数"].ToString();
                textBox9.Text = dt.Rows[0]["车辆描述"].ToString();
            }
            con.Close();
        }
    }
}
