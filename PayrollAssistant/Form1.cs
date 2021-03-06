﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Windows.Forms.ListViewItem;

namespace PayrollAssistant
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBHelper.GetInstance().SaveResult(CasheAllWorkerHelper.GetInstance().GetAllWorker());
            DBHelper.GetInstance().CloseDB();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DBHelper.GetInstance().connectDB();
            DBHelper.GetInstance().LoadAllElementDB();
            LoadAllWorker();
        }

        private void LoadAllWorker() {
            List<Worker> workers = CasheAllWorkerHelper.GetInstance().GetAllWorker();
            for (int i = 0; i < workers.Count; i++) {
                var lvi = new ListViewItem(workers[i].Id.ToString());
                lvi.SubItems.Add(workers[i].Name);
                lvi.SubItems.Add(workers[i].Date.ToShortDateString());
                lvi.SubItems.Add(workers[i].CurrentGroup.ToString());
                lvi.SubItems.Add("-");
                lvi.SubItems.Add(workers[i].GetCountAllSubordinate().ToString());
                if(workers[i].Chief!=null)
                    lvi.SubItems.Add(workers[i].Chief.Name);
                else
                    lvi.SubItems.Add("-");

                // Add the list items to the ListView
                listView1.Items.Add(lvi);
            }
        }

        private void CalculateSalaryBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.SelectedItems.Count; i++) {
                ListViewSubItemCollection subItems = listView1.SelectedItems[i].SubItems;
                var cw = CasheAllWorkerHelper.GetInstance()
                     .GetWorkerByID(int.Parse(subItems[0].Text));
                //Worker cw = group.CurrentGroup.Equals(Worker.Group.Employee) ? (Employee)group
                //    : (group.CurrentGroup.Equals(Worker.Group.Manager)) ? (Manager)group
                //    : (group.CurrentGroup.Equals(Worker.Group.Salesman)) ? (Salesman)group : group;
                float salary = cw.GetPayroll(DateTime.Parse(dateTimePicker1.Value.Date.ToShortDateString()),
                    (DateTime.Parse(dateTimePicker2.Value.Date.ToShortDateString())));
                if (salary == 0)
                    subItems[4].Text = "ERROR DATE";
                else
                    subItems[4].Text = salary.ToString();
            }
        }

        private void AddWorkerBtn_Click(object sender, EventArgs e)
        {
            AddWorkerForm adf = new AddWorkerForm();
            adf.ShowDialog();
            if (adf.DialogResult == DialogResult.OK) {
               listView1.Items.Clear();
               DBHelper.GetInstance().LoadAllElementDB();
               LoadAllWorker();
            }
        }

        private void ShowSubBtn_Click(object sender, EventArgs e)
        {
            SubListBox.Items.Clear();
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                ListViewSubItemCollection subItems = listView1.SelectedItems[i].SubItems;
                Worker cw = CasheAllWorkerHelper.GetInstance()
                   .GetWorkerByID(int.Parse(subItems[0].Text));
                if (cw.Subbordinate != null) {
                    SubListBox.Items.Add("-----------"+cw.Name+"-----------");
                    for (int j = 0; j < cw.GetCountAllSubordinate(); j++) {
                        SubListBox.Items.Add(cw.Subbordinate[j].Name);
                    }
                }
            }
        }




        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0) {
                var udf = new UpdateWorkerForm(listView1.SelectedItems[0].SubItems[0].Text);
                udf.ShowDialog();
                if (udf.DialogResult == DialogResult.OK)
                {
                    listView1.Items.Clear();
                    DBHelper.GetInstance().LoadAllElementDB();
                    LoadAllWorker();
                }
            }
        }

        private void AllWorkerCalculate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ListViewSubItemCollection subItems = listView1.Items[i].SubItems;
                Worker group = CasheAllWorkerHelper.GetInstance()
                    .GetWorkerByID(int.Parse(subItems[0].Text));
                Worker cw = group.CurrentGroup.Equals(Worker.Group.Employee) ? (Employee)group
                    : (group.CurrentGroup.Equals(Worker.Group.Manager)) ? (Manager)group
                    : (group.CurrentGroup.Equals(Worker.Group.Salesman)) ? (Salesman)group : group;
                float salary = cw.GetPayroll(DateTime.Parse(dateTimePicker1.Value.Date.ToShortDateString()),
                    (DateTime.Parse(dateTimePicker2.Value.Date.ToShortDateString())));
                if (salary == 0)
                    subItems[4].Text = "ERROR DATE";
                else
                    subItems[4].Text = salary.ToString();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.SelectedItems.Count; i++) {
                var worker = CasheAllWorkerHelper.GetInstance().GetWorkerByID(int.Parse(listView1.SelectedItems[i].SubItems[0].Text));
                DBHelper.GetInstance().DeleteWorker(worker);
            }
            listView1.Items.Clear();
            DBHelper.GetInstance().LoadAllElementDB();
            LoadAllWorker();
        }
    }
}
