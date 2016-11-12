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

            bugReportInstance.ShowDialog();
            bugReportInstance.BringToFront();
        }

        // Fill in the Bug Report window with the text entered in the Main Window.
        private void populateBugReport()
        {
            bugReportInstance.summary = txtSummary.Text;
            bugReportInstance.reporter = txtReporter.Text;
            bugReportInstance.testCase = txtTestCase.Text;
            bugReportInstance.testStep = txtTestStep.Text;
            bugReportInstance.homerGabboVersion = txtHomerGabboVersion.Text;
            bugReportInstance.deviceVersions = txtDeviceVersion.Text;
            bugReportInstance.internetConnectionType = txtInternetConnectionType.Text;
            bugReportInstance.testEnvironment = txtTestEnvironment.Text;
            bugReportInstance.stepsToReproduce = txtStepsToReproduce.Text;
            bugReportInstance.expectedResult = txtExpectedResult.Text;
            bugReportInstance.actualResult = txtActualResult.Text;
            bugReportInstance.timesRepeatableNum = txtTimesRepeatableNumerator.Text;
            bugReportInstance.timesRepeatableDen = txtTimesRepeatableDenominator.Text;
            bugReportInstance.testMachineNames = txtTestMachineNames.Text;
            bugReportInstance.workaround = txtWorkaround.Text;
            bugReportInstance.otherNotesOrComments = txtOtherNotesOrComments.Text;
        }
    }
}
