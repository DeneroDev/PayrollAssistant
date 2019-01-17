using System;
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
            DBHelper.GetInstance().SaveResult(CasheAllWolkerHelper.GetInstance().GetAllWorker());
            DBHelper.GetInstance().CloseDB();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DBHelper.GetInstance().connectDB();
            DBHelper.GetInstance().LoadAllElementDB();
            LoadAllWorker();
        }

        private void LoadAllWorker() {
            List<Worker> workers = CasheAllWolkerHelper.GetInstance().GetAllWorker();
            for (int i = 0; i < workers.Count; i++) {
                ListViewItem lvi = new ListViewItem(workers[i].GetID().ToString());
                lvi.SubItems.Add(workers[i].GetName());
                lvi.SubItems.Add(workers[i].GetDate().ToShortDateString());
                lvi.SubItems.Add(workers[i].GetCurrentGroup().ToString());
                lvi.SubItems.Add("-");
                lvi.SubItems.Add(workers[i].GetCountAllSubordinate().ToString());
                if(workers[i].GetChief()!=null)
                    lvi.SubItems.Add(workers[i].GetChief().GetName());
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
                CurrentWorker cw = (CurrentWorker)CasheAllWolkerHelper.GetInstance()
                    .GetWorkerByID(int.Parse(subItems[0].Text));
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
                Worker cw = CasheAllWolkerHelper.GetInstance()
                   .GetWorkerByID(int.Parse(subItems[0].Text));
                if (cw.GetSubbordinate() != null) {
                    SubListBox.Items.Add("-----------"+cw.GetName()+"-----------");
                    for (int j = 0; j < cw.GetCountAllSubordinate(); j++) {
                        SubListBox.Items.Add(cw.GetSubbordinate()[j].GetName());
                    }
                }
            }
        }




        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            DBHelper.GetInstance().LoadAllElementDB();
            LoadAllWorker();
        }

        private void AllWorkerCalculate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                ListViewSubItemCollection subItems = listView1.Items[i].SubItems;
                CurrentWorker cw = (CurrentWorker)CasheAllWolkerHelper.GetInstance()
                    .GetWorkerByID(int.Parse(subItems[0].Text));
                float salary = cw.GetPayroll(DateTime.Parse(dateTimePicker1.Value.Date.ToShortDateString()),
                    (DateTime.Parse(dateTimePicker2.Value.Date.ToShortDateString())));
                if (salary == 0)
                    subItems[4].Text = "ERROR DATE";
                else
                    subItems[4].Text = salary.ToString();
            }
        }
    }
}
