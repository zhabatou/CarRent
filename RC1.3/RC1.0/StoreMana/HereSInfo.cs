using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RC1._0.StoreMana
{
    public partial class HereSInfo : Form
    {
        public HereSInfo(string storeID)
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            con.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();//实例化sqldataadpter
            DataTable dt = new DataTable();
            com.CommandText = "select * from 门店信息 where 门店ID='" + storeID + "'";
            da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令                              
            da.Fill(dt);
            {
                textBox1.Text = dt.Rows[0]["门店ID"].ToString();
                textBox2.Text = dt.Rows[0]["门店地址"].ToString();
                textBox3.Text = dt.Rows[0]["门店联系电话"].ToString();
                textBox4.Text = dt.Rows[0]["门店经理职工号"].ToString();
                textBox5.Text = dt.Rows[0]["门店营业时间"].ToString();
            }
            con.Close();//关闭数据库
        }

    }

}
