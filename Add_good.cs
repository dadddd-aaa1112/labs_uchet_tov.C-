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
    public partial class Add_good : Form
    {
        DataBase dataBase = new DataBase();
        public Add_good()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var title = textBox_title.Text;
            var code = textBox_code.Text;
            var date = System.Convert.ToDateTime(dateTimePicker_date.Text);
            int count;
            int.TryParse(textBox_count.Text, out count);
            int opt;
            int retail;
            int.TryParse(textBox_opt.Text, out opt);
            int.TryParse(textBox_retail.Text, out retail);

            if (!String.IsNullOrEmpty(textBox_title.Text) &&
                !String.IsNullOrEmpty(textBox_code.Text) &&
                !String.IsNullOrEmpty(textBox_opt.Text) &&
                !String.IsNullOrEmpty(textBox_retail.Text) &&
                !String.IsNullOrEmpty(dateTimePicker_date.Text) &&
                !String.IsNullOrEmpty(textBox_count.Text)
                )
            {
                var addQuery = $"insert into goods (title, code, opt_price,retail_price,order_date, count_order_goods) values ('{title}','{code}','{opt}','{retail}','{date}', '{count}')";

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

        private void Add_good_Load(object sender, EventArgs e)
        {

        }
    }
}
