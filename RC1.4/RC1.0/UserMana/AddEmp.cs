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
    public partial class AddEmp : Form
    {
        public AddEmp()
        {
            InitializeComponent();
        }

        static string filepath = "";
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            con.Open();
            string sql = "insert into 职工信息(职工号,姓名,性别,年龄,职称,联系电话,工作门店,通讯地址) values('" + textBox5.Text + "','" + textBox1.Text + "','" + comboBox2.Text + "'," +
                        textBox3.Text + ",'" + textBox4.Text + "','" + textBox7.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "')";
            SqlCommand com1 = new SqlCommand(sql, con);
            com1.ExecuteNonQuery();           
            con.Close();
            MessageBox.Show("保存成功！");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择上传的图片";

            ofd.Filter = "图片格式|*.jpg";

            ofd.Multiselect = false;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filepath = ofd.FileName;

                int position = filepath.LastIndexOf("\\");

                string filename = filepath.Substring(position + 1);

                pictureBox1.ImageLocation = filepath;
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            con.Open();
            string sql2 = "update 职工信息 set 职工照片 = @picture where 职工号 = '" + textBox5.Text + "'";
            SqlCommand com2 = new SqlCommand(sql2, con);

            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);

            Byte[] mybyte = new byte[fs.Length];

            fs.Read(mybyte, 0, mybyte.Length);

            fs.Close();

            SqlParameter prm = new SqlParameter("@picture", SqlDbType.VarBinary, mybyte.Length, ParameterDirection.Input, false,
                0, 0, null, DataRowVersion.Current, mybyte);
            com2.Parameters.Add(prm);
            com2.ExecuteNonQuery();
            MessageBox.Show("图片上传成功！");
            con.Close();
        }
    }
}
