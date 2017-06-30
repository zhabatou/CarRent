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
    public partial class BuildRent : Form
    {
        public BuildRent()
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
            com.CommandText = "select 订单号,开始时间,预计还车时间,订单状态,租车门店ID,创建时间,车辆ID,车型ID from 订单信息 where 订单状态='在预约'";
            da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            button5.Enabled = false;
        }
        public string cartypeid = "";
        public string carnum = "";
        private void button3_Click(object sender, EventArgs e)
        {
            string curtime = DateTime.Now.ToString("yyyyMMddHHmmss");
            textBox1.Text = curtime;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
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
            com.CommandText = "select * from 车型信息 where 车型名称='" + comboBox3.Text + "'";
            da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令                
            da.Fill(ds1);//把数据填充到dataset                
            da.Fill(dt);
            {
                cartypeid = dt.Rows[0]["车型ID"].ToString();
                textBox6.Text = dt.Rows[0]["车损押金"].ToString();
                textBox11.Text = dt.Rows[0]["日租金"].ToString();
            }
            con.Close();
        }

        private void BuildRent_Load(object sender, EventArgs e)
        {

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
           // com.CommandText = "select * from 车辆基本信息 where 车牌号码='" + textBox4.Text + "'";
           // da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令
           // da.Fill(dt);
           // {
           //     carnum = dt.Rows[0]["车辆ID"].ToString();
           // }
            string sql = "insert into 订单信息(订单号,预约人编号,使用人编号,车辆ID,车型ID,开始时间,预计还车时间,订单状态,租车门店ID,车损押金,使用押金,违章押金,日租金,创建时间,创建人职工号) values('"+
                                textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "'," + textBox4.Text + "," + cartypeid + ",'" + dateTimePicker1.Value + "','" + dateTimePicker2.Value+"','"+
                                comboBox2.Text+"','"+comboBox1.Text+"',"+textBox6.Text+","+textBox8.Text+","+textBox9.Text+","+textBox11.Text+",'"+DateTime.Now.ToString()+"','"+textBox10.Text+"')";
            SqlCommand com2 = new SqlCommand(sql, con);
            com2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("保存成功！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cartyid = "";
            button5.Enabled = true;
            button1.Enabled = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            con.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();//实例化sqldataadpter
            //DataSet ds1 = new DataSet();//实例化dataset
            DataTable dt = new DataTable();
            com.CommandText = "select * from 订单信息 where 订单号='" + textBox7.Text + "'";
            da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令
            da.Fill(dt);
            {
                textBox1.Text = dt.Rows[0]["订单号"].ToString();
                textBox2.Text = dt.Rows[0]["预约人编号"].ToString();
                textBox4.Text = dt.Rows[0]["车辆ID"].ToString();
                cartyid = dt.Rows[0]["车型ID"].ToString();
                //dateTimePicker1.Value = DateTime.Parse(dt.Rows[0]["订单号"].ToString());
                //dateTimePicker2.Value = DateTime.Parse(dt.Rows[0]["订单号"].ToString());
                comboBox2.Text = dt.Rows[0]["订单状态"].ToString();
                comboBox1.Text = dt.Rows[0]["租车门店ID"].ToString();
                textBox10.Text = dt.Rows[0]["创建人职工号"].ToString();
                dateTimePicker1.Value = DateTime.Parse(dt.Rows[0]["开始时间"].ToString());
                dateTimePicker2.Value = DateTime.Parse(dt.Rows[0]["预计还车时间"].ToString());
            }
            dt.Clear();
            com.CommandText = "select * from 车型信息 where 车型ID=" + cartyid;
            da.SelectCommand = com;
            da.Fill(dt);
            {
                comboBox3.Text = dt.Rows[0]["车型名称"].ToString();
                textBox6.Text = dt.Rows[0]["车损押金"].ToString();
                textBox11.Text = dt.Rows[0]["日租金"].ToString();
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
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
            // com.CommandText = "select * from 车辆基本信息 where 车牌号码='" + textBox4.Text + "'";
            // da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令
            // da.Fill(dt);
            // {
            //     carnum = dt.Rows[0]["车辆ID"].ToString();
            // }
            string sql = "update 订单信息 set 订单状态='使用中',使用人编号="+textBox3.Text+",车辆ID='"+textBox4.Text+"',开始时间='"+dateTimePicker1.Value+
                           "',预计还车时间='"+dateTimePicker2.Value+"',车损押金="+textBox6.Text+",使用押金="+textBox8.Text+",违章押金="+textBox9.Text+",日租金="+
                           textBox11.Text+" where 订单号='"+textBox1.Text+"'";
            SqlCommand com2 = new SqlCommand(sql, con);
            com2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("保存成功！");
        }
    }
}
