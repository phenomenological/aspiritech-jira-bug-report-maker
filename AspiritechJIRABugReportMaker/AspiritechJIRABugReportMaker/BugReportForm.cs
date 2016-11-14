using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        public string jiraID;
        public string summary;
        public string reporter;
        public string testCase, testStep;
        public string homerGabboVersion;
        public string deviceVersions;
        public string internetConnectionType;
        public string testEnvironment;
        public string stepsToReproduce;
        public string expectedResult;
        public string actualResult;
        public string timesRepeatableNum, timesRepeatableDen;
        public string testMachineNames;
        public string workaround;
        public string otherNotesOrComments;

        private JiraIDForm jiraIDForm;
        private SqlConnection con;

        public BugReportForm()
        {
            InitializeComponent();
        }

        private void BugReportForm_Shown(object sender, EventArgs e)
        {
            populateBugReport();
            // Change the textbox text the the bug report text.
            txtBugReport.Text = bugReportText;
            // Highlight the text to show it's copyable.
            txtBugReport.SelectAll(); 
        }

        private void populateBugReport()
        {
            bugReportText =
                "Summary: " + summary + "\r\n"
                + "Reporter: " + reporter + "\r\n \r\n"
                + "*Test Case/Step:* \r\n" + testCase + "/" + testStep + "\r\n"
                + "*Homer/Gabbo version:* \r\n" + homerGabboVersion + "\r\n"
                + "*Device Version:* \r\n" + deviceVersions + "\r\n"
                + "*Connection:* \r\n" + internetConnectionType + "\r\n"
                + "*Test Environment:* \r\n" + testEnvironment + "\r\n"
                + "*Steps to Reproduce:* \r\n" + stepsToReproduce + "\r\n \r\n"
                + "*Expected Result:* \r\n" + expectedResult + "\r\n"
                + "*Actual Result:* \r\n" + actualResult + "\r\n \r\n"
                + "*Times Repeatable:* \r\n" + timesRepeatableNum + " / " + timesRepeatableDen + " Times\r\n"
                + "*Test Machine Name(s):* \r\n" + testMachineNames + "\r\n"
                + "*Workaround:* \r\n" + workaround + "\r\n"
                + "*Other Notes/Comments*: \r\n" + otherNotesOrComments
                ;
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
            saveFileDialog.DefaultExt = "";
            saveFileDialog.Filter = " files (*.)|*.|All files (*.*)|*.*";

            // Open the dialog box to write the bug report text to a file (no blank filenames).
            if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName != "")
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    sw.Write(bugReportText);
                saveFileDialog.Dispose();
            }
        }

        private void btnSubmitToDatabase_Click(object sender, EventArgs e)
        {
            if (jiraIDForm != null && !jiraIDForm.IsDisposed)
            {
                jiraIDForm.Dispose();
            }

            jiraIDForm = new JiraIDForm();

            jiraIDForm.ShowDialog();
            // Since the window from the previous line is a dialog we can stop the code here until the window is closed.
            if (jiraIDForm.checkIfReadyToSubmit()) // Make sure the user didn't Cancel out of or close the window.
            {
                jiraID = jiraIDForm.jiraID;
                jiraIDForm.Dispose();
                submitToSQLServer(); // Everything is ready now to submit to the database.
            }
        }

        // This is called after the Jira ID Form is submitted.
        public void submitToSQLServer()
        {
            try
            {
                con = new SqlConnection();
                // The connection string values are hard-coded for now.
                con.ConnectionString = @"Server=ASPIRITECH-PC21; Database=master; User Id=Aspiritech; Password=Shalom@1";
                con.Open();
                SqlCommand command = new SqlCommand("INSERT INTO dbo.jira_reports VALUES ('"
                    + jiraID
                    + "', GETDATE(), '"
                    + summary
                    + "', '" + reporter
                    + "', '" + testCase
                    + "', '" + testStep
                    + "', '" + homerGabboVersion
                    + "', '" + deviceVersions
                    + "', '" + internetConnectionType
                    + "', '" + testEnvironment
                    + "', '" + stepsToReproduce
                    + "', '" + expectedResult
                    + "', '" + actualResult
                    + "', '" + timesRepeatableNum
                    + "', '" + timesRepeatableDen
                    + "', '" + testMachineNames
                    + "', '" + workaround
                    + "', '" + otherNotesOrComments
                    + "')");
                command.Connection = con;
                // Execute the SQL command
                AsyncCallback callback = new AsyncCallback(HandleCallback);
                command.BeginExecuteNonQuery(callback, command);
            }
            catch (Exception submitException)
            {
                MessageBox.Show(submitException.Message);
            }
        }

        // Callback method for the asynchronius SQL command.
        private void HandleCallback(IAsyncResult result)
        {
            try
            {
                // Create and execute the SQL INSERT command.
                SqlCommand command = (SqlCommand)result.AsyncState;
                command.EndExecuteNonQuery(result);
                // We're all done here.  Close the SQL connection.
                con.Close();
                // Let the user know the bug was successfully submitted:
                System.Media.SystemSounds.Asterisk.Play();
                MessageBox.Show("Bug entry successful!", "Bug Entry Status");
            }
            catch (Exception asyncException)
            {
                MessageBox.Show(asyncException.Message);
            }
        }
    }
}
