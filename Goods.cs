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
    enum RowState
    {
        Existed,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Goods : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;
        int test;

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("title", "наименование товара");
            dataGridView1.Columns.Add("code", "шифр товара");
            dataGridView1.Columns.Add("opt_price", "оптовая цена");
            dataGridView1.Columns.Add("retail_price", "розничная цена");
            dataGridView1.Columns.Add("order_date", "дата продажи");
            dataGridView1.Columns.Add("count_order_goods", "количество проданного товара");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(
                record.GetInt32(0), 
                record.GetString(1), 
                record.GetString(2), 
                record.GetInt32(3),
                record.GetInt32(4), 
                record.GetDateTime(5), 
                record.GetInt32(6), 
                RowState.ModifiedNew);
            
        }
        
        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from goods";
            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();

        }


        public Goods()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Navigation navigation = new Navigation();
            this.Hide();
            navigation.ShowDialog();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Goods_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox_id.Text = row.Cells[0].Value.ToString();
                textBox_title.Text = row.Cells[1].Value.ToString();
                textBox_code.Text = row.Cells[2].Value.ToString();
                textBox_opt.Text = row.Cells[3].Value.ToString();
                textBox_retail.Text = row.Cells[4].Value.ToString();                
                textBox_date.Text = row.Cells[5].Value.ToString();
                textBox_count.Text = row.Cells[6].Value.ToString();
                
            }
        }

        private void pictureBox_refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            ClearFields();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            Add_good addGood = new Add_good();
            addGood.Show();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from goods where concat (id, title, code, opt_price, retail_price, order_date, count_order_goods) like '%" + textBox_search.Text + "%'";
            SqlCommand com    = new SqlCommand(searchString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader read = com.ExecuteReader();

            while(read.Read())
            {
                ReadSingleRow(dgw, read);
            }
            read.Close();

        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == String.Empty)
            {
                dataGridView1.Rows[index].Cells[7].Value = RowState.Deleted;
                return;
            }
                        
            dataGridView1.Rows[index].Cells[7].Value = RowState.Deleted;
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void Save()
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[7].Value;
                
                if (rowState == RowState.Existed) {             
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from goods where id = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var title = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var code = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var opt = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var retail = dataGridView1.Rows[index].Cells[4].Value.ToString();                   
                    var date = System.Convert.ToDateTime(dataGridView1.Rows[index].Cells[5].Value);
                    var count = dataGridView1.Rows[index].Cells[6].Value.ToString();

                    var changeQuery = $"update goods set title = '{title}', code = '{code}', opt_price = '{opt}', retail_price = '{retail}', order_date = '{date}', count_order_goods = '{count}' where id = '{id}'";

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
            var title = textBox_title.Text;
            var code = textBox_code.Text;
            int opt;
            int.TryParse(textBox_opt.Text, out opt);
            int retail;
            int.TryParse(textBox_retail.Text, out retail);
            var date = textBox_date.Text;
            var count = textBox_count.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (!String.IsNullOrEmpty(textBox_id.Text) &&
                    !String.IsNullOrEmpty(textBox_title.Text) &&
                    !String.IsNullOrEmpty(textBox_code.Text) &&
                    !String.IsNullOrEmpty(textBox_opt.Text) &&
                    !String.IsNullOrEmpty(textBox_retail.Text) &&
                    !String.IsNullOrEmpty(textBox_date.Text) &&
                    !String.IsNullOrEmpty(textBox_count.Text)                
                )
                {                
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, title, code, opt, retail, date, count);
                    dataGridView1.Rows[selectedRowIndex].Cells[7].Value = RowState.Modified;
                } else
                {
                    MessageBox.Show("Необходимо верно заполнить все поля");
                }
            }

        }

        private void ClearFields()
        {
            textBox_id.Text = "";
            textBox_title.Text = "";
            textBox_code.Text = "";
            textBox_opt.Text = "";
            textBox_retail.Text = "";
            textBox_date.Text = "";
            textBox_count.Text = "";
        }


        private void btn_delete_Click(object sender, EventArgs e)
        {
            deleteRow();
            ClearFields();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Edit();            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Save();
            MessageBox.Show("Сохранено!");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
