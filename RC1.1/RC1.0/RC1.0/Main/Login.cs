using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RC1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] trans = new string[3];
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string address = comboBox1.Text;
            string limit = comboBox2.Text;
            if (username == "")
            {
                MessageBox.Show("请输入用户名！");
                return;
            }
            else if(password=="")
            {
                MessageBox.Show("请输入用户密码！");
                return;
            }
            else if (address == "")
            {
                MessageBox.Show("选择你的工作门店地址！");
                return;
            }
            else if (limit == "")
            {
                MessageBox.Show("请选择你的工作！");
                return;
            }
            else
            {
                trans[0] = username;
                trans[1] = address;
                trans[2] = limit;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
                con.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter();//实例化sqldataadpter
                DataSet ds1 = new DataSet();//实例化dataset
                DataTable dt = new DataTable();
                com.CommandText = "select * from 账户信息 where 用户名='" + username + "' and 密码='" + password + "' and 工作单位='" + address + "' and 用户权限='"+limit+"'";
                da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令                
                da.Fill(ds1);//把数据填充到dataset                
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                    MessageBox.Show("用户名不存在或密码错误！");
                else
                {
                    con.Close();//关闭数据库               
                    Main.MainForm mainfrom = new Main.MainForm(trans);
                    mainfrom.Show();
                    this.Hide();
                }
            }            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
