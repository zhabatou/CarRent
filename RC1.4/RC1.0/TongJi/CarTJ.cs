using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RC1._0.TongJi
{
    public partial class CarTJ : Form
    {
        public CarTJ()
        {
            InitializeComponent();
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
            com.CommandText = "select 车辆ID,SUM(总费用) AS 销售额 from 订单信息 where 订单状态='已结束' and 实际还车时间>='" +
                               dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and 实际还车时间<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") +
                               "' group by(车辆ID)";
            da.SelectCommand = com;//设置为已实例化SqlDataAdapter的查询命令
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
