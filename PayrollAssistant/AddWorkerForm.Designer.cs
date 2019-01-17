namespace PayrollAssistant
{
    partial class AddWorkerForm
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
            this.FIOTextBox = new System.Windows.Forms.TextBox();
            this.AddWorkerBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.GroupListBox = new System.Windows.Forms.ListBox();
            this.ChiefListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // FIOTextBox
            // 
            this.FIOTextBox.Location = new System.Drawing.Point(142, 108);
            this.FIOTextBox.Name = "FIOTextBox";
            this.FIOTextBox.Size = new System.Drawing.Size(188, 20);
            this.FIOTextBox.TabIndex = 4;
            // 
            // AddWorkerBtn
            // 
            this.AddWorkerBtn.Location = new System.Drawing.Point(290, 327);
            this.AddWorkerBtn.Name = "AddWorkerBtn";
            this.AddWorkerBtn.Size = new System.Drawing.Size(75, 23);
            this.AddWorkerBtn.TabIndex = 5;
            this.AddWorkerBtn.Text = "Add";
            this.AddWorkerBtn.UseVisualStyleBackColor = true;
            this.AddWorkerBtn.Click += new System.EventHandler(this.AddWorkerBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "ФИО";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Группа";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Начальник";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Дата Поступления";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(142, 268);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(188, 20);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // GroupListBox
            // 
            this.GroupListBox.FormattingEnabled = true;
            this.GroupListBox.Items.AddRange(new object[] {
            "Employee",
            "Manager",
            "Salesman"});
            this.GroupListBox.Location = new System.Drawing.Point(142, 159);
            this.GroupListBox.Name = "GroupListBox";
            this.GroupListBox.Size = new System.Drawing.Size(188, 30);
            this.GroupListBox.TabIndex = 13;
            // 
            // ChiefListBox
            // 
            this.ChiefListBox.FormattingEnabled = true;
            this.ChiefListBox.Location = new System.Drawing.Point(142, 214);
            this.ChiefListBox.Name = "ChiefListBox";
            this.ChiefListBox.Size = new System.Drawing.Size(188, 30);
            this.ChiefListBox.TabIndex = 14;
            // 
            // AddWorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 362);
            this.Controls.Add(this.ChiefListBox);
            this.Controls.Add(this.GroupListBox);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddWorkerBtn);
            this.Controls.Add(this.FIOTextBox);
            this.Name = "AddWorkerForm";
            this.Text = "AddWorkerForm";
            this.Load += new System.EventHandler(this.AddWorkerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox FIOTextBox;
        private System.Windows.Forms.Button AddWorkerBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ListBox GroupListBox;
        private System.Windows.Forms.ListBox ChiefListBox;
    }
}