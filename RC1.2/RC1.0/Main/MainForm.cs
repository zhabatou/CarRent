﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RC1._0.Main
{
    public partial class MainForm : Form
    {
        public string address = "";
        public string addressid = "";
        public MainForm(string[] str)
        {
            InitializeComponent();
            address = str[1];
            toolStripStatusLabel2.Text = str[0];
            toolStripStatusLabel4.Text = str[1];
            toolStripStatusLabel6.Text = str[2];
            addressid = str[3];
        }

        private void 本店车辆信息_Click(object sender, EventArgs e)
        {
            CarInfo.CarInfo carinfo = new CarInfo.CarInfo(address);
            carinfo.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            CarMana.AddCar addcar = new CarMana.AddCar();
            addcar.Show();
        }

        private void 所有车辆信息_Click(object sender, EventArgs e)
        {
            CarInfo.CarInfo carinfo = new CarInfo.CarInfo();
            carinfo.Show();
        }

        private void 删除车辆_Click(object sender, EventArgs e)
        {
            CarInfo.DeleteCar deletecar = new CarInfo.DeleteCar();
            deletecar.Show();
        }

        private void 客户信息查询_Click(object sender, EventArgs e)
        {
            ClientMana.ClientInfo clientinfo = new ClientMana.ClientInfo();
            clientinfo.Show();
        }

        private void 添加客户_Click(object sender, EventArgs e)
        {
            ClientMana.AddClient addclient = new ClientMana.AddClient();
            addclient.Show();
        }

        private void 修改删除客户信息_Click(object sender, EventArgs e)
        {
            ClientMana.DeleteClient deleteclient = new ClientMana.DeleteClient();
            deleteclient.Show();
        }

        private void 查询订单_Click(object sender, EventArgs e)
        {
            RentMana.CheckRent checkrent = new RentMana.CheckRent();
            checkrent.Show();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            RentMana.BaseInfo baseinfo = new RentMana.BaseInfo();
            baseinfo.Show();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            RentMana.BuildRent buildrent = new RentMana.BuildRent();
            buildrent.Show();
        }

        private void 创建订单_Click(object sender, EventArgs e)
        {
            RentMana.BuildRent buildrent = new RentMana.BuildRent();
            buildrent.Show();
        }

        private void 删除订单_Click(object sender, EventArgs e)
        {
            RentMana.DeleteRent deleterent = new RentMana.DeleteRent();
            deleterent.Show();
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            RentMana.ReletInfo reletinfo = new RentMana.ReletInfo();
            reletinfo.Show();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            RentMana.EndRent endrent = new RentMana.EndRent();
            endrent.Show();
        }

        private void 本店信息_Click(object sender, EventArgs e)
        {
            StoreMana.HereSInfo hereinfo = new StoreMana.HereSInfo(addressid);
            hereinfo.Show();
        }

        private void 全部门店_Click(object sender, EventArgs e)
        {
            StoreMana.AllSInfo allsinfo = new StoreMana.AllSInfo();
            allsinfo.Show();
        }

        private void 添加门店_Click(object sender, EventArgs e)
        {
            StoreMana.AddStore addstore = new StoreMana.AddStore();
            addstore.Show();
        }

        private void 删除门店_Click(object sender, EventArgs e)
        {
            StoreMana.DeleteStore deletestore = new StoreMana.DeleteStore();
            deletestore.Show();
        }

        private void toolStripLabel7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel8.Text=DateTime.Now.ToString();
        }

        private void 账户信息_Click(object sender, EventArgs e)
        {
            UserMana.UserInfo userinfo = new UserMana.UserInfo(toolStripStatusLabel2.Text);
            userinfo.Show();
        }

        private void 修改密码_Click(object sender, EventArgs e)
        {
            UserMana.ChangePass changepass = new UserMana.ChangePass(toolStripStatusLabel2.Text);
            changepass.Show();
        }

        private void 添加账户_Click(object sender, EventArgs e)
        {
            UserMana.AddEmp adduser = new UserMana.AddEmp();
            adduser.Show();
        }

        private void 删除账户_Click(object sender, EventArgs e)
        {
            UserMana.DeleteUser deleteuser = new UserMana.DeleteUser();
            deleteuser.Show();
        }

      
        private void 帮助_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"D:\code\软件工程\RC1.0\RC1.0\Help.txt");
        }

        private void 关于_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"D:\code\软件工程\RC1.0\RC1.0\About.txt");
        }

        private void toolStripLabel6_Click_1(object sender, EventArgs e)
        {
            RentMana.OrderCar ordercar = new RentMana.OrderCar();
            ordercar.Show();
        }

        private void 添加账户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserMana.AddUser addus = new UserMana.AddUser();
            addus.Show();
        }

        private void 添加车型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarInfo.AddCarType a = new CarInfo.AddCarType();
            a.Show();
        }       
    }
}
