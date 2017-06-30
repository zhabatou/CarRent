using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RC1._0.CarInfo
{
    public partial class CarInfo : Form
    {
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
            com.CommandText = "select 车牌号码,车辆名称,门店地址,状态 from 车辆基本信息 where 门店地址='"+address+"'";
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
            com.CommandText = "select 车牌号码,车辆名称,门店地址,状态 from 车辆基本信息";
            da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令            
            da.Fill(ds1);//把数据填充到dataset            
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
