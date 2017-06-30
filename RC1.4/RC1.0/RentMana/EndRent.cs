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
    public partial class EndRent : Form
    {
        public int mo = 0;//总费用
        public int csm = 0;//合计超时费用
        public int cdm = 0;//合计超公里费用
        public EndRent()
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
            com.CommandText = "select 订单号,开始时间,订单状态,租车门店ID,创建时间,日租金 from 订单信息 where 订单状态='使用中' or 订单状态='续租中'";
            da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
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
            com.CommandText = "select * from 订单信息 where 订单号='" + textBox1.Text + "'";
            da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令
            da.Fill(dt);
            {
                textBox2.Text = dt.Rows[0]["订单号"].ToString();
                textBox3.Text = dt.Rows[0]["预约人编号"].ToString();
                textBox4.Text = dt.Rows[0]["使用人编号"].ToString();
                textBox5.Text = dt.Rows[0]["车辆ID"].ToString();
                textBox6.Text = dt.Rows[0]["车型ID"].ToString();
                textBox7.Text = dt.Rows[0]["开始时间"].ToString();
                textBox8.Text = dt.Rows[0]["预计还车时间"].ToString();
                textBox9.Text = dt.Rows[0]["订单状态"].ToString();
                textBox10.Text = dt.Rows[0]["租车门店ID"].ToString();
                textBox11.Text = dt.Rows[0]["车损押金"].ToString();
                textBox12.Text = dt.Rows[0]["使用押金"].ToString();
                textBox13.Text = dt.Rows[0]["违章押金"].ToString();
                textBox14.Text = dt.Rows[0]["创建人职工号"].ToString();
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int money = 0;//实际租金
            string str1 = "";//日租金
            string str2 = "";//超时费用元每天
            string str3 = "";//超公里费用元每公里
            string str4 = "";//额定行驶公里数公里每天
            if (textBox15.Text == "")
            {
                MessageBox.Show("请录入行驶公里数！");
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
                //DataSet ds1 = new DataSet();//实例化dataset
                DataTable dt = new DataTable();
                com.CommandText = "select * from 车型信息 where 车型ID='" + textBox6.Text + "'";
                da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令
                da.Fill(dt);
                {
                    str1 = dt.Rows[0]["日租金"].ToString();
                    str2 = dt.Rows[0]["超时费用"].ToString();
                    str3 = dt.Rows[0]["超公里费用"].ToString();
                    str4 = dt.Rows[0]["额定行驶公里数"].ToString();
                }
                con.Close();
                DateTime dts1 = DateTime.Parse(textBox8.Text.ToString());//预计还车时间
                DateTime dts2 = dateTimePicker1.Value;//实际还车时间
                DateTime dts3 = DateTime.Parse(textBox7.Text.ToString());//开始时间
                TimeSpan d1 = dts2.Subtract(dts3);
                int dds1 = d1.Days;
                TimeSpan d2 = dts1.Subtract(dts3);
                int dds3 = d2.Days;
                if (dts2 <= dts1)
                {
                    csm = 0;
                    textBox16.Text = csm.ToString();
                    money += dds1 * Int32.Parse(str1);
                }
                else
                {
                    TimeSpan d3 = dts2.Subtract(dts1);
                    int dds2 = d3.Days;
                    csm=dds2 * Int32.Parse(str2);
                    textBox16.Text = csm.ToString();
                    money += dds3 * Int32.Parse(str1) + dds2 * Int32.Parse(str2);
                }
                int dis = Int32.Parse(str4) * dds1;//总计额定行驶公里数
                int dist = Int32.Parse(textBox15.Text.ToString());
                if (dis >= dist)
                {
                    cdm = 0;
                    textBox17.Text = cdm.ToString();
                }
                else
                {
                    int df = dist - dis;
                    cdm = df * Int32.Parse(str3);
                    textBox17.Text = cdm.ToString();
                    money += cdm;
                }
                textBox18.Text = money.ToString();
                mo = money;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mo += Int32.Parse(textBox19.Text.ToString()) + Int32.Parse(textBox20.Text.ToString());
            textBox21.Text = mo.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            con.Open();
            string sql2 = "update 订单信息 set 实际还车时间='"+dateTimePicker1.Value+"',行驶公里数="+textBox15.Text+",超时费用="+textBox16.Text+",超公里费用="+
                            textBox17.Text+",服务费="+textBox19.Text+",赔偿金="+textBox20.Text+",实际租金="+textBox18.Text+",总费用="+textBox21.Text+
                            ",订单状态='已结束' where 订单号='"+textBox1.Text+"'";
            SqlCommand com2 = new SqlCommand(sql2, con);
            com2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("保存成功！");
        }
    }
}
