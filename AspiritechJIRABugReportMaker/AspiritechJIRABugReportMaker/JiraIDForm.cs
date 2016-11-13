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
        private bool isReadyToSubmit = false; // Used to check if the form was closed without submitting.

        public JiraIDForm()
        {
            InitializeComponent();
            // Simulate the "Submit" button when the user presses the Enter key.
            this.AcceptButton = btnSubmit;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Play an error sound if the user attempts to enter a blank text field.
            if (txtJiraID.Text == "")
            {
                System.Media.SystemSounds.Beep.Play();
            }
            else
            {
                jiraID = txtJiraID.Text;
                isReadyToSubmit = true;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // This is an accessor method to check if the form was closed without submitting anything.
        public bool checkIfReadyToSubmit()
        {
            return isReadyToSubmit;
        }
    }
}
