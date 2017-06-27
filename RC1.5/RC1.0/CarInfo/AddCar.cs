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


namespace RC1._0.CarMana
{
    public partial class AddCar : Form
    {
        static string filepath = "";
        public AddCar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";
            con.Open();
        
            string sql1 = "insert into 车辆基本信息(车牌号码,车辆名称,车辆类型,车辆颜色,发动机号,车架编号,燃油编号,购买日期,销售商,状态,门店地址) values ('"
                + textBox1.Text + "','" + textBox2.Text + "','" 
                + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" +
                textBox7.Text + "','" + dateTimePicker1.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','"
                + textBox10.Text +"')" ;
            SqlCommand com1 = new SqlCommand( sql1 , con);
            com1.ExecuteNonQuery();
            string sql2 = "insert into 车辆保险信息 values('" + textBox11.Text + "','" + textBox1.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + dateTimePicker2.Text + "','" + dateTimePicker3.Text + "')";
            SqlCommand com2 = new SqlCommand(sql2, con);
            com2.ExecuteNonQuery();
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
            string sql2 = "update 车辆基本信息 set 车辆图片 = @picture where 车牌号码 = '" + textBox1.Text + "'";
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
