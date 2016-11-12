using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AspiritechJIRABugReportMaker
{
    public partial class JiraIDForm : Form
    {
        public string jiraID;

        public JiraIDForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Play an error sound if the user attempts to enter a blank text field.
            if (txtJiraID.Text == "")
            {
                System.Media.SystemSounds.Asterisk.Play();
            }
            else
            {
                jiraID = txtJiraID.Text;
                this.Close();
            }
        }
    }
}
