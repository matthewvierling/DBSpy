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

            this.tableDisplay = new TableDisplay(this.database, this.getTableNames());
            this.dataDisplay = new DataDisplay();
            
            //test code
            this.dataDisplay.UpdateDataTable(this.getTableData());
            //and test code

            this.InitializeComponent();
        }

        private DataTable getTableData(){
            DataTable dataTable = new DataTable();

            //test code
            dataTable.Columns.Add("Col Test1");
            dataTable.Columns.Add("Col Test2");
            dataTable.Columns.Add("Col Test3");
            dataTable.Columns.Add("Col Test4");
            dataTable.Columns.Add("Col Test5");
            dataTable.Columns.Add("Col Test6");
            dataTable.Columns.Add("Col Test7");
            dataTable.Columns.Add("Col Test8");

            DataRow row1 = dataTable.NewRow();
            row1["Col test1"] = "row1,1";
            row1["Col test2"] = "row1,2";
            row1["Col test3"] = "row1,3";
            row1["Col test4"] = "row1,4";
            row1["Col test5"] = "row1,5";
            row1["Col test6"] = "row1,6";
            dataTable.Rows.Add(row1);

            //end test code

            return dataTable;
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

    }

}
