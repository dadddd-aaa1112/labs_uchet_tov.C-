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
    public partial class Auth_user : Form
    {
        DataBase dataBase = new DataBase();

        public Auth_user()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Auth_user_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '.';
            textBox_login.MaxLength = 50;
            textBox_password.MaxLength = 50;
        }

        private void btn_auth_Click(Object sender, EventArgs e)
        {
            var loginUser = textBox_login.Text;
            var passUser = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"select id, login, password from auth_user where login = '{loginUser}' and password = '{passUser}'";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Navigation navigation = new Navigation();
                this.Hide();
                navigation.ShowDialog();                
            }
            else
            {
                MessageBox.Show("Такого аккаунта не существует", "Такого аккаунта не существует", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
      
    }
}
