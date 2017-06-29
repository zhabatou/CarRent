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

namespace RC1._0.ClientMana
{
    public partial class ClientInfo : Form
    {
        public ClientInfo()
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
            com.CommandText = "select 客户编号,姓名,电话,身份证号 from 客户基本信息 where 删除标记 = '否'";
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

            string sql1 = "select * from 客户基本信息 where 客户编号 = '" + textBox13.Text + "'";
            SqlCommand com1 = new SqlCommand(sql1, con);
            com1.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = com1;
            DataTable dt = new DataTable();
            da.Fill(dt);


            textBox1.Text = dt.Rows[0]["姓名"].ToString();
            textBox2.Text = dt.Rows[0]["性别"].ToString();
            textBox3.Text = dt.Rows[0]["年龄"].ToString();
            textBox4.Text = dt.Rows[0]["身份证号"].ToString();
            textBox5.Text = dt.Rows[0]["电话"].ToString();
            textBox6.Text = dt.Rows[0]["工作单位"].ToString();
            textBox7.Text = dt.Rows[0]["通讯地址"].ToString();
            textBox8.Text = dt.Rows[0]["邮政编码"].ToString();
            textBox9.Text = dt.Rows[0]["邮箱地址"].ToString();

            Byte[] mybyte = new byte[0];
            MemoryStream ms;
            mybyte = (Byte[])(dt.Rows[0]["客户照片"]);
            ms = new MemoryStream(mybyte);
            pictureBox1.Image = Image.FromStream(ms);

            dt.Clear();

            string sql2 = "select* from 驾驶证信息 where 客户编号 = '" + textBox13.Text + "'";
            SqlCommand com2 = new SqlCommand(sql2, con);
            com2.ExecuteNonQuery();

            SqlDataAdapter da2 = new SqlDataAdapter();
            da2.SelectCommand = com2;
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            textBox10.Text = dt2.Rows[0]["驾驶证号"].ToString();
            textBox11.Text = dt2.Rows[0]["驾照类型"].ToString();
            textBox12.Text = dt2.Rows[0]["驾龄"].ToString();
            textBox14.Text = dt2.Rows[0]["驾驶证状态"].ToString();

            dt2.Clear();

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";

            con.Open();

            string sql1 = "select 客户编号 from 客户基本信息 where 姓名 = '" + textBox1.Text + "'";
            SqlCommand com1 = new SqlCommand(sql1, con);
            com1.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = com1;
            DataTable dt = new DataTable();
            da.Fill(dt);

            int temp = dt.Rows.Count;

            if (temp == 0)
            {
                MessageBox.Show("查询失败，无该姓名。");
            }

            string s = null;
            int i = 0;
            while (temp >= 1)
            {
                s = s + dt.Rows[i]["客户编号"].ToString();
                s = s + ";";
                i++;
                temp--;
            }
            textBox13.Text =s;

            
            dt.Clear();

            con.Close();
        }
    }
}
