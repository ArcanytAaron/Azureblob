
namespace BackupToAzure
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnBackupAzure = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxFileName = new System.Windows.Forms.TextBox();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxCredentialName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxAzureStorage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxAzureSecret = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxAzureFileName = new System.Windows.Forms.TextBox();
            this.btnRestoreFromBlob = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(214, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Backup to Azure";
            // 
            // btnBackupAzure
            // 
            this.btnBackupAzure.Location = new System.Drawing.Point(33, 129);
            this.btnBackupAzure.Name = "btnBackupAzure";
            this.btnBackupAzure.Size = new System.Drawing.Size(179, 60);
            this.btnBackupAzure.TabIndex = 1;
            this.btnBackupAzure.Text = "Backup to Azure Blob";
            this.btnBackupAzure.UseVisualStyleBackColor = true;
            this.btnBackupAzure.Click += new System.EventHandler(this.btnBackupAzure_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "File Location:";
            // 
            // txtBoxFileName
            // 
            this.txtBoxFileName.Location = new System.Drawing.Point(383, 148);
            this.txtBoxFileName.Name = "txtBoxFileName";
            this.txtBoxFileName.Size = new System.Drawing.Size(289, 22);
            this.txtBoxFileName.TabIndex = 3;
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Location = new System.Drawing.Point(678, 147);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(75, 23);
            this.BtnBrowse.TabIndex = 4;
            this.BtnBrowse.Text = "Browse";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "SQL Credential Name:";
            // 
            // txtBoxCredentialName
            // 
            this.txtBoxCredentialName.Location = new System.Drawing.Point(383, 201);
            this.txtBoxCredentialName.Name = "txtBoxCredentialName";
            this.txtBoxCredentialName.Size = new System.Drawing.Size(289, 22);
            this.txtBoxCredentialName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Azure Storage Account:";
            // 
            // txtBoxAzureStorage
            // 
            this.txtBoxAzureStorage.Location = new System.Drawing.Point(383, 245);
            this.txtBoxAzureStorage.Name = "txtBoxAzureStorage";
            this.txtBoxAzureStorage.Size = new System.Drawing.Size(289, 22);
            this.txtBoxAzureStorage.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(229, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Azure Storage Secret:";
            // 
            // txtBoxAzureSecret
            // 
            this.txtBoxAzureSecret.Location = new System.Drawing.Point(383, 291);
            this.txtBoxAzureSecret.Name = "txtBoxAzureSecret";
            this.txtBoxAzureSecret.Size = new System.Drawing.Size(289, 22);
            this.txtBoxAzureSecret.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(261, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Azure File Name:";
            // 
            // txtBoxAzureFileName
            // 
            this.txtBoxAzureFileName.Location = new System.Drawing.Point(383, 325);
            this.txtBoxAzureFileName.Name = "txtBoxAzureFileName";
            this.txtBoxAzureFileName.Size = new System.Drawing.Size(289, 22);
            this.txtBoxAzureFileName.TabIndex = 12;
            // 
            // btnRestoreFromBlob
            // 
            this.btnRestoreFromBlob.Location = new System.Drawing.Point(33, 395);
            this.btnRestoreFromBlob.Name = "btnRestoreFromBlob";
            this.btnRestoreFromBlob.Size = new System.Drawing.Size(179, 60);
            this.btnRestoreFromBlob.TabIndex = 13;
            this.btnRestoreFromBlob.Text = "Restore from Azure Blob";
            this.btnRestoreFromBlob.UseVisualStyleBackColor = true;
            this.btnRestoreFromBlob.Click += new System.EventHandler(this.btnRestoreFromBlob_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 546);
            this.Controls.Add(this.btnRestoreFromBlob);
            this.Controls.Add(this.txtBoxAzureFileName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBoxAzureSecret);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBoxAzureStorage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxCredentialName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnBrowse);
            this.Controls.Add(this.txtBoxFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBackupAzure);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBackupAzure;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxFileName;
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxCredentialName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxAzureStorage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxAzureSecret;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxAzureFileName;
        private System.Windows.Forms.Button btnRestoreFromBlob;
    }
}

