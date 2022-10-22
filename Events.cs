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
    public partial class Events : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;
        public Events()
        {
            InitializeComponent();
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("date", "Дата");
            dataGridView1.Columns.Add("time", "Время");
            dataGridView1.Columns.Add("description", "Описание");            
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Navigation navigation = new Navigation();
            this.Hide();
            navigation.ShowDialog();
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(
                record.GetInt32(0),
                record.GetDateTime(1),
                record.GetString(2),
                record.GetString(3)                
                );
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();            
            string queryString = $"select * from events where date = '" + monthCalendar1.SelectionRange.Start.ToShortDateString() + "'";
            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }
        private void Calendar_Load(object sender, EventArgs e)
        {
            label_show_date.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void btn_redirect_event_task_Click(object sender, EventArgs e)
        {
            Event_tasks eventTasks = new Event_tasks();
            eventTasks.Show();
            this.Hide();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {            
            label_show_date.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
            RefreshDataGrid(dataGridView1);
        }
    }
}
