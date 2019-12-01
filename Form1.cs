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

namespace DBSpy
{
    public partial class Form1 : Form
    {
        //Parameters
        private string[] databaseOptions = new string[]{"MySQL"};
        private string currentDatabaseType;
        private string currentDatabase;

        public Form1()
        {
            currentDatabaseType = databaseOptions[0];
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
            }
            catch(Exception ex){
                MessageBox.Show(ex.ToString());
            }
            finally{
                this.databasesOnServerCombo.Items.AddRange(databases.ToArray());
                this.databasesOnServerCombo.Refresh();
            }
            
        }

        private void ConnectToDB(object source, EventArgs e){

            
        }

        private void ChangeDBType(object source, EventArgs e){
            this.databaseTypeCombo.Refresh();

            if(this.databaseTypeCombo.SelectedItem != null){
                this.currentDatabaseType = this.databaseTypeCombo.SelectedItem.ToString();
            }

        }

        private void DBToConnect(object source, EventArgs e){
            this.databaseTypeCombo.Refresh();

            if(this.databasesOnServerCombo.SelectedItem != null){
                this.currentDatabase = this.databasesOnServerCombo.SelectedItem.ToString();
            }

            this.Terminal.Text = this.currentDatabase;

        }

    }

    
}
