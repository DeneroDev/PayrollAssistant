namespace PayrollAssistant
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddWorkerBtn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.IDColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GroupColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SalaryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SubordinatesColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChiefColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ShowSubBtn = new System.Windows.Forms.Button();
            this.CalculateSalaryBtn = new System.Windows.Forms.Button();
            this.SubListBox = new System.Windows.Forms.ListBox();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.AllWorkerCalculate = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddWorkerBtn
            // 
            this.AddWorkerBtn.Location = new System.Drawing.Point(12, 136);
            this.AddWorkerBtn.Name = "AddWorkerBtn";
            this.AddWorkerBtn.Size = new System.Drawing.Size(75, 23);
            this.AddWorkerBtn.TabIndex = 0;
            this.AddWorkerBtn.Text = "AddWorker";
            this.AddWorkerBtn.UseVisualStyleBackColor = true;
            this.AddWorkerBtn.Click += new System.EventHandler(this.AddWorkerBtn_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDColumn,
            this.NameColumn,
            this.DateColumn,
            this.GroupColumn,
            this.SalaryColumn,
            this.SubordinatesColumn,
            this.ChiefColumn});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(776, 97);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // IDColumn
            // 
            this.IDColumn.Text = "ID";
            this.IDColumn.Width = 30;
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 120;
            // 
            // DateColumn
            // 
            this.DateColumn.Text = "Дата поступления";
            this.DateColumn.Width = 140;
            // 
            // GroupColumn
            // 
            this.GroupColumn.Text = "Должность";
            this.GroupColumn.Width = 80;
            // 
            // SalaryColumn
            // 
            this.SalaryColumn.Text = "Зарплата";
            this.SalaryColumn.Width = 95;
            // 
            // SubordinatesColumn
            // 
            this.SubordinatesColumn.Text = "Подчиненные Кол-во";
            this.SubordinatesColumn.Width = 137;
            // 
            // ChiefColumn
            // 
            this.ChiefColumn.Text = "Начальник";
            this.ChiefColumn.Width = 241;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(184, 203);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(184, 229);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Рассчитать зарплату с:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "на:";
            // 
            // ShowSubBtn
            // 
            this.ShowSubBtn.Location = new System.Drawing.Point(576, 304);
            this.ShowSubBtn.Name = "ShowSubBtn";
            this.ShowSubBtn.Size = new System.Drawing.Size(75, 23);
            this.ShowSubBtn.TabIndex = 6;
            this.ShowSubBtn.Text = "ShowSub";
            this.ShowSubBtn.UseVisualStyleBackColor = true;
            this.ShowSubBtn.Click += new System.EventHandler(this.ShowSubBtn_Click);
            // 
            // CalculateSalaryBtn
            // 
            this.CalculateSalaryBtn.Location = new System.Drawing.Point(309, 255);
            this.CalculateSalaryBtn.Name = "CalculateSalaryBtn";
            this.CalculateSalaryBtn.Size = new System.Drawing.Size(75, 23);
            this.CalculateSalaryBtn.TabIndex = 7;
            this.CalculateSalaryBtn.Text = "Расчитать";
            this.CalculateSalaryBtn.UseVisualStyleBackColor = true;
            this.CalculateSalaryBtn.Click += new System.EventHandler(this.CalculateSalaryBtn_Click);
            // 
            // SubListBox
            // 
            this.SubListBox.FormattingEnabled = true;
            this.SubListBox.Location = new System.Drawing.Point(484, 203);
            this.SubListBox.Name = "SubListBox";
            this.SubListBox.Size = new System.Drawing.Size(167, 95);
            this.SubListBox.TabIndex = 8;
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(97, 136);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(75, 23);
            this.UpdateBtn.TabIndex = 9;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // AllWorkerCalculate
            // 
            this.AllWorkerCalculate.Location = new System.Drawing.Point(309, 284);
            this.AllWorkerCalculate.Name = "AllWorkerCalculate";
            this.AllWorkerCalculate.Size = new System.Drawing.Size(98, 23);
            this.AllWorkerCalculate.TabIndex = 10;
            this.AllWorkerCalculate.Text = "Расчитать Всех";
            this.AllWorkerCalculate.UseVisualStyleBackColor = true;
            this.AllWorkerCalculate.Click += new System.EventHandler(this.AllWorkerCalculate_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(184, 136);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 11;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.AllWorkerCalculate);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.SubListBox);
            this.Controls.Add(this.CalculateSalaryBtn);
            this.Controls.Add(this.ShowSubBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.AddWorkerBtn);
            this.Name = "MainForm";
            this.Text = "Payroll Assistant";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddWorkerBtn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ShowSubBtn;
        private System.Windows.Forms.Button CalculateSalaryBtn;
        private System.Windows.Forms.ColumnHeader IDColumn;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader DateColumn;
        private System.Windows.Forms.ColumnHeader GroupColumn;
        private System.Windows.Forms.ColumnHeader SalaryColumn;
        private System.Windows.Forms.ColumnHeader SubordinatesColumn;
        private System.Windows.Forms.ColumnHeader ChiefColumn;
        private System.Windows.Forms.ListBox SubListBox;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Button AllWorkerCalculate;
        private System.Windows.Forms.Button DeleteBtn;
    }
}

