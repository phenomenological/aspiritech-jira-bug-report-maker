// Aspiritech JIRA Bug Report Maker by Alex Fisher

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
    public partial class MainWindow : Form
    {

        private BugReportForm bugReportInstance;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            if (bugReportInstance != null && !bugReportInstance.IsDisposed)
            {
                bugReportInstance.Dispose();
            }

            bugReportInstance = new BugReportForm();

            populateBugReport();

            bugReportInstance.Show();
            bugReportInstance.BringToFront();
        }

        // Fill in the Bug Report window with the text entered in the Main Window.
        private void populateBugReport()
        {
            bugReportInstance.bugReportText =
                "Summary: " + txtSummary.Text + "\r\n"
                + "Reporter: " + txtReporter.Text + "\r\n\r\n"
                + "*Test Case/Step:* \r\n" + txtTestCase.Text + "/" + txtTestStep.Text + "\r\n"
                + "*Homer/Gabbo version:* \r\n" + txtHomerGabboVersion.Text + "\r\n"
                + "*Connection:* \r\n" + txtInternetConnectionType.Text + "\r\n"
                + "*Test Environment:* \r\n" + txtTestEnvironment.Text + "\r\n"
                + "*Steps to Reproduce:* \r\n" + txtStepsToReproduce.Text + "\r\n\r\n"
                + "*Expected Result:* \r\n" + txtExpectedResult.Text + "\r\n"
                + "*Actual Result:* \r\n" + txtActualResult.Text + "\r\n\r\n"
                + "*Times Repeatable:* \r\n" + txtTimesRepeatableNumerator.Text + " / " + txtTimesRepeatableDenominator.Text + " Times\r\n"
                + "*Test Machine Name(s):* \r\n" + txtTestMachineNames.Text + "\r\n"
                + "*Workaround:* \r\n" + txtWorkaround.Text + "\r\n"
                + "*Other Notes/Comments*: \r\n" + txtOtherNotesOrComments.Text
                ;
        }
    }
}
