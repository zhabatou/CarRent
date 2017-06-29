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
    public partial class DeleteStore : Form
    {
        public DeleteStore()
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
            com.CommandText = "select * from 门店信息";
            da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令            
            da.Fill(ds1);//把数据填充到dataset            
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string storeID = comboBox1.Text;
            if (storeID == "")
            {
                MessageBox.Show("选择删除门店ID！");
                return;
            }
            else
            {
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            con.Open();
            string sql = "update 门店信息 set 删除状态='是' where 门店ID='" + textBox1.Text + "'";
            SqlCommand com = new SqlCommand(sql,con);           
            com.ExecuteNonQuery();
            MessageBox.Show("已删除" + textBox1.Text + "！");
            con.Close();           
           
        }
    }
}
