
namespace Goods
{
    partial class Navigation
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
            this.btn_Address_book = new System.Windows.Forms.Button();
            this.btn_Event = new System.Windows.Forms.Button();
            this.btn_Goods = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Address_book
            // 
            this.btn_Address_book.Location = new System.Drawing.Point(263, 51);
            this.btn_Address_book.Name = "btn_Address_book";
            this.btn_Address_book.Size = new System.Drawing.Size(241, 61);
            this.btn_Address_book.TabIndex = 0;
            this.btn_Address_book.Text = "Адресная книга";
            this.btn_Address_book.UseVisualStyleBackColor = true;
            this.btn_Address_book.Click += new System.EventHandler(this.btn_Address_book_Click);
            // 
            // btn_Event
            // 
            this.btn_Event.Location = new System.Drawing.Point(263, 155);
            this.btn_Event.Name = "btn_Event";
            this.btn_Event.Size = new System.Drawing.Size(241, 61);
            this.btn_Event.TabIndex = 1;
            this.btn_Event.Text = "События";
            this.btn_Event.UseVisualStyleBackColor = true;
            this.btn_Event.Click += new System.EventHandler(this.btn_Event_Click);
            // 
            // btn_Goods
            // 
            this.btn_Goods.Location = new System.Drawing.Point(263, 263);
            this.btn_Goods.Name = "btn_Goods";
            this.btn_Goods.Size = new System.Drawing.Size(241, 61);
            this.btn_Goods.TabIndex = 2;
            this.btn_Goods.Text = "Товары";
            this.btn_Goods.UseVisualStyleBackColor = true;
            this.btn_Goods.Click += new System.EventHandler(this.btn_Goods_Click);
            // 
            // Navigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Goods);
            this.Controls.Add(this.btn_Event);
            this.Controls.Add(this.btn_Address_book);
            this.Name = "Navigation";
            this.Text = "Navigation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Address_book;
        private System.Windows.Forms.Button btn_Event;
        private System.Windows.Forms.Button btn_Goods;
    }
}