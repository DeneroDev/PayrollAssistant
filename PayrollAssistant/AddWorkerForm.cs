using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollAssistant
{
    public partial class AddWorkerForm : Form
    {
        public AddWorkerForm()
        {
            InitializeComponent();
        }

        private void AddWorkerForm_Load(object sender, EventArgs e)
        {
            LoadAllChiefToList();
        }

        private void LoadAllChiefToList() {
            List<Worker> workers = CasheAllWolkerHelper.GetInstance().GetAllWorker();
            for (int i = 0; i < workers.Count; i++) {
                if (workers[i].CurrentGroup != Worker.Group.Employee)
                    ChiefListBox.Items.Add(workers[i].Name);
            }
        }


        private void AddWorkerBtn_Click(object sender, EventArgs e)
        {
            if (FIOTextBox.Text != "" && GroupListBox.SelectedItem != null) {
                Enum.TryParse(GroupListBox.SelectedItem.ToString(), out Worker.Group currentGroup);
                var nc = new CurrentWorker(0,
                     FIOTextBox.Text, DateTime.Parse(dateTimePicker1.Value.Date.ToShortDateString()),
                     currentGroup);

                if (ChiefListBox.SelectedItems.Count>0)
                {
                    nc.UpdateChief(CasheAllWolkerHelper.GetInstance().GetWorkerByName(ChiefListBox.SelectedItem.ToString()));
                }
             
               DBHelper.GetInstance().AddWorker(nc);
                DialogResult = DialogResult.OK;
                Hide();

            }
        }


       
    }
}
