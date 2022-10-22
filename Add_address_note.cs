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
    public partial class Add_address_note : Form
    {
        DataBase dataBase = new DataBase();
        public Add_address_note()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Add_address_note_Load(object sender, EventArgs e)
        {

        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();           

            var name = textBox_name.Text;
            var surname = textBox_surname.Text;
            var patronymic = textBox_patronymic.Text;
            var bithday = System.Convert.ToDateTime(textBox_bithday.Text); 
            var email = textBox_email.Text;
            var phone = textBox_phone.Text;
            var work = textBox_work.Text;
            var post = textBox_post.Text;

            if (!String.IsNullOrEmpty(textBox_name.Text) &&
                !String.IsNullOrEmpty(textBox_surname.Text) &&
                !String.IsNullOrEmpty(textBox_patronymic.Text) &&
                !String.IsNullOrEmpty(textBox_email.Text) &&
                !String.IsNullOrEmpty(textBox_phone.Text) &&
                !String.IsNullOrEmpty(textBox_work.Text) &&
                !String.IsNullOrEmpty(textBox_post.Text)        
                )
            {
                var addQuery = $"insert into address_book (name, surname, patronymic,bithday,email, phone, place_work, post) values ('{name}','{surname}','{patronymic}','{bithday}','{email}', '{phone}', '{work}', '{post}')";

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
