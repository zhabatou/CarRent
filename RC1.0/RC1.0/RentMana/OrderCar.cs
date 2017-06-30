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
    public partial class OrderCar : Form
    {
        public OrderCar()
        {
            InitializeComponent();
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string curtime = DateTime.Now.ToString("yyyyMMddHHmmss");
            textBox3.Text = curtime;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select 车辆ID,车型ID,车型名称,座位数,车辆颜色,门店ID,日租金 from 车辆基本信息,车型信息 where 服役状态='是' and 车辆基本信息.车辆类型ID=车型信息.车型ID and 车辆颜色='" + comboBox2.Text +
                          "'and 座位数=" + comboBox3.Text + " and 车型名称='" + comboBox1.Text + "' and 车辆ID  in ( select 车辆ID from 订单信息 where 开始时间<='" + dateTimePicker1.Value.ToString("yyyy-MM-dd")+
                          "' and 预计还车时间>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' or 开始时间<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and 预计还车时间>='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") +
                          "' or 开始时间<='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and 预计还车时间<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "')";
           
            if (comboBox1.Text == ""&&comboBox2.Text!=""&&comboBox3.Text!="")
            {
                sql = "select 车辆ID,车型ID,车型名称,座位数,车辆颜色,门店ID,日租金 from 车辆基本信息,车型信息 where 服役状态='是' and 车辆基本信息.车辆类型ID=车型信息.车型ID and 车辆颜色='" + comboBox2.Text +
                          "'and 座位数=" + comboBox3.Text + " and 车辆ID  in ( select 车辆ID from 订单信息 where 开始时间<='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") +
                          "' and 预计还车时间>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' or 开始时间<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and 预计还车时间>='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") +
                           "' or 开始时间<='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and 预计还车时间<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "')";
            }
            if (comboBox1.Text == "" && comboBox2.Text == "" && comboBox3.Text == "")
            {
                sql = "select 车辆ID,车型ID,车型名称,座位数,车辆颜色,门店ID,日租金 from 车辆基本信息,车型信息 where 服役状态='是' and 车辆基本信息.车辆类型ID=车型信息.车型ID and 车辆ID  in ( select 车辆ID from 订单信息 where 开始时间<='" + 
                    dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and 预计还车时间>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' or 开始时间<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and 预计还车时间>='" +
                    dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' or 开始时间<='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and 预计还车时间<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "')";
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            con.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();//实例化sqldataadpter
            DataTable dt = new DataTable();
            com.CommandText = sql;
            da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令                             
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            dateTimePicker3.Value = dateTimePicker1.Value;
            dateTimePicker4.Value = dateTimePicker2.Value;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            con.Open();

            string sql1 = "insert into 订单信息(订单号,预约人编号,车辆ID,车型ID,开始时间,预计还车时间,租车门店ID,订单状态,创建时间,创建人职工号) values('"+textBox3.Text+"','"+textBox4.Text+
                            "'," + textBox5.Text + "," + textBox6.Text + ",'" + dateTimePicker3.Value + "','" + dateTimePicker4.Value+"','"+comboBox4.Text + "','在预约','"+DateTime.Now+"','"+
                            textBox1.Text+"')";
            SqlCommand com1 = new SqlCommand(sql1, con);
            com1.ExecuteNonQuery();           
            con.Close();
            MessageBox.Show(textBox3.Text+"号订单保存成功！");
        }
    }
}
