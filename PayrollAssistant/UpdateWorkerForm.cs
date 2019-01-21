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
    public partial class UpdateWorkerForm : Form
    {
        public UpdateWorkerForm(string id)
        {
            InitializeComponent();
            IdLabel.Text = id.ToString();
            LoadAllChiefToList();
         
        }

        private void LoadAllChiefToList()
        {
            List<Worker> workers = CasheAllWorkerHelper.GetInstance().GetAllWorker();
            for (int i = 0; i < workers.Count; i++)
            {
                Console.WriteLine($"{workers[i].Id}/{int.Parse(IdLabel.Text)}");
                if (workers[i].CurrentGroup != Worker.Group.Employee && workers[i].Id != int.Parse(IdLabel.Text))
                    ChiefListBox.Items.Add(workers[i].Name);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (FIOTextBox.Text != "" && GroupListBox.SelectedItem != null)
            {
                var nc = CasheAllWorkerHelper.GetInstance().GetWorkerByID(int.Parse(IdLabel.Text));
                if (ChiefListBox.SelectedItems.Count > 0)
                {
                    nc.UpdateChief(CasheAllWorkerHelper.GetInstance().GetWorkerByName(ChiefListBox.SelectedItem.ToString()));
                }
                else
                    nc.Chief = null;
                nc.Name = FIOTextBox.Text;
                nc.Date = DateTime.Parse(dateTimePicker1.Value.Date.ToShortDateString());
                Enum.TryParse(GroupListBox.SelectedItem.ToString(), out Worker.Group group);
                nc.CurrentGroup = group;
                DBHelper.GetInstance().UpdateWorker(nc);
                DialogResult = DialogResult.OK;
                Hide();
            }
        }
    }
}
