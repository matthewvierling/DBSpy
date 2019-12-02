using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace DBSpy
{
    public partial class Form1 : Form
    {
        //Parameters
        private string[] databaseOptions = new string[]{"MySQL"};
        private string currentDBServerType;
        private string currentDatabase;

        public Form1()
        {
            currentDBServerType = databaseOptions[0];
            InitializeComponent();
        }

        //returns the names of all the Databases on a MySQL Database
        private void UpdateDBSpy(object source, EventArgs e){

            string conString = "";
            List<string> databases = new List<string>();

            //try to connect to server and read the tables
            try{

                conString = "server=" + this.IPTextBox.Text + ";uid=" + this.UserTextBox.Text + ";pwd=" + this.PasswordTextBox.Text + ";";

                using (MySqlConnection connection = new MySqlConnection(conString)){

                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SHOW DATABASES;", connection)){

                        using (IDataReader dr = cmd.ExecuteReader()){
                            
                            while (dr.Read()){
                                databases.Add(dr[0].ToString());
                            }
                        }
                    }
                }
                //clear terminal
                this.Terminal.Text = "";
            }
            catch(Exception ex){
                //MessageBox.Show(ex.ToString());
                this.Terminal.Text = ex.ToString();
            }
            finally{
                this.databasesOnServerCombo.Items.AddRange(databases.ToArray());
                this.databasesOnServerCombo.Refresh();
            }
            
        }

        //called when the connect button is pressed.
        private void ConnectToDB(object source, EventArgs e){

            if(this.currentDBServerType == "MySQL"){
                Thread thread = new Thread(StartMySQLConnectionForm);
                thread.Start();
            }
                      
        }

        //called when database server type combo box is closed
        private void ChangeDBServerType(object source, EventArgs e){
            this.databaseTypeCombo.Refresh();

            if(this.databaseTypeCombo.SelectedItem != null){
                this.currentDBServerType = this.databaseTypeCombo.SelectedItem.ToString();
            }

        }

        //called when database selection combobox is closed
        private void DBToConnect(object source, EventArgs e){
            this.databaseTypeCombo.Refresh();

            if(this.databasesOnServerCombo.SelectedItem != null){
                this.currentDatabase = this.databasesOnServerCombo.SelectedItem.ToString();
            }

        }

        private void StartMySQLConnectionForm(){
            try{
                Application.Run(new MySQLConnectionForm(this.IPTextBox.Text, this.currentDatabase, this.UserTextBox.Text, this.PasswordTextBox.Text));
            }
            catch{
                this.Terminal.Text = "MySQLConnectionForm failed to start.";
            }
            
        }

    }

    
}
