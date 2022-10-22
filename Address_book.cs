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
    public partial class Address_book : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("name", "Имя");
            dataGridView1.Columns.Add("surname", "Фамилия");
            dataGridView1.Columns.Add("patronymic", "Отчество");            
            dataGridView1.Columns.Add("bithday", "Дата рождения");
            dataGridView1.Columns.Add("email", "email");
            dataGridView1.Columns.Add("phone", "Телефон");
            dataGridView1.Columns.Add("place_work", "Место работы");
            dataGridView1.Columns.Add("post", "должность");
            dataGridView1.Columns.Add("IsNew", String.Empty);

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(
                record.GetInt32(0),
                record.GetString(1),
                record.GetString(2),
                record.GetString(3),
                record.GetDateTime(4),
                record.GetString(5),
                record.GetString(6),
                record.GetString(7),
                record.GetString(8),
                RowState.ModifiedNew
                );
        }
        public Address_book()
        {
            InitializeComponent();
        }

        private void pictureBox_refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from address_book";
            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox_id.Text = row.Cells[0].Value.ToString();
                textBox_name.Text = row.Cells[1].Value.ToString();
                textBox_surname.Text = row.Cells[2].Value.ToString();
                textBox_patronymic.Text = row.Cells[3].Value.ToString();
                textBox_bithday.Text = row.Cells[4].Value.ToString();
                textBox_email.Text = row.Cells[5].Value.ToString();
                textBox_phone.Text = row.Cells[6].Value.ToString();
                textBox_work.Text = row.Cells[7].Value.ToString();
                textBox_post.Text = row.Cells[8].Value.ToString();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Navigation navigation = new Navigation();
            this.Hide();
            navigation.ShowDialog();
        }
               

        private void Address_book_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            Add_address_note addfrm = new Add_address_note();
            addfrm.Show();
        }

        
        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from address_book where concat (id, name, surname, patronymic, email, phone, place_work, post) like '%" + textBox_search.Text + "%'";
            SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }
            read.Close();

        }
        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == String.Empty)
            {
                dataGridView1.Rows[index].Cells[9].Value = RowState.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[9].Value = RowState.Deleted;
        }

        private void Save()
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[9].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from address_book where id = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var name = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var surname = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var patronymic = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var bithday = System.Convert.ToDateTime(dataGridView1.Rows[index].Cells[4].Value);
                    var email = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    var phone = dataGridView1.Rows[index].Cells[6].Value.ToString();
                    var work = dataGridView1.Rows[index].Cells[7].Value.ToString();
                    var post = dataGridView1.Rows[index].Cells[8].Value.ToString();

                    var changeQuery = $"update address_book set name = '{name}', surname = '{surname}', patronymic = '{patronymic}', bithday = '{bithday}', email = '{email}', phone = '{phone}', place_work = '{work}', post = '{post}' where id = '{id}'";

                    var command = new SqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }


            }
            dataBase.closeConnection();
        }

        private void ClearFields()
        {
            textBox_id.Text = "";
            textBox_name.Text = "";
            textBox_surname.Text = "";
            textBox_patronymic.Text = "";
            textBox_bithday.Text = "";
            textBox_email.Text = "";
            textBox_phone.Text = "";
            textBox_work.Text = "";
            textBox_post.Text = "";
        }

        private void Edit()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = textBox_id.Text;
            var name = textBox_name.Text;
            var surname = textBox_surname.Text;
            var patronymic = textBox_patronymic.Text;
            var bithday = textBox_bithday.Text;
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
                 dataGridView1.Rows[selectedRowIndex].SetValues(id, name, surname, patronymic, bithday, email, phone, work, post);
                 dataGridView1.Rows[selectedRowIndex].Cells[9].Value = RowState.Modified;

            }
            else
            {
                MessageBox.Show("Необходимо верно заполнить все поля");
            }           

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            deleteRow();
            ClearFields();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Save();
            MessageBox.Show("Сохранено!");
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Edit();           
        }
    }
}
