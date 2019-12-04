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
            this.InitializeComponent();
        }

        protected override bool CreateConnection(){
            try{
                //create connection
                string connectionString = "server=" + this.server + "database=" + this.database + ";port=" + this.port + ";uid=" + this.uid + ";pwd=" + this.pwd + ";";
                this.connection = new MySqlConnection(connectionString);
                return true;
            }catch(Exception e){
                //connection failed
                MessageBox.Show(e.ToString());
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
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        protected override void CloseConnection(){
            this.connection.Close();
            MessageBox.Show("closing.");
        }

    }

}
