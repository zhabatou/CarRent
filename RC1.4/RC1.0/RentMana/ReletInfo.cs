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
    public partial class ReletInfo : Form
    {
        public ReletInfo()
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
            com.CommandText = "select 订单号,开始时间,预计还车时间,订单状态,租车门店ID,创建时间,车辆ID,车型ID from 订单信息 where 订单状态='使用中' or 订单状态='续租中'";
            da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox7.Text = textBox1.Text;
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
                dateTimePicker1.Value = DateTime.Parse(dt.Rows[0]["预计还车时间"].ToString());
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            con.Open();
            string sql = "insert into 续租信息 values('" + textBox7.Text + "'," + comboBox1.Text + ",'" + textBox3.Text + "','" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "','" + DateTime.Now.ToString() + "','" + textBox2.Text + "')";
            SqlCommand com = new SqlCommand(sql,con);
            com.ExecuteNonQuery();            
            string sql2 = "update 订单信息 set 预计还车时间='" + dateTimePicker2.Value + "',订单状态='续租中' where 订单号='" + textBox7.Text + "'";
            SqlCommand com2 = new SqlCommand(sql2, con);
            com2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(textBox7.Text+"号续租订单保存成功！");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime d1 = dateTimePicker1.Value;
            DateTime d2 = dateTimePicker2.Value;
            TimeSpan ds1 = d2.Subtract(d1);
            int days = ds1.Days;
            textBox3.Text = days.ToString();
        }

    }
}
