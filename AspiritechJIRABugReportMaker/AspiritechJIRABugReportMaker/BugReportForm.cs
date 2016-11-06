using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AspiritechJIRABugReportMaker
{
    public partial class BugReportForm : Form
    {
        public string bugReportText = "";

        public BugReportForm()
        {
            InitializeComponent();
        }

        private void BugReportForm_Shown(object sender, EventArgs e)
        {
            // Change the textbox text the the bug report text.
            txtBugReport.Text = bugReportText;
            // Highlight the text to show it's copyable.
            txtBugReport.SelectAll(); 
        }

        // Copies the bug report contents to the Windows clipboard.
        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(bugReportText);
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Bug Report";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            // Open the dialog box to write the bug report text to a file (no blank filenames).
            if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName != "")
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    sw.Write(bugReportText);
                saveFileDialog.Dispose();
            }
        }
    }
}
