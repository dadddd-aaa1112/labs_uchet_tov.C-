
namespace Goods
{
    partial class Event_tasks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Event_tasks));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_create = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_time = new System.Windows.Forms.DateTimePicker();
            this.textBox_date = new System.Windows.Forms.DateTimePicker();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_from_date = new System.Windows.Forms.DateTimePicker();
            this.textBox_by_date = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.pictureBox_refresh = new System.Windows.Forms.PictureBox();
            this.pictureBox_eraser = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_eraser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(423, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Планировщик задач";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Описание";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.btn_edit);
            this.panel1.Controls.Add(this.btn_create);
            this.panel1.Location = new System.Drawing.Point(717, 519);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 243);
            this.panel1.TabIndex = 2;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(29, 187);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(166, 35);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "Сохранить";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(29, 132);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(166, 35);
            this.btn_delete.TabIndex = 2;
            this.btn_delete.Text = "Удалить";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(29, 78);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(166, 35);
            this.btn_edit.TabIndex = 1;
            this.btn_edit.Text = "Редактировать";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(29, 20);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(166, 41);
            this.btn_create.TabIndex = 0;
            this.btn_create.Text = "Создать событие";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Дата события";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "id";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBox_time);
            this.panel2.Controls.Add(this.textBox_date);
            this.panel2.Controls.Add(this.textBox_id);
            this.panel2.Controls.Add(this.textBox_description);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(85, 519);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(439, 214);
            this.panel2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Время";
            // 
            // textBox_time
            // 
            this.textBox_time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.textBox_time.Location = new System.Drawing.Point(183, 62);
            this.textBox_time.Name = "textBox_time";
            this.textBox_time.Size = new System.Drawing.Size(190, 31);
            this.textBox_time.TabIndex = 8;
            // 
            // textBox_date
            // 
            this.textBox_date.Location = new System.Drawing.Point(183, 16);
            this.textBox_date.Name = "textBox_date";
            this.textBox_date.Size = new System.Drawing.Size(190, 31);
            this.textBox_date.TabIndex = 7;
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(183, 155);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(190, 31);
            this.textBox_id.TabIndex = 5;
            // 
            // textBox_description
            // 
            this.textBox_description.Location = new System.Drawing.Point(183, 114);
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.Size = new System.Drawing.Size(190, 31);
            this.textBox_description.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 229);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1267, 284);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // textBox_from_date
            // 
            this.textBox_from_date.CustomFormat = "MMMMdd, yyyy hh:mm";
            this.textBox_from_date.Location = new System.Drawing.Point(252, 174);
            this.textBox_from_date.Name = "textBox_from_date";
            this.textBox_from_date.Size = new System.Drawing.Size(226, 31);
            this.textBox_from_date.TabIndex = 5;
            this.textBox_from_date.ValueChanged += new System.EventHandler(this.textBox_from_date_ValueChanged);
            // 
            // textBox_by_date
            // 
            this.textBox_by_date.Location = new System.Drawing.Point(538, 174);
            this.textBox_by_date.Name = "textBox_by_date";
            this.textBox_by_date.Size = new System.Drawing.Size(242, 31);
            this.textBox_by_date.TabIndex = 6;
            this.textBox_by_date.ValueChanged += new System.EventHandler(this.textBox_by_date_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "Дата начала";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(576, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "Дата окончания";
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(984, 156);
            this.textBox_search.Multiline = true;
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(190, 49);
            this.textBox_search.TabIndex = 10;
            this.textBox_search.TextChanged += new System.EventHandler(this.textBox_search_TextChanged);
            // 
            // pictureBox_refresh
            // 
            this.pictureBox_refresh.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_refresh.Image")));
            this.pictureBox_refresh.Location = new System.Drawing.Point(888, 156);
            this.pictureBox_refresh.Name = "pictureBox_refresh";
            this.pictureBox_refresh.Size = new System.Drawing.Size(64, 49);
            this.pictureBox_refresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_refresh.TabIndex = 11;
            this.pictureBox_refresh.TabStop = false;
            this.pictureBox_refresh.Click += new System.EventHandler(this.pictureBox_refresh_Click);
            // 
            // pictureBox_eraser
            // 
            this.pictureBox_eraser.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_eraser.Image")));
            this.pictureBox_eraser.Location = new System.Drawing.Point(810, 156);
            this.pictureBox_eraser.Name = "pictureBox_eraser";
            this.pictureBox_eraser.Size = new System.Drawing.Size(64, 49);
            this.pictureBox_eraser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_eraser.TabIndex = 12;
            this.pictureBox_eraser.TabStop = false;
            this.pictureBox_eraser.Click += new System.EventHandler(this.pictureBox_eraser_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(1171, 156);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 49);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(352, 12);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(357, 53);
            this.btn_back.TabIndex = 14;
            this.btn_back.Text = "Вернуться на предыдущую страницу";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // Event_tasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 712);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox_eraser);
            this.Controls.Add(this.pictureBox_refresh);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_by_date);
            this.Controls.Add(this.textBox_from_date);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Event_tasks";
            this.Text = "Event_tasks";
            this.Load += new System.EventHandler(this.Event_tasks_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_eraser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.TextBox textBox_description;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker textBox_date;
        private System.Windows.Forms.DateTimePicker textBox_from_date;
        private System.Windows.Forms.DateTimePicker textBox_by_date;
        private System.Windows.Forms.DateTimePicker textBox_time;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.PictureBox pictureBox_refresh;
        private System.Windows.Forms.PictureBox pictureBox_eraser;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btn_back;
    }
}