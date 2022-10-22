using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Goods
{
    public partial class Navigation : Form
    {
        DataBase dataBase = new DataBase();
        
        public Navigation()
        {
            InitializeComponent();
        }

        private void btn_Address_book_Click(object sender, EventArgs e)
        {
            Address_book addressBook = new Address_book();
            this.Hide();
            addressBook.ShowDialog();
          

        }

        private void btn_Event_Click(object sender, EventArgs e)
        {
            Events calendar = new Events();
            this.Hide();
            calendar.ShowDialog();
           

        }

        private void btn_Goods_Click(object sender, EventArgs e)
        {
            Goods goods = new Goods();
            this.Hide();
            goods.ShowDialog();
           
        }

       
    }
}
