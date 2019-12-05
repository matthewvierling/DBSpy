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
    public partial class MySQLConnectionForm : ConnectionForm
    {
        private MySqlConnection connection;
        public MySQLConnectionForm(string server, string port, string database, string userid, string password):base(server, port, database, userid, password){

            this.connectionCreated = this.CreateConnection();
            this.connectionOpen = this.OpenConnection();

            this.tableDisplay = new TableDisplay(this.database, this.getTableNames(), this.UpdateDataTableOnDoubleClick);
            this.dataDisplay = new DataDisplay();

            this.InitializeComponent();
        }

        private List<string> getTableNames(){

            List<string> tables = new List<string>();

            try{
                using (MySqlCommand cmd = new MySqlCommand("SHOW TABLES;", this.connection)){

                        using (IDataReader dr = cmd.ExecuteReader()){
                            
                            while (dr.Read()){
                                tables.Add(dr[0].ToString());
                            }
                        }
                    }
            }catch(Exception e){
                this.terminal.Text = e.ToString();
            }

            return tables;
        }

        protected override bool CreateConnection(){
            try{
                //create connection
                string connectionString = "server=" + this.server + ";database=" + this.database + ";port=" + this.port + ";uid=" + this.uid + ";pwd=" + this.pwd + ";";
                this.connection = new MySqlConnection(connectionString);
                return true;
            }catch(Exception e){
                //connection failed
                this.terminal.Text = (e.ToString());
                return false;
            }
        }

        protected override bool OpenConnection(){
            try{
                //open connection
                this.connection.Open();
                return true;
            }catch(Exception e){
                //open connection failed
                this.terminal.Text = (e.ToString());
                return false;
            }
        }

        protected override void CloseConnection(){
            this.connection.Close();
            //MessageBox.Show("closing.");
        }

        protected override int UpdateDataTableOnDoubleClick(){
            string table = this.tableDisplay.tablesTree.SelectedNode.Text;
            DataTable dataTable = new DataTable();
            try{
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM " + table, this.connection)){
                    adapter.Fill(dataTable);
                }
                this.dataDisplay.UpdateDataTable(dataTable);
            }catch(Exception e){
                this.terminal.Text = e.ToString();
            }

            return 0;
        }

    }

}
