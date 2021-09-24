using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using Azure;
using Azure.Storage.Blobs;
using System.Configuration;
using RSAAlgorithm;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Web;

namespace BackupToAzure
{
    public partial class Form1 : Form
    {
        private string _databaseName = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Database restore";
            dlg.Filter = "Backup File |*.bak";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtBoxFileName.Text = dlg.FileName;
                _databaseName = dlg.SafeFileName.Remove(dlg.SafeFileName.IndexOf('.'));
            }
        }

        private void btnBackupAzure_Click(object sender, EventArgs e)
        {
            string AzureUrl = ConfigurationManager.AppSettings["containerurl"];
            bool IsExist = false;

            try
            {
                if (txtBoxFileName.Text != "")
                {
                    //Check if DB exists or not first in SQL 
                    string IfExistQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", _databaseName);

                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString);
                    SqlCommand command = new SqlCommand(IfExistQuery, con);

                    con.Open();

                    object resultObj = command.ExecuteScalar();

                    int databaseID = 0;

                    if (resultObj != null)
                    {
                        int.TryParse(resultObj.ToString(), out databaseID);
                    }

                    IsExist = (databaseID > 0);


                    if (IsExist)
                    {
                        //Restore First to SQL
                        string sql = "Alter Database " + _databaseName + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                        sql += "Restore Database " + _databaseName + " FROM DISK ='" + txtBoxFileName.Text + "' WITH REPLACE;";

                        command = new SqlCommand(sql, con);
                        command.CommandTimeout = 25200;
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        string sql = "Restore Database " + _databaseName + " FROM DISK ='" + txtBoxFileName.Text + "' WITH REPLACE;";

                        command = new SqlCommand(sql, con);
                        command.CommandTimeout = 25200;
                        command.ExecuteNonQuery();
                    }


                    //Then Backup to Azure from SQL
                    if (txtBoxCredentialName.Text == "")
                        throw new Exception("Please input sql credential!");

                    //Replicate and show the RSA Encryption for the secret key
                    string decryptedText = string.Empty;
                    var SecretEncrypted = RSAEncryption.Encrypt(RSAEncryption.encoder.GetBytes(txtBoxAzureSecret.Text));
                    var SecretDecrypted = RSAEncryption.RSADecrypt(SecretEncrypted, ref decryptedText);

                    string makeCredentialToAzure = string.Format("IF NOT EXISTS (SELECT * FROM sys.credentials WHERE NAME = '" + txtBoxCredentialName.Text +
                    "') CREATE CREDENTIAL [" + txtBoxCredentialName.Text + "] WITH IDENTITY = '" + txtBoxAzureStorage.Text + "', SECRET ='" + decryptedText + "' ");
                    command = new SqlCommand(makeCredentialToAzure, con);
                    command.CommandTimeout = 25200;
                    command.ExecuteNonQuery();


                    //Set database to full recovery
                    string alterDatabase = string.Format("ALTER DATABASE " + _databaseName + " SET RECOVERY FULL");
                    command = new SqlCommand(alterDatabase, con);
                    command.CommandTimeout = 25200;
                    command.ExecuteNonQuery();

                    //Backup to Azure as Blob
                    if (txtBoxAzureFileName.Text == "")
                        throw new Exception("Please enter a file name for backup to Azure Blob!");

                    if (txtBoxAzureFileName.Text.Contains(".bak"))
                        AzureUrl = AzureUrl + txtBoxAzureFileName.Text;
                    else
                        AzureUrl = AzureUrl + "/" + txtBoxAzureFileName.Text + ".bak";

                    string backupDatabase = string.Format("BACKUP DATABASE " + _databaseName + " TO URL = N'" + AzureUrl + "'  WITH CREDENTIAL = '" +
                    txtBoxCredentialName.Text + "'");
                    command = new SqlCommand(backupDatabase, con);
                    command.CommandTimeout = 25200;
                    command.ExecuteNonQuery();

                    command.Dispose();
                    con.Close();
                    con.Dispose();
                    MessageBox.Show("Database Backed Up Successfully!");

                }
                else
                {
                    throw new Exception("No database backup file has been selected!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RSAEncryption.GenerateKey();
        }

        private void btnRestoreFromBlob_Click(object sender, EventArgs e)
        {
            //var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings.Get("StorageConnectionString").ToString());
            //var blobClient = storageAccount.CreateCloudBlobClient();
            //// Get Blob Container  
            //var container = blobClient.GetContainerReference(ConfigurationManager.AppSettings.Get("Container").ToString());
            //// Get reference to blob (binary content)  
            //var pageBlob = container.GetPageBlobReference(fileName);
            //string directoryPath = HttpServerUtility.MapPath(ConfigurationManager.AppSettings.Get(ConfigurationManager.AppSettings.Get("FolderName").ToString()).ToString());
            //string filePath = directoryPath + "\\" + fileName;
            //if (!Directory.Exists(directoryPath))
            //{
            //    Directory.CreateDirectory(directoryPath);
            //}

            //blockBlob.DownloadToFile(filePath, FileMode.OpenOrCreate);
        }
    }
}
