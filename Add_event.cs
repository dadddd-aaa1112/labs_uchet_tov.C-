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
    public partial class Add_event : Form
    {
        DataBase dataBase = new DataBase();
        public Add_event()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Add_event_Load(object sender, EventArgs e)
        {

        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();          
            var date = System.Convert.ToDateTime(textBox_date.Text);
            var time = textBox_time.Text;
            var description = textBox_description.Text;
           
            if (!String.IsNullOrEmpty(textBox_date.Text) &&
                !String.IsNullOrEmpty(textBox_time.Text) &&
                !String.IsNullOrEmpty(textBox_description.Text)
             )
            {
                var addQuery = $"insert into events (date, time, description) values ('{date}','{time}','{description}')";

                var command = new SqlCommand(addQuery, dataBase.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно создана", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Необходимо верно заполнить все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            dataBase.closeConnection();
        }
    }
}
