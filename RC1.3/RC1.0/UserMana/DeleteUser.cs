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

namespace RC1._0.UserMana
{
    public partial class DeleteUser : Form
    {
        public DeleteUser()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            con.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            com.CommandText = "select 用户名,删除标记 from 账户信息";
            da.SelectCommand = com;
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
            SqlDataAdapter da = new SqlDataAdapter();
            Byte[] mybyte = new byte[0];
            MemoryStream ms;
            DataTable dt = new DataTable();

            com.CommandText = "select * from 职工信息 where 姓名='" + textBox9.Text + "'";
            da.SelectCommand = com;
            da.Fill(dt);
            {
                textBox5.Text = dt.Rows[0]["职工号"].ToString();
                textBox1.Text = dt.Rows[0]["姓名"].ToString();
                textBox2.Text = dt.Rows[0]["性别"].ToString();
                textBox3.Text = dt.Rows[0]["年龄"].ToString();
                textBox4.Text = dt.Rows[0]["职称"].ToString();
                textBox6.Text = dt.Rows[0]["工作门店"].ToString();
                textBox7.Text = dt.Rows[0]["联系电话"].ToString();
                textBox8.Text = dt.Rows[0]["通讯地址"].ToString();

                if (dt.Rows[0]["职工照片"].ToString() != "")
                {
                    mybyte = (Byte[])(dt.Rows[0]["职工照片"]);
                    ms = new MemoryStream(mybyte);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            con.Open();
            string sql = "update 账户信息 set 删除标记='是' where 用户名='" + textBox9.Text + "'";
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();
            MessageBox.Show("账户"+textBox9.Text+"已删除成功！");
            con.Close();
        }
    }
}
