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
    public partial class AddCarType : Form
    {
        string str = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";

        public AddCarType()
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
            com.CommandText = "select * from 车型信息";
            da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令            
            da.Fill(ds1);//把数据填充到dataset            
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();

                string strSql = "insert into 车型信息(车型名称,车损押金,日租金,超时费用,超公里费用,额定行驶公里数,座位数,车辆描述) values ('"
                + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','"
                + textBox5.Text + "','" + textBox6.Text + "','" + textBox8.Text + "','" + textBox7.Text + "')";
                
                SqlCommand cmd = new SqlCommand(strSql, conn);

                cmd.ExecuteNonQuery();
                //conn.Close();

                //conn.Open();

                string strSql2 = "select * from 车型信息";
                cmd = new SqlCommand(strSql2, conn);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;             
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                conn.Close();
                
                MessageBox.Show("插入成功！");
            }
            catch
            {
                MessageBox.Show("插入失败！");
            }


        }
    }
}
