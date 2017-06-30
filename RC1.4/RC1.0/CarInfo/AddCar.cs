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
        public static byte[] imgBytesIn;
        Stream ms;
        byte[] picbyte;
        string filepath;
        string str = @"Data Source=(local),1433;Initial Catalog=CarRentManage;Trusted_connection=yes";

        public AddCar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择上传的图片";

            ofd.Filter = "图片格式|*.jpg";

            ofd.Multiselect = false;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((ms = ofd.OpenFile()) != null)
                {
                    picbyte = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(picbyte, 0, Convert.ToInt32(ms.Length));
                    pictureBox1.Image = System.Drawing.Image.FromFile(ofd.FileName);

                }

                else
                {
                    MessageBox.Show("选择错误！");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            string strSql = "insert into 车辆基本信息(车牌号码,车辆类型ID,车辆颜色,发动机号,车架编号,燃油编号,购买日期,销售商,服役状态,门店ID) values ('"
               + textBox2.Text + "','" + textBox3.Text + "','" 
               + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','"
               + dateTimePicker1.Value + "','"
               + textBox9.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "')";

            SqlCommand cmd = new SqlCommand(strSql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            string strSql2 = "update 车辆基本信息 set 车辆图片 = @picture where 车牌号码 = '" + textBox2.Text + "'";
            SqlCommand cmd2 = new SqlCommand(strSql2, conn);
            /*
            cmd2.Parameters.Add("@Photo", SqlDbType.Image);
            cmd2.Parameters["@Photo"].Value = picbyte;
            */
            SqlParameter prm = new SqlParameter
              ("@picture", SqlDbType.VarBinary, picbyte.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, picbyte);
            cmd2.Parameters.Add(prm);
            cmd2.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("已存入数据库！");
            
            ms.Close();    
                 
        }

       

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
