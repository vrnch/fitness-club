namespace fitness_club
{
    partial class Employee
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
            this.employeeTabs = new System.Windows.Forms.TabControl();
            this.viewClient = new System.Windows.Forms.TabPage();
            this.signUpClient = new System.Windows.Forms.TabPage();
            this.editClientInfo = new System.Windows.Forms.TabPage();
            this.issueWithSubscription = new System.Windows.Forms.TabPage();
            this.employeeTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // employeeTabs
            // 
            this.employeeTabs.Controls.Add(this.viewClient);
            this.employeeTabs.Controls.Add(this.signUpClient);
            this.employeeTabs.Controls.Add(this.editClientInfo);
            this.employeeTabs.Controls.Add(this.issueWithSubscription);
            this.employeeTabs.Location = new System.Drawing.Point(12, 12);
            this.employeeTabs.Name = "employeeTabs";
            this.employeeTabs.SelectedIndex = 0;
            this.employeeTabs.Size = new System.Drawing.Size(776, 426);
            this.employeeTabs.TabIndex = 0;
            // 
            // viewClient
            // 
            this.viewClient.Location = new System.Drawing.Point(4, 25);
            this.viewClient.Name = "viewClient";
            this.viewClient.Padding = new System.Windows.Forms.Padding(3);
            this.viewClient.Size = new System.Drawing.Size(768, 397);
            this.viewClient.TabIndex = 0;
            this.viewClient.Text = "View client";
            this.viewClient.UseVisualStyleBackColor = true;
            // 
            // signUpClient
            // 
            this.signUpClient.Location = new System.Drawing.Point(4, 25);
            this.signUpClient.Name = "signUpClient";
            this.signUpClient.Padding = new System.Windows.Forms.Padding(3);
            this.signUpClient.Size = new System.Drawing.Size(768, 397);
            this.signUpClient.TabIndex = 1;
            this.signUpClient.Text = "Sign up new client";
            this.signUpClient.UseVisualStyleBackColor = true;
            // 
            // editClientInfo
            // 
            this.editClientInfo.Location = new System.Drawing.Point(4, 25);
            this.editClientInfo.Name = "editClientInfo";
            this.editClientInfo.Padding = new System.Windows.Forms.Padding(3);
            this.editClientInfo.Size = new System.Drawing.Size(768, 397);
            this.editClientInfo.TabIndex = 2;
            this.editClientInfo.Text = "Edit client personal info";
            this.editClientInfo.UseVisualStyleBackColor = true;
            // 
            // issueWithSubscription
            // 
            this.issueWithSubscription.Location = new System.Drawing.Point(4, 25);
            this.issueWithSubscription.Name = "issueWithSubscription";
            this.issueWithSubscription.Padding = new System.Windows.Forms.Padding(3);
            this.issueWithSubscription.Size = new System.Drawing.Size(768, 397);
            this.issueWithSubscription.TabIndex = 3;
            this.issueWithSubscription.Text = "Issue with subscription";
            this.issueWithSubscription.UseVisualStyleBackColor = true;
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.employeeTabs);
            this.Name = "Employee";
            this.Text = "Employee";
            this.employeeTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl employeeTabs;
        private System.Windows.Forms.TabPage viewClient;
        private System.Windows.Forms.TabPage signUpClient;
        private System.Windows.Forms.TabPage editClientInfo;
        private System.Windows.Forms.TabPage issueWithSubscription;
    }
}