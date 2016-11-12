namespace AspiritechJIRABugReportMaker
{
    partial class BugReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BugReportForm));
            this.txtBugReport = new System.Windows.Forms.TextBox();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnSubmitToDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBugReport
            // 
            this.txtBugReport.AcceptsReturn = true;
            this.txtBugReport.AcceptsTab = true;
            this.txtBugReport.AllowDrop = true;
            this.txtBugReport.Location = new System.Drawing.Point(12, 77);
            this.txtBugReport.Multiline = true;
            this.txtBugReport.Name = "txtBugReport";
            this.txtBugReport.ReadOnly = true;
            this.txtBugReport.Size = new System.Drawing.Size(493, 424);
            this.txtBugReport.TabIndex = 0;
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Location = new System.Drawing.Point(13, 13);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(233, 23);
            this.btnCopyToClipboard.TabIndex = 1;
            this.btnCopyToClipboard.Text = "Copy Text to Clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(252, 13);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(254, 23);
            this.btnSaveAs.TabIndex = 2;
            this.btnSaveAs.Text = "Save As...";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnSubmitToDatabase
            // 
            this.btnSubmitToDatabase.Location = new System.Drawing.Point(13, 507);
            this.btnSubmitToDatabase.Name = "btnSubmitToDatabase";
            this.btnSubmitToDatabase.Size = new System.Drawing.Size(194, 23);
            this.btnSubmitToDatabase.TabIndex = 3;
            this.btnSubmitToDatabase.Text = "Submit to Database...";
            this.btnSubmitToDatabase.UseVisualStyleBackColor = true;
            this.btnSubmitToDatabase.Click += new System.EventHandler(this.btnSubmitToDatabase_Click);
            // 
            // BugReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 542);
            this.Controls.Add(this.btnSubmitToDatabase);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.txtBugReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BugReportForm";
            this.Text = "Bug Report";
            this.Shown += new System.EventHandler(this.BugReportForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBugReport;
        private System.Windows.Forms.Button btnCopyToClipboard;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnSubmitToDatabase;
    }
}