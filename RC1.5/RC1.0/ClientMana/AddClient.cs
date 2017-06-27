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
    public partial class AddClient : Form
    {
        static string filepath = "";
        public AddClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            con.Open();
            string sql = "insert into 客户信息(姓名,性别,年龄,身份证号码,联系电话,工作单位,联系地址,邮政编码,邮箱地址,驾驶证号码,驾照类型,驾龄) values('"
                        + textBox1.Text + "','" + textBox2.Text + "'," + textBox3.Text + ",'" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text
                        + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "')";
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();
            MessageBox.Show(textBox1.Text+"信息保存成功！");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
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
            string sql2 = "update 客户信息 set 客户照片 = @picture where 身份证号码 = '" + textBox4.Text + "'";
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
