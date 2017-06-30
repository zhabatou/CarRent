using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RC1._0.UserMana
{
    public partial class ChangePass : Form
    {
        public string usern = "";
        public ChangePass(string str)
        {
            InitializeComponent();
            usern = str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tmp = "";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            con.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            com.CommandText = "select * from 账户信息 where 用户名='" + usern + "'";
            da.SelectCommand = com;
            da.Fill(dt);
            {
                tmp = dt.Rows[0]["密码"].ToString();
            }
            if (tmp != textBox1.Text)
            {
                MessageBox.Show("您输入的旧密码不正确，请重新输入！");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                con.Close();
            }
            else if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("您前后两次的新密码不一致,请重新输入新密码！");
                textBox2.Text = "";
                textBox3.Text = "";
            }
            else
            {
                string sql1 = "update 账户信息 set 密码='" + textBox3.Text + "' where 用户名='" + usern + "'";
                SqlCommand com2 = new SqlCommand(sql1, con);
                com2.ExecuteNonQuery();
                MessageBox.Show(usern + "的密码修改成功！");
                con.Close();
            }
        }
    }
}
