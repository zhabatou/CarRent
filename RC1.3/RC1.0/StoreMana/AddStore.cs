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

namespace RC1._0.StoreMana
{
    public partial class AddStore : Form
    {
        public AddStore()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            string sql1 = "insert into 门店信息 values ('"
                + comboBox1.Text + "','" + textBox2.Text + "','"
                + textBox3.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','否')";

            SqlConnection con = new SqlConnection(connString);
            SqlCommand com1 = new SqlCommand(sql1, con);
            con.Open();
            com1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("保存成功！");
        }
    }
}
