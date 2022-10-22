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
    public partial class Event_tasks : Form
    {
        DataBase dataBase = new DataBase();
        int selectedRow;
        public Event_tasks()
        {
            InitializeComponent();
        }

        private void CreateColumns()
        {       
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("date", "Дата");
            dataGridView1.Columns.Add("time", "Время");
            dataGridView1.Columns.Add("description", "Описание");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void Event_tasks_Load(object sender, EventArgs e)
        {
            //textBox_from_date.Value = textBox_from_date.Value.AddDays(-15);
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(
                record.GetInt32(0),
                record.GetDateTime(1),
                record.GetString(2),
                record.GetString(3),
                RowState.ModifiedNew
                );
        }

        private void ClearFields()
        {
            textBox_id.Text = "";
            textBox_date.Text = "";
            textBox_time.Text = "";
            textBox_description.Text = "";         
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();           
            string queryString = $"select * from events where date >= '" + textBox_from_date.Value.ToString() + "'  and date <= '" + textBox_by_date.Value.ToString() + "'";
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
                textBox_date.Text = row.Cells[1].Value.ToString();
                textBox_time.Text = row.Cells[2].Value.ToString();
                textBox_description.Text = row.Cells[3].Value.ToString();
            }
        }

        private void pictureBox_refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            ClearFields();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            Add_event addEvent = new Add_event();
            addEvent.Show();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from events where concat (id, date, time, description) like '%" + textBox_search.Text + "%'";
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
                dataGridView1.Rows[index].Cells[4].Value = RowState.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[4].Value = RowState.Deleted;
        }

        private void Save()
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[4].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from events where id = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var date = System.Convert.ToDateTime(dataGridView1.Rows[index].Cells[1].Value);
                    var time = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var description = dataGridView1.Rows[index].Cells[3].Value.ToString();                   

                    var changeQuery = $"update events set date = '{date}', time = '{time}', description = '{description}' where id = '{id}'";

                    var command = new SqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void Edit()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = textBox_id.Text;
            var date = textBox_date.Text;
            var time = textBox_time.Text;
            var description = textBox_description.Text;   

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (!String.IsNullOrEmpty(textBox_id.Text) &&
                    !String.IsNullOrEmpty(textBox_date.Text) &&
                    !String.IsNullOrEmpty(textBox_time.Text) &&
                    !String.IsNullOrEmpty(textBox_description.Text) 
                )
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, date, time, description);
                    dataGridView1.Rows[selectedRowIndex].Cells[4].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Необходимо верно заполнить все поля");
                }
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

        private void pictureBox_eraser_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Events events = new Events();
            events.Show();
            this.Hide();
        }

        private void textBox_from_date_ValueChanged(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void textBox_by_date_ValueChanged(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }
    }

}
